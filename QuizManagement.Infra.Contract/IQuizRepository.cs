using QuizManagement.Core.Domain.ResponseModels;
using QuizManagement.Infra.Domain.Entities;

namespace QuizManagement.Infra.Contract;

public interface IQuizRepository
{
    public Task<long> AddQuizAsync(Quiz quiz);
    public Task<IList<Quiz>> GetQuizAsync(long? quizId, long loginUserId);
    public Task<IList<Quiz>> GetQuizzesAsync();
    public Task<IList<QuizAnalysisModel>> GetAnalysisAsync(long quizId, long participantId);
}
