using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuizManagement.Infra.Domain.Entities;

public class OptionBank
{
    [Key]
    public long OptionId { get; set; }
    public string Option { get; set; }
    [ForeignKey("QuestionBank")]
    public long QuestionId { get; set; }
    public QuestionBank? QuestionBank { get; set; }
    protected OptionBank() { }
    public OptionBank(string option, long questionId)
    {
        Option = option;
        QuestionId = questionId;
    }
}
