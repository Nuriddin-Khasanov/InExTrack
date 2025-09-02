using InExTrack.DataContext;
using InExTrack.DTOs.Requests;
using InExTrack.Interfaces.Repositories;
using InExTrack.Models;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace InExTrack.Repositories;

public class UserRepository(AppDBContext _context) : IUserRepository
{

    public async Task<List<User>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Users.ToListAsync(cancellationToken);
    }

    public async Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var newUser = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);

        return newUser;
    }

    public async Task<User> AddAsync(User user, CancellationToken cancellationToken = default)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync(cancellationToken);

        return user;
    }

    public async Task<User?> UpdateAsync(Guid userId, UserRequestsDto userRequestsDto, CancellationToken cancellationToken = default)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId, cancellationToken);
        if (user == null)
        {
            return null; 
        }

        userRequestsDto.Adapt(user);

        await _context.SaveChangesAsync(cancellationToken);

        return user;
    }


    public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var user = _context.Users.FirstOrDefault(u => u.Id == id);
        if (user == null)
            return false;

        _context.Users.Remove(user);
        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }
}