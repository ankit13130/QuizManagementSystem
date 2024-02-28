using Microsoft.EntityFrameworkCore;
using QuizManagement.Infra.Contract;
using QuizManagement.Infra.Domain;
using QuizManagement.Infra.Domain.Entities;

namespace QuizManagement.Infra.Repository;

public class UserRepository : IUserRepository
{
    private readonly QuizContext _quizContext;

    public UserRepository(QuizContext quizContext)
    {
        _quizContext = quizContext;
    }

    public async Task AddUserAsync(User user)
    {
        user.CreatedAt = DateTime.Now;
        user.GenerateTime = DateTime.Now;
        user.IsVerified = false;
        await _quizContext.Users.AddAsync(user);
        await _quizContext.SaveChangesAsync();
        user.CreatedBy = user.UserId;
        _quizContext.Update(user);

        var roleId = await _quizContext.Roles.Where(x => x.RoleName == "user").Select(x=>x.RoleId).FirstOrDefaultAsync();
        await _quizContext.UserRoles.AddAsync(new UserRole() { UserId = user.UserId, RoleId = roleId});
        await _quizContext.SaveChangesAsync();
    }
    public async Task UpdateUserAsync(User user)
    {
        user.UpdatedAt = DateTime.Now;
        user.UpdatedBy = user.UserId;
        user.IsVerified = true;
        _quizContext.Update(user);
        await _quizContext.SaveChangesAsync();
    }
    public async Task<User> GetUserAsync(long userId)
    {
        return await _quizContext.Users.Where(x => x.UserId == userId && x.IsActive).FirstOrDefaultAsync();
    }
    public async Task<User> GetUserAsync(string email)
    {
        return await _quizContext.Users.Where(x => x.Email == email && x.IsActive).Include(x=>x.UserRoles).ThenInclude(x=>x.Role).FirstOrDefaultAsync();
    }
    public async Task<IList<User>> GetUsersAsync()
    {
        return await _quizContext.Users.ToListAsync();
    }
}
