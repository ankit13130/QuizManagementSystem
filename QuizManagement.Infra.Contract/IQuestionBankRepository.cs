using QuizManagement.Infra.Domain.Entities;

namespace QuizManagement.Infra.Contract;

public interface IQuestionBankRepository
{
    public Task<long> AddQuestionBankAsync(QuestionBank questionBank);
    public Task UpdataQuestionBankAsync(QuestionBank questionBank, string correctOption);
    public Task<QuestionBank> GetQuestionBankAsync(long questionId);
    //public Task<IList<QuestionBank>> GetQuestionBankzesAsync();
}
