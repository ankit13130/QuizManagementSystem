using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuizManagement.Core.Contract;
using QuizManagement.Core.Domain.CustomExceptions;
using QuizManagement.Core.Domain.Helper;
using QuizManagement.Core.Domain.RequestModels;
using System.Security.Claims;

namespace QuizManagement.API.Controllers;

[Route("[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserServices _userServices;
    private readonly IFeedbackServices _feedbackServices;
    private readonly IHttpContextAccessor _contextAccessor;
    private readonly IEmailServices _emailServices;
    private readonly long _loginUserId;
    //private readonly List<string> _roles;

    public UserController(IUserServices userServices, IHttpContextAccessor contextAccessor, IFeedbackServices feedbackServices, IEmailServices emailServices)
    {
        _userServices = userServices;
        _contextAccessor = contextAccessor;
        _loginUserId = Convert.ToInt64(contextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Sid));
        //_roles = contextAccessor.HttpContext.User.FindAll(ClaimTypes.Role).Select(x => x.Value).ToList();
        _feedbackServices = feedbackServices;
        _emailServices = emailServices;
    }

    [HttpPost("signup")]
    public async Task<IActionResult> SignupAsync(UserRequestModel userRequestModel)
    {
        _contextAccessor.HttpContext.Session.SetString("EMAIL", userRequestModel.Email);

        await _userServices.SignupAsync(userRequestModel);
        return Created("Success", null);
    }

    [HttpPost("login")]
    public async Task<IActionResult> LoginAsync(LoginRequestModel loginRequestModel)
    {
        return Ok(await _userServices.LoginAsync(loginRequestModel));
    }

    [HttpPost("verifyAccount/{otp}")]
    public async Task<IActionResult> VerifyAsync(long otp)
    {
        string status = "Incorrect OTP";
        var userEmail = _contextAccessor.HttpContext.Session.GetString("EMAIL");
        if (!string.IsNullOrEmpty(userEmail))
        {
            var user = _userServices.GetUserAsync(userEmail).Result;
            if (user.IsVerified)
                status = "Account Already Verified";
            else if ((DateTime.Now - user.GenerateTime).TotalMinutes < 2)
            {
                if (user.OTP.Equals(otp))
                {
                    Console.WriteLine(_emailServices.SendEmailAsync(_contextAccessor.HttpContext.Session.GetString("EMAIL"),""));
                    await _userServices.UpdateUserAsync(user);
                    status = "Verified Successfully";
                }
            }
            else
            {
                status = "OTP Expired";
            }
        }
        return Ok(status);
    }

    //[Authorize(Roles = "organiser")]
    [HttpGet("{userId}")]
    public async Task<IActionResult> GetUserAsync(long userId)
    {
        var user = await _userServices.GetUserAsync(userId);
        if (user == null)
            throw new NotFoundException("User Not Found");
        return Ok(user);
    }

    [Authorize]
    [HttpPost("feedback")]
    public async Task<IActionResult> AddFeedbackAsync(string comment, long quizId)
    {
        await _feedbackServices.AddFeedbackAsync(comment, quizId, _loginUserId);
        return Ok("Success");
    }
}
