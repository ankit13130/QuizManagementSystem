using QuizManagement.Infra.Domain.Entities;

namespace QuizManagement.Infra.Contract;

public interface IParticipantRepository
{
    public Task AddParticipantAsync(Participant participant);
    public Task<IList<User>> GetAllParticipantByQuizAsync(long quizId);
    public Task<IList<Quiz>> GetAllQuizByLoginIdAsync(long loginUserId);
    public Task<long> GetQuizAsync(long quizId, long loginUserId);
}