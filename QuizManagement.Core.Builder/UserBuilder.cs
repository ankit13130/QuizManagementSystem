using QuizManagement.Core.Domain.RequestModels;
using QuizManagement.Infra.Domain.Entities;

namespace QuizManagement.Core.Builder;

public static class UserBuilder
{
    public static User Build(UserRequestModel userRequestModel,string passwordHash, string passwordSalt, long otp)
    {
        return new User(userRequestModel.UserName, userRequestModel.Email, passwordHash, passwordSalt, otp);
    }
}
