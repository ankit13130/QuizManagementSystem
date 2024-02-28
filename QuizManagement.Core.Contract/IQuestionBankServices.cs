using QuizManagement.Core.Domain.RequestModels;

namespace QuizManagement.Core.Contract;

public interface IQuestionBankServices
{
    public Task<long> AddQuestionBankAsync(long quizId,QuestionBankRequestModel questionBankRequestModel, long loginUserId);
    public Task UpdateQuestionBankAsync(string correctOption, long questionId);
}
