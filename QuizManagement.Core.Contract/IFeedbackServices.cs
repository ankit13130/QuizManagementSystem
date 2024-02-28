namespace QuizManagement.Core.Contract;

public interface IFeedbackServices
{
    Task AddFeedbackAsync(string comment, long quizId, long loginUserId);
}
