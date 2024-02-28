namespace QuizManagement.Core.Contract;

public interface IEmailServices
{
    string SendEmailAsync(string to, string? otp);
}
