namespace QuizManagement.Core.Domain.RequestModels;

public record LoginRequestModel
{
    public string Email { get; set; }
    public string Password { get; set; }
}
