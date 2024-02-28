namespace QuizManagement.Core.Domain.RequestModels;

public record ParticipantRequestModel
{
    public long UserId { get; set; }
    public long QuizId { get; set; }
}