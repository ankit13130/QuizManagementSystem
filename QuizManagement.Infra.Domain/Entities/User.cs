namespace QuizManagement.Infra.Domain.Entities;

public class User : Audit
{
    public long UserId { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public string PasswordSalt { get; set; }
    public IList<UserRole> UserRoles { get; set; }
    public bool IsVerified { get; set; }
    public DateTime GenerateTime { get; set; }
    public long OTP {  get; set; }
    protected User() { }
    public User(string userName, string email, string passwordHash, string passwordSalt, long oTP)
    {
        UserName = userName;
        Email = email;
        PasswordHash = passwordHash;
        PasswordSalt = passwordSalt;
        OTP = oTP;
    }
}