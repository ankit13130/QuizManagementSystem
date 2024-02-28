using Microsoft.EntityFrameworkCore;
using QuizManagement.Infra.Contract;
using QuizManagement.Infra.Domain;
using QuizManagement.Infra.Domain.Entities;

namespace QuizManagement.Infra.Repository;

public class QuestionAnswerRepository : IQuestionAnswerRepository
{
    private readonly QuizContext _quizContext;

    public QuestionAnswerRepository(QuizContext quizContext)
    {
        _quizContext = quizContext;
    }

    public async Task<decimal> AddQuestionAnswerAsync(long quizId, IList<QuestionAnswer> questionAnswer, long participantId)
    {
        foreach (var item in questionAnswer)
        {
            item.ParticipantId = participantId;   
        }
        await _quizContext.AddRangeAsync(questionAnswer);
        await _quizContext.SaveChangesAsync();
        var list = questionAnswer.Join(_quizContext.QuestionBanks,
                                    qa => qa.QuestionId,
                                    qb => qb.QuestionId,
                                    (qa, qb) => new
                                    {
                                        ParticioantId = qa.ParticipantId,
                                        SelectedAnswer = qa.SelectedAnswer,
                                        CorrectOption = qb.CorrectOption,
                                    }).Where(x=>x.ParticioantId == participantId && x.SelectedAnswer == x.CorrectOption).Count();

        var result = (decimal)list/_quizContext.QuestionBanks.Count(x=>x.QuizId == quizId)*100;
        var userQuizData = await _quizContext.Participants.Where(x => x.ParticipantId == participantId).FirstOrDefaultAsync();
        userQuizData.Score = result;
        _quizContext.Participants.Update(userQuizData);
        await _quizContext.SaveChangesAsync();
        return result;
    }
}
