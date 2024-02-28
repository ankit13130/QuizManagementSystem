using QuizManagement.Infra.Domain.Entities;

namespace QuizManagement.Infra.Contract;

public interface IQuestionAnswerRepository
{
    Task<decimal> AddQuestionAnswerAsync(long quizId, IList<QuestionAnswer> questionAnswer,long loginUserId);
}
