using Microsoft.EntityFrameworkCore;
using QuizManagement.Core.Domain.CustomExceptions;
using QuizManagement.Infra.Contract;
using QuizManagement.Infra.Domain;
using QuizManagement.Infra.Domain.Entities;

namespace QuizManagement.Infra.Repository;

public class FeedbackRepository : IFeedbackRepository
{
    private readonly QuizContext _quizContext;
    public FeedbackRepository(QuizContext quizContext)
    {
        _quizContext = quizContext;
    }

    public async Task AddFeedbackAsync(Feedback feedback) 
    { 
        if (!await _quizContext.Quizzes.AnyAsync(x=>x.QuizId == feedback.QuizId && x.UserId == feedback.ParticipantId))
        {
            throw new BadRequestException("Wrong Feedback");
        }
        await _quizContext.AddAsync(feedback);
        await _quizContext.SaveChangesAsync();
    }
}
