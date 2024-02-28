namespace QuizManagement.Core.Domain.ResponseModels;

public record QuizAnalysisModel
{
    public string Question { get; set; }
    public string SelectedOption { get; set;}
    public string CorrectOption { get; set;}
}
