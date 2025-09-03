using InExTrack.DataContext;
using InExTrack.Interfaces.Repositories;
using InExTrack.Models;
using Microsoft.EntityFrameworkCore;

namespace InExTrack.Repositories
{
    public class AuthRepository(AppDBContext _context) : IAuthRepository
    {

        public async Task<User?> GetByUsernameAsync(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.UserName == username);
        }
        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistsAsync(string username)
        {
            return await _context.Users.AnyAsync(u => u.UserName == username);
        }
    }
}
