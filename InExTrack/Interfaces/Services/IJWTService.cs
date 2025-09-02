using InExTrack.Models;

namespace InExTrack.Interfaces.Services
{
    public interface IJWTService
    {
        string GenerateToken(User user);
    }
}
