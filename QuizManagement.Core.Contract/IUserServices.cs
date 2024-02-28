using QuizManagement.Core.Domain.RequestModels;
using QuizManagement.Core.Domain.ResponseModels;
using QuizManagement.Infra.Domain.Entities;

namespace QuizManagement.Core.Contract;

public interface IUserServices
{
    Task<string> LoginAsync(LoginRequestModel loginRequestModel);
    Task SignupAsync(UserRequestModel loginRequestModel);
    Task<UserResponseModel> GetUserAsync(long userId);
    Task<User> GetUserAsync(string userEmail);
    Task UpdateUserAsync(User user);
}
