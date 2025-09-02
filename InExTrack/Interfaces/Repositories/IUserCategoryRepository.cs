using InExTrack.DTOs;
using InExTrack.Models;

namespace InExTrack.Interfaces.Repositories
{
    public interface IUserCategoryRepository
    {
        Task<IEnumerable<UserCategory>> GetUserCategoriesAsync(CancellationToken cancellationToken = default);
        Task<UserCategory> GetUserCategoryByIdAsync(Guid userId, CancellationToken cancellationToken = default);
        Task<UserCategory?> HasUserCategoryAsync(Guid userId, Guid categoryId, CancellationToken cancellationToken = default);
        Task<UserCategory> AddUserCategoryAsync(UserCategory userCategoryDto, CancellationToken cancellationToken = default);
        Task<UserCategory> UpdateUserCategoryAsync(Guid id, UserCategoryDto userCategoryDto, CancellationToken cancellationToken = default);
        Task<bool> DeleteUserCategoryAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
