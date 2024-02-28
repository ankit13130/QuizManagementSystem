using QuizManagement.Core.Domain.RequestModels;
using QuizManagement.Core.Domain.ResponseModels;

namespace QuizManagement.Core.Contract;

public interface IParticipantServices
{
    public Task AddParticipantAsync(ParticipantRequestModel participantRequestModel);
    public Task<IList<UserResponseModel>> GetAllParticipantByQuizAsync(long quizId);
    public Task<IList<QuizResponseModel>> GetAllQuizByLoginIdAsync(long loginUserId);
}
