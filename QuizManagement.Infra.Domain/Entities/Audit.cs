using System.ComponentModel.DataAnnotations.Schema;

namespace QuizManagement.Infra.Domain.Entities;

public class Audit
{
    public bool IsActive { get; set; } = true;
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    [ForeignKey("CreatedUser")]
    public long? CreatedBy { get; set; }
    public User? CreatedUser { get; set; }
    public DateTime? UpdatedAt { get; set; }

    [ForeignKey("UpdatedUser")]
    public long? UpdatedBy { get; set; }
    public User? UpdatedUser { get; set; }
}