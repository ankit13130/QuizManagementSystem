using QuizManagement.Infra.Domain.Entities;

namespace QuizManagement.Infra.Contract;

public interface IFeedbackRepository
{
    Task AddFeedbackAsync(Feedback feedback);
}
