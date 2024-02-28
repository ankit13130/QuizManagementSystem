namespace QuizManagement.Infra.Domain.Entities;

public class Feedback
{
    public long FeedbackId { get; set; }
    public string Comment { get; set;}
    public long ParticipantId { get; set; }
    public long QuizId { get; set; }
    public Participant? Participant { get; set; }
    public Quiz? Quiz { get; set; }
}
