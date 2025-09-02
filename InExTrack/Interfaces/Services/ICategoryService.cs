using InExTrack.Common;
using InExTrack.DTOs;
using InExTrack.Models;

namespace InExTrack.Interfaces.Services
{
    public interface ICategoryService
    {
        public Task<ApiResponse<IEnumerable<CategoryDto>>> GetCategories(CancellationToken cancellationToken);
        public Task<ApiResponse<CategoryDto?>> GetCategoryById(Guid id, CancellationToken cancellationToken);
        public Task<ApiResponse<CategoryDto>> CreateCategory(CategoryDto categoryDto, CancellationToken cancellationToken);
        public Task<ApiResponse<CategoryDto?>> UpdateCategory(Guid id, CategoryDto categoryDto, CancellationToken cancellationToken);
        public Task<ApiResponse<bool>> DeleteCategory(Guid id, CancellationToken cancellationToken);
    }
}
