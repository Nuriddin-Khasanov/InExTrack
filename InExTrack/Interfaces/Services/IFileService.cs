using InExTrack.DTOs;

namespace InExTrack.Interfaces.Services
{
    public interface IFileService
    {
        Task RemoveAsync(string fileName);
        Task<FileDto> SaveAsync(IFormFile file);
    }
}
