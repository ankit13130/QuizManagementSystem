using AutoMapper;
using QuizManagement.Core.Builder;
using QuizManagement.Core.Contract;
using QuizManagement.Core.Domain.ResponseModels;
using QuizManagement.Infra.Contract;

namespace QuizManagement.Core.Services;

public class QuizServices : IQuizServices
{
    private readonly IQuizRepository _quizRepository;
    private readonly IParticipantRepository _participantRepository;
    private readonly IMapper _mapper;

    public QuizServices(IQuizRepository quizRepository, IMapper mapper, IParticipantRepository participantRepository)
    {
        _quizRepository = quizRepository;
        _mapper = mapper;
        _participantRepository = participantRepository;
    }
    public async Task<long> AddQuizAsync(string quizName,int totalQuestion, long loginUserId)
    {
        var quiz = QuizBuilder.Build(quizName, totalQuestion, loginUserId);      
        return await _quizRepository.AddQuizAsync(quiz);
    }

    public async Task<IList<QuizAnalysisModel>> GetAnalysisAsync(long quizId, long loginUserId)
    {
        long participantId = await _participantRepository.GetQuizAsync(quizId, loginUserId);
        return await _quizRepository.GetAnalysisAsync(quizId, participantId);
    }

    public async Task<IList<QuizResponseModel>> GetQuizAsync(long? quizId, long loginUserId)
    {
        var quizList = await _quizRepository.GetQuizAsync(quizId, loginUserId);
        return quizList == null ? throw new Exception("No quizzes Conducted") : _mapper.Map<IList<QuizResponseModel>>(quizList);
    }
    public async Task<IList<QuizResponseModel>> GetQuizzesAsync()
    {
        return _mapper.Map<IList<QuizResponseModel>>(await _quizRepository.GetQuizzesAsync());
    }
}
