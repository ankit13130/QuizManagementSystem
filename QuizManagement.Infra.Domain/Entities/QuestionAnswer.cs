using System.ComponentModel.DataAnnotations.Schema;

namespace QuizManagement.Infra.Domain.Entities;

public class QuestionAnswer
{
    public long QuestionAnswerId { get; set; }
    public long ParticipantId { get; set; }
    [ForeignKey("QuestionBank")]
    public long QuestionId { get; set; }
    [ForeignKey("OptionBank")]
    public long SelectedAnswer {  get; set; }
    public Participant? Participant{ get; set; }
    public QuestionBank? QuestionBank { get; set; }
    public OptionBank? OptionBank { get; set; }
}