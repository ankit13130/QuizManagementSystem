namespace QuizManagement.Core.Domain.ResponseModels;

public record ParticipantResponseModel
{
    public long QuizId { get; set; }
    public List<UserResponseModel> participants { get; set; }
}
