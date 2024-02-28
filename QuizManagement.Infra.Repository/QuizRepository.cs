using Microsoft.EntityFrameworkCore;
using QuizManagement.Core.Domain.ResponseModels;
using QuizManagement.Infra.Contract;
using QuizManagement.Infra.Domain;
using QuizManagement.Infra.Domain.Entities;

namespace QuizManagement.Infra.Repository;

public class QuizRepository : IQuizRepository
{
    private readonly QuizContext _quizContext;

    public QuizRepository(QuizContext quizContext)
    {
        _quizContext = quizContext;
    }

    public async Task<long> AddQuizAsync(Quiz quiz)
    {
        long roleId = await _quizContext.UserRoles.Where(x =>x.UserId == quiz.UserId && x.Role.RoleName == "administrator").Include(x=>x.Role).CountAsync();
        if (roleId == 0)
        {
            roleId = await _quizContext.Roles.Where(x => x.RoleName == "administrator").Select(x=>x.RoleId).FirstOrDefaultAsync();
            UserRole userRole = new UserRole();
            userRole.UserId = quiz.UserId;
            userRole.RoleId = roleId;
            await _quizContext.UserRoles.AddAsync(userRole);
        }

        await _quizContext.Quizzes.AddAsync(quiz);
        await _quizContext.SaveChangesAsync();
        return quiz.QuizId;
    }

    public async Task<IList<QuizAnalysisModel>> GetAnalysisAsync(long quizId, long participantId)
    {
        var list = await _quizContext.QuestionAnswers.Include(x => x.QuestionBank.OptionBank).Include(x => x.OptionBank).Where(x => x.ParticipantId==participantId && x.QuestionBank.QuizId == quizId).Select(x => new QuizAnalysisModel
        {
            Question = x.QuestionBank.Question,
            CorrectOption = x.QuestionBank.OptionBank.Option,
            SelectedOption = x.OptionBank.Option,

        }).ToListAsync();
        return list;
    }

    public async Task<IList<Quiz>> GetQuizAsync(long? quizId, long loginUserId)
    {
        List<Quiz> quizzes = null;
        if(quizId != null)
            quizzes = await _quizContext.Quizzes.Where(x => x.QuizId == quizId && x.UserId == loginUserId).ToListAsync();
        else
            quizzes = await _quizContext.Quizzes.Where(x => x.UserId == loginUserId).ToListAsync();   
        return quizzes;
    }
    public async Task<IList<Quiz>> GetQuizzesAsync()
    {
        return await _quizContext.Quizzes.ToListAsync();
    }
}
