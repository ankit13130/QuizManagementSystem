using Microsoft.Extensions.Configuration;
using QuizManagement.Core.Contract;
using QuizManagement.Core.Domain.Helper;

namespace QuizManagement.Core.Services;

public class EmailServices : IEmailServices
{
    private readonly IConfiguration _configuration;

    public EmailServices(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string SendEmailAsync(string to, string? otp)
    {
        EmailSender emailSender = new EmailSender();

        if (!string.IsNullOrEmpty(otp))
            return emailSender.sendOtpMail(to, otp, _configuration["EmailConfig:Email"], _configuration["EmailConfig:Password"], _configuration["EmailConfig:Smtp"], Convert.ToInt32(_configuration["EmailConfig:Port"]));
        else
            return emailSender.sendCongratulationMail(to, _configuration["EmailConfig:Email"], _configuration["EmailConfig:Password"], _configuration["EmailConfig:Smtp"], Convert.ToInt32(_configuration["EmailConfig:Port"]));
    }
}
