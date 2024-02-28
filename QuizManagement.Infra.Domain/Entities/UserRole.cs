namespace QuizManagement.Infra.Domain.Entities;

public class UserRole
{
    public long UserId { get; set; }
    public long RoleId { get; set; }
    public User? User { get; set; }
    public Role? Role { get; set; }
}
