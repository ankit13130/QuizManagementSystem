using Microsoft.EntityFrameworkCore;
using QuizManagement.Infra.Contract;
using QuizManagement.Infra.Domain;
using QuizManagement.Infra.Domain.Entities;

namespace QuizManagement.Infra.Repository;

public class QuestionBankRepository : IQuestionBankRepository
{
    private readonly QuizContext _quizContext;

    public QuestionBankRepository(QuizContext quizContext)
    {
        _quizContext = quizContext;
    }

    public async Task<long> AddQuestionBankAsync(QuestionBank questionBank)
    {
        await _quizContext.QuestionBanks.AddAsync(questionBank);
        await _quizContext.SaveChangesAsync();
        return questionBank.QuestionId;
    }

    public async Task<QuestionBank> GetQuestionBankAsync(long questionId)
    {
        return await _quizContext.QuestionBanks.Where(x=>x.QuestionId == questionId).FirstOrDefaultAsync();
    }

    public async Task UpdataQuestionBankAsync(QuestionBank questionBank, string correctOption)
    {
        questionBank.CorrectOption = await _quizContext.OptionBanks.Where(x => x.Option == correctOption && x.QuestionId == questionBank.QuestionId).Select(x=>x.OptionId).FirstOrDefaultAsync();
        _quizContext.Update(questionBank);
        await _quizContext.SaveChangesAsync();
    }
}
