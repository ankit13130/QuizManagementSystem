namespace QuizManagement.Core.Domain.ResponseModels;

public record UserResponseModel
{
    public long UserId { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public DateTime CreateTime { get; set; }
}
