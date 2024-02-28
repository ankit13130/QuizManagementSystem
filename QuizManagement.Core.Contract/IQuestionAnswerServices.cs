using QuizManagement.Core.Domain.RequestModels;

namespace QuizManagement.Core.Contract;

public interface IQuestionAnswerServices
{
    Task<decimal> AddQuestionAnswerAsync(long quizId, IList<QuestionAnswerRequestModel> questionAnswerRequestModel, long loginUserId);
}
