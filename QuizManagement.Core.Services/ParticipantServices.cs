using AutoMapper;
using QuizManagement.Core.Contract;
using QuizManagement.Core.Domain.CustomExceptions;
using QuizManagement.Core.Domain.RequestModels;
using QuizManagement.Core.Domain.ResponseModels;
using QuizManagement.Infra.Contract;
using QuizManagement.Infra.Domain.Entities;

namespace QuizManagement.Core.Services;

public class ParticipantServices : IParticipantServices
{
    private readonly IParticipantRepository _participantRepository;
    private readonly IMapper _mapper;

    public ParticipantServices(IParticipantRepository participantRepository, IMapper mapper)
    {
        _participantRepository = participantRepository;
        _mapper = mapper;
    }

    public async Task AddParticipantAsync(ParticipantRequestModel participantRequestModel)
    {
        await _participantRepository.AddParticipantAsync(_mapper.Map<Participant>(participantRequestModel));
    }

    public async Task<IList<UserResponseModel>> GetAllParticipantByQuizAsync(long quizId)
    {
        //var list = await _participantRepository.GetAllParticipantByQuizAsync(quizId);
        return _mapper.Map<IList<UserResponseModel>>(await _participantRepository.GetAllParticipantByQuizAsync(quizId));
    }

    public async Task<IList<QuizResponseModel>> GetAllQuizByLoginIdAsync(long loginUserId)
    {
        var quizList = await _participantRepository.GetAllQuizByLoginIdAsync(loginUserId);
        return quizList == null ? throw new NotFoundException("No quizzes Scheduled") : _mapper.Map<IList<QuizResponseModel>>(quizList);
    }
}
