namespace QuizManagement.Core.Domain.ResponseModels;

public class QuestionBankResponseModel
{
    public long QuizId { get; set; }
    public string Question { get; set; }
    public string Option1 { get; set; }
    public string Option2 { get; set; }
    public string? Option3 { get; set; }
    public string? Option4 { get; set; }
    public string CorrectOption { get; set; }
}
