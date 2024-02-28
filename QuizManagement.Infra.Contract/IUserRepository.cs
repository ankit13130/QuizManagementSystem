using QuizManagement.Infra.Domain.Entities;

namespace QuizManagement.Infra.Contract;

public interface IUserRepository
{
    public Task AddUserAsync(User user);
    public Task UpdateUserAsync(User user);
    public Task<User> GetUserAsync(long userId);
    public Task<User> GetUserAsync(string email);
    public Task<IList<User>> GetUsersAsync();
}
