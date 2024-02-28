using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuizManagement.Infra.Domain.Entities;

public class QuestionBank : Audit
{
    [Key]
    public long QuestionId { get; set; }
    public string Question { get; set; }
    [ForeignKey("OptionBank")]
    public long? CorrectOption { get; set; }
    public long QuizId { get; set; }
    public Quiz? Quiz { get; set; }
    public OptionBank? OptionBank { get; set; }
    public IList<QuestionAnswer> QuestionAnswers { get; set; }
    protected QuestionBank() { }
    public QuestionBank(string question, long quizId, long loginUserId)
    {
        Question = question;
        QuizId = quizId;
        CreatedBy = loginUserId;
    }
}
