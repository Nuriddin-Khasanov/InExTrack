using InExTrack.Common;
using InExTrack.DTOs;
using InExTrack.Interfaces.Repositories;
using InExTrack.Interfaces.Services;
using InExTrack.Models;
using Mapster;

namespace InExTrack.Services
{
    public class CategoryService(ICategoryRepository _categoryRepository) : ICategoryService
    {
        public async Task<ApiResponse<IEnumerable<CategoryDto>>> GetCategories(CancellationToken cancellationToken)
        {
            var categories = await _categoryRepository.GetCategories(cancellationToken);
            var categoriesDto = categories.Adapt<IEnumerable<CategoryDto>>();

            return new ApiResponse<IEnumerable<CategoryDto>>(categoriesDto, "Категории успешно получены!");
        }

        public async Task<ApiResponse<CategoryDto?>> GetCategoryById(Guid id, CancellationToken cancellationToken)
        {
            if(id == Guid.Empty) return new ApiResponse<CategoryDto?>("Id не можеть быть путым!");

            var category = await _categoryRepository.GetCategoryById(id, cancellationToken);
            var categoryDto = category.Adapt<CategoryDto>();

            return new ApiResponse<CategoryDto?>(categoryDto, "Категория успешно получена!");
        }

        public async Task<ApiResponse<CategoryDto>> CreateCategory(CategoryDto categoryDto, CancellationToken cancellationToken)
        {
            Category category = categoryDto.Adapt<Category>();

            var _categoryDto = (await _categoryRepository.CreateCategory(category, cancellationToken)).Adapt<CategoryDto>();
        
            return new ApiResponse<CategoryDto>(_categoryDto, "Категория успешно создана!");
        }

        public async Task<ApiResponse<CategoryDto?>> UpdateCategory(Guid id, CategoryDto categoryDto, CancellationToken cancellationToken)
        {
            if (id == Guid.Empty) return new ApiResponse<CategoryDto?>("Id не можеть быть путым!");

            var category = (await  _categoryRepository.UpdateCategory(id, categoryDto.Adapt<Category>(), cancellationToken)).Adapt<CategoryDto>();

            return new ApiResponse<CategoryDto?>(category, "Категория успешно обновлена!");
        }

        public async Task<ApiResponse<bool>> DeleteCategory(Guid id, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.DeleteCategory(id, cancellationToken);
            if (!category) return new ApiResponse<bool>("Категория не найдена!");

            return new ApiResponse<bool>(category, "Категория успешно удалена!");
        }
        
    }
}
