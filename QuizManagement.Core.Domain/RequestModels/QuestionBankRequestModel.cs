namespace QuizManagement.Core.Domain.RequestModels;

public record QuestionBankRequestModel
{
    //public long QuizId { get; set; }
    public string Question { get; set; }
    public string CorrectOption { get; set; }
    public IList<string> Option { get; set; }
}
