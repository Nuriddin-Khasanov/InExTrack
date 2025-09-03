using InExTrack.Models;

namespace InExTrack.Interfaces.Repositories
{
    public interface IAuthRepository
    {
        Task<User?> GetByUsernameAsync(string username);
        Task AddAsync(User user);
        Task<bool> ExistsAsync(string username);

    }
}
