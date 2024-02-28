namespace QuizManagement.Core.Domain.ResponseModels;

public record QuizResponseModel
{
    public long QuizId { get; set; }
    public string QuizName { get; set; }
}
