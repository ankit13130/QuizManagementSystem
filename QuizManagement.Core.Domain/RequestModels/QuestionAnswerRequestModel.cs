namespace QuizManagement.Core.Domain.RequestModels;

public class QuestionAnswerRequestModel
{
    public long QuestionId { get; set; }
    public long SelectedAnswer { get; set; }
}
