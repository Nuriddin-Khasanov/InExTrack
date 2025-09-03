using InExTrack.Enums;
using InExTrack.Interfaces.Repositories;
using InExTrack.Interfaces.Services;
using InExTrack.Models;

namespace InExTrack.Services
{
    public class AuthService(IAuthRepository _authRepository, IJWTService _jwtService) : IAuthService
    {
        public async Task<string?> AuthenticateAsync(string username, string password)
        {
            var user = await _authRepository.GetByUsernameAsync(username);
            if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
                return null;

            return _jwtService.GenerateToken(user);
        }

        public async Task<bool> RegisterUserAsync(string username, string password)
        {
            if(await _authRepository.ExistsAsync(username)) 
                return false;

            var user = new User
            {
                UserName = username,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(password),
                Role = RoleEnum.User
            };

            await _authRepository.AddAsync(user);
            return true;
        }

    }
}
