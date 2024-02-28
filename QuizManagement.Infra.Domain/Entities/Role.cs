namespace QuizManagement.Infra.Domain.Entities;

public class Role
{
    public long RoleId { get; set; }
    public string RoleName { get; set; }
    public IList<UserRole> UserRoles { get; set; }
}
