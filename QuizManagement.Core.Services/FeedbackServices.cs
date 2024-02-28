using QuizManagement.Core.Contract;
using QuizManagement.Infra.Contract;
using QuizManagement.Infra.Domain.Entities;

namespace QuizManagement.Core.Services;

public class FeedbackServices : IFeedbackServices
{
    private readonly IFeedbackRepository _feedbackRepository;
    public FeedbackServices(IFeedbackRepository feedbackRepository)
    {
        _feedbackRepository = feedbackRepository;
    }

    public async Task AddFeedbackAsync(string comment, long quizId, long loginUserId)
    {
       await _feedbackRepository.AddFeedbackAsync(new Feedback { Comment = comment, QuizId = quizId, ParticipantId = loginUserId});
    }
}
