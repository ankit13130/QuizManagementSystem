using Microsoft.EntityFrameworkCore;
using QuizManagement.Infra.Domain.Entities;

namespace QuizManagement.Infra.Domain;

public class QuizContext : DbContext
{
    public QuizContext(DbContextOptions<QuizContext> opt) : base(opt) { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserRole>()
                    .HasNoKey();

        modelBuilder.Entity<UserRole>()
                        .HasKey(ur => new { ur.UserId, ur.RoleId });
        modelBuilder.Entity<UserRole>()
                    .HasOne(u => u.User)
                    .WithMany(ur => ur.UserRoles)
                    .HasForeignKey(u => u.UserId);
        modelBuilder.Entity<UserRole>()
                    .HasOne(r => r.Role)
                    .WithMany(ur => ur.UserRoles)
                    .HasForeignKey(r => r.RoleId);                    
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Quiz> Quizzes { get; set; }
    public DbSet<QuestionBank> QuestionBanks { get; set; }
    public DbSet<OptionBank> OptionBanks { get; set; }
    public DbSet<Participant> Participants { get; set; }
    public DbSet<QuestionAnswer> QuestionAnswers { get; set; }
    public DbSet<Feedback> Feedbacks { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }
}
