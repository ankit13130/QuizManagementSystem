using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using QuizManagement.Core.Builder;
using QuizManagement.Core.Contract;
using QuizManagement.Core.Domain.CustomExceptions;
using QuizManagement.Core.Domain.Helper;
using QuizManagement.Core.Domain.RequestModels;
using QuizManagement.Core.Domain.ResponseModels;
using QuizManagement.Infra.Contract;
using QuizManagement.Infra.Domain.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace QuizManagement.Core.Services;

public class UserServices : IUserServices
{
    private readonly IUserRepository _userRepository;
    private readonly IConfiguration _configuration;
    private readonly IEmailServices _emailServices;
    private readonly IMapper _mapper;
    public UserServices(IUserRepository userRepository, IConfiguration configuration, IMapper mapper, IEmailServices emailServices)
    {
        _userRepository = userRepository;
        _configuration = configuration;
        _mapper = mapper;
        _emailServices = emailServices;
    }

    //helper methods
    private User AuthenticateUser(LoginRequestModel loginRequestModel)
    {
        EncryptionDecryption encryptionDecryption = new EncryptionDecryption();
        User user = _userRepository.GetUserAsync(loginRequestModel.Email).Result;

        if (user == null || !user.IsActive)
            throw new Exception("User Not Found");

        if (!encryptionDecryption.VerifyPassword(loginRequestModel.Password, user.PasswordHash, Convert.FromHexString(user.PasswordSalt)))
            throw new Exception("Wrong Password");

        return user;
    }
    private string GenerateToken(User user)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        List<Claim> claims = new List<Claim>
        {
            new Claim(ClaimTypes.Sid,user.UserId.ToString()),
            new Claim(ClaimTypes.Name,user.UserName)
        };
        foreach (var role in user.UserRoles)
        {
            claims.Add(new Claim(ClaimTypes.Role, role.Role.RoleName));
        }

        var token = new JwtSecurityToken(_configuration["Jwt:Issuer"],
            _configuration["Jwt:Audience"],
            claims,
            expires: DateTime.Now.AddMinutes(20),
            signingCredentials: credentials);
        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public async Task<string> LoginAsync(LoginRequestModel loginRequestModel)
    {
        string response = null;
        var user = AuthenticateUser(loginRequestModel);
        if (user != null)
        {
            var tokenString = GenerateToken(user);
            response = tokenString;
        }
        return response;
    }
    public async Task SignupAsync(UserRequestModel userRequestModel)
    {
        if (_userRepository.GetUserAsync(userRequestModel.Email).Result != null)
        {
            throw new BadRequestException("User Already Exists");
        }

        EncryptionDecryption encryptDecrypt = new EncryptionDecryption();
        string passwordHash = encryptDecrypt.HashPasword(userRequestModel.Password, out var salt);
        string passwordSalt = Convert.ToHexString(salt);
        
        //OTP Generate
        long otp = new Random().Next(100000, 999999);

        User user = UserBuilder.Build(userRequestModel, passwordHash, passwordSalt, otp);

        await _userRepository.AddUserAsync(user);

        //email services
        Console.WriteLine(_emailServices.SendEmailAsync(userRequestModel.Email, otp.ToString()));
    }

    public async Task<UserResponseModel> GetUserAsync(long userId)
    {
        return _mapper.Map<UserResponseModel>(await _userRepository.GetUserAsync(userId));
    }

    public async Task<User> GetUserAsync(string userEmail)
    {
        return await _userRepository.GetUserAsync(userEmail);
    }

    public async Task UpdateUserAsync(User user)
    {
        await _userRepository.UpdateUserAsync(user);
    }
}
