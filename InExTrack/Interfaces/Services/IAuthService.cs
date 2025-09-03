namespace InExTrack.Interfaces.Services
{
    public interface IAuthService
    {
        Task<string?> AuthenticateAsync(string username, string password);
        Task<bool> RegisterUserAsync(string username, string password);
    }
}
