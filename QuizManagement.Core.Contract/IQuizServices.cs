using QuizManagement.Core.Domain.ResponseModels;

namespace QuizManagement.Core.Contract;

public interface IQuizServices
{
    public Task<long> AddQuizAsync(string quizName,int totalQuestion, long loginUserId);
    public Task<IList<QuizResponseModel>> GetQuizAsync(long? quizId, long loginUserId);
    public Task<IList<QuizResponseModel>> GetQuizzesAsync();
    public Task<IList<QuizAnalysisModel>> GetAnalysisAsync(long quizId, long loginUserId);
}
