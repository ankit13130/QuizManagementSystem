using QuizManagement.Core.Domain.RequestModels;
using QuizManagement.Infra.Domain.Entities;

namespace QuizManagement.Core.Builder;

public static class QuestionBankBuilder
{
    public static QuestionBank Build(long quizId, QuestionBankRequestModel questionBankRequestModel, long loginUserId)
    {
        return new QuestionBank(questionBankRequestModel.Question, quizId, loginUserId);
    }
}
