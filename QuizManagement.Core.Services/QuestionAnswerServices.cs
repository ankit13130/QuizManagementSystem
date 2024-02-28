using AutoMapper;
using QuizManagement.Core.Contract;
using QuizManagement.Core.Domain.CustomExceptions;
using QuizManagement.Core.Domain.RequestModels;
using QuizManagement.Infra.Contract;
using QuizManagement.Infra.Domain.Entities;

namespace QuizManagement.Core.Services;

public class QuestionAnswerServices : IQuestionAnswerServices
{
    private readonly IQuestionAnswerRepository _questionAnswerRepository;
    private readonly IParticipantRepository _participantRepository;
    private readonly IMapper _mapper;

    public QuestionAnswerServices(IQuestionAnswerRepository questionAnswerRepository, IMapper mapper, IParticipantRepository participantRepository)
    {
        _questionAnswerRepository = questionAnswerRepository;
        _mapper = mapper;
        _participantRepository = participantRepository;
    }

    public async Task<decimal> AddQuestionAnswerAsync(long quizId, IList<QuestionAnswerRequestModel> questionAnswerRequestModel, long loginUserId)
    {
        var participantId = await _participantRepository.GetQuizAsync(quizId, loginUserId);
        if (participantId == null)
            throw new NotFoundException("Not Eligible For Quiz");
        var list = _mapper.Map<IList<QuestionAnswer>>(questionAnswerRequestModel);
        return await _questionAnswerRepository.AddQuestionAnswerAsync(quizId, list, participantId);
    }
}
