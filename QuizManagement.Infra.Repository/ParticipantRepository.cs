using Microsoft.EntityFrameworkCore;
using QuizManagement.Infra.Contract;
using QuizManagement.Infra.Domain;
using QuizManagement.Infra.Domain.Entities;

namespace QuizManagement.Infra.Repository;

public class ParticipantRepository : IParticipantRepository
{
    private readonly QuizContext _quizContext;

    public ParticipantRepository(QuizContext quizContext)
    {
        _quizContext = quizContext;
    }

    public async Task AddParticipantAsync(Participant participant)
    {
        await _quizContext.Participants.AddAsync(participant);
        await _quizContext.SaveChangesAsync();
    }
    public async Task<IList<User>> GetAllParticipantByQuizAsync(long quizId)
    {
        var list = await _quizContext.Participants.Where(x => x.QuizId == quizId).Select(x=>x.UserId).ToListAsync();
        var asa = await _quizContext.Users.Where(x => list.Contains(x.UserId)).ToListAsync();
        return asa;
    }

    public async Task<IList<Quiz>> GetAllQuizByLoginIdAsync(long loginUserId)
    {
        var data = await _quizContext.Participants.Where(x=>x.UserId == loginUserId).Select(x=>x.QuizId).ToListAsync();
        var quizList = await _quizContext.Quizzes.Where(x => data.Contains(x.QuizId)).ToListAsync();
        return quizList;
    }

    public async Task<long> GetQuizAsync(long quizId, long loginUserId)
    {
        return await _quizContext.Participants.Where(x => x.QuizId == quizId && x.UserId == loginUserId).Select(x=>x.ParticipantId).FirstOrDefaultAsync();
    }
}
