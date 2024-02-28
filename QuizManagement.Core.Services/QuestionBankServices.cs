using QuizManagement.Core.Builder;
using QuizManagement.Core.Contract;
using QuizManagement.Core.Domain.RequestModels;
using QuizManagement.Infra.Contract;

namespace QuizManagement.Core.Services;

public class QuestionBankServices : IQuestionBankServices
{
    private readonly IQuestionBankRepository _questionBankRepository;
    public QuestionBankServices(IQuestionBankRepository questionBankRepository)
    {
        _questionBankRepository = questionBankRepository;
    }

    public async Task<long> AddQuestionBankAsync(long quizId, QuestionBankRequestModel questionBankRequestModel, long loginUserId)
    {
        var questionBank = QuestionBankBuilder.Build(quizId, questionBankRequestModel, loginUserId);
        return await _questionBankRepository.AddQuestionBankAsync(questionBank);
    }

    public async Task UpdateQuestionBankAsync(string correctOption, long questionId)
    {
        await _questionBankRepository.UpdataQuestionBankAsync(await _questionBankRepository.GetQuestionBankAsync(questionId), correctOption);
    }
}
