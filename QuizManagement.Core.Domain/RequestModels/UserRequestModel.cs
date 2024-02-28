namespace QuizManagement.Core.Domain.RequestModels;

public record UserRequestModel
{
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}
