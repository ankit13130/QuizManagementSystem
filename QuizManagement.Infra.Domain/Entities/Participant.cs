using System.ComponentModel.DataAnnotations;

namespace QuizManagement.Infra.Domain.Entities;

public class Participant
{
    [Key]
    public long ParticipantId { get; set; }
    public decimal? Score { get; set; }

    public long UserId { get; set; }
    public long QuizId { get; set; }
    public User? User { get; set; }
    public Quiz? Quiz { get; set; }
}
