using InExTrack.Common;
using InExTrack.DTOs;
using InExTrack.Interfaces.Repositories;
using InExTrack.Interfaces.Services;
using InExTrack.Models;
using Mapster;

namespace InExTrack.Services
{
    public class UserCategoryService(IUserCategoryRepository _userCategoryRepository) : IUserCategoryService
    {

        public async Task<ApiResponse<IEnumerable<UserCategoryDto>>> GetUserCategoriesAsync(CancellationToken cancellationToken = default)
        {
            var userCategories = await _userCategoryRepository.GetUserCategoriesAsync(cancellationToken);
            var userCategoriesDto = userCategories.Adapt<IEnumerable<UserCategoryDto>>();

            return new ApiResponse<IEnumerable<UserCategoryDto>>(userCategoriesDto, "UserCategories успешно получены!");
        }

        public async Task<ApiResponse<UserCategoryDto>> GetUserCategoryByIdAsync(Guid userId, CancellationToken cancellationToken = default)
        {
            if(userId == Guid.Empty)
                throw new ArgumentException("User ID cannot be empty.", nameof(userId));

            var userCategory = await  _userCategoryRepository.GetUserCategoryByIdAsync(userId, cancellationToken);
            var userCategoryDto = userCategory.Adapt<UserCategoryDto>();

            return new ApiResponse<UserCategoryDto>(userCategoryDto, "UserCategory успешно получен!");
        }

        public async Task<ApiResponse<UserCategoryDto>> AddUserCategoryAsync(UserCategoryDto userCategoryDto, CancellationToken cancellationToken = default)
        {
            if(userCategoryDto.CategoryId == Guid.Empty)
                return new ApiResponse<UserCategoryDto>("Category Id не можеть быть пустым!");
            if (userCategoryDto.UserId == Guid.Empty)
                return new ApiResponse<UserCategoryDto>("User Id не можеть быть пустым!");

            var existingUserCategory = await _userCategoryRepository.HasUserCategoryAsync(userCategoryDto.UserId, userCategoryDto.CategoryId, cancellationToken);
            if (existingUserCategory != null)
            {
                var UCD = existingUserCategory.Adapt<UserCategoryDto>();
                return new ApiResponse<UserCategoryDto>(UCD, "UserCategory ещё добавлен!");
            }

            var userCategory = userCategoryDto.Adapt<UserCategory>();
            var createdUserCategory = await  _userCategoryRepository.AddUserCategoryAsync(userCategory, cancellationToken);
            var createdUserCategoryDto = createdUserCategory.Adapt<UserCategoryDto>();

            return new ApiResponse<UserCategoryDto>(createdUserCategoryDto, "UserCategory успешно добавлен!");
        }

        public async Task<ApiResponse<UserCategoryDto>> UpdateUserCategoryAsync(Guid id, UserCategoryDto userCategoryDto, CancellationToken cancellationToken = default)
        {
            if(id == Guid.Empty)
                return new ApiResponse<UserCategoryDto>("Id не можеть быть пустым!");

            var userCategory = await _userCategoryRepository.UpdateUserCategoryAsync(id, userCategoryDto, cancellationToken);
            var updatedUserCategoryDto = userCategory.Adapt<UserCategoryDto>();

            return new ApiResponse<UserCategoryDto>(updatedUserCategoryDto, "UserCategory успешно обновлен!");
        }

        public async Task<ApiResponse<bool>> DeleteUserCategoryAsync(Guid id, CancellationToken cancellationToken = default)
        {
            if(id == Guid.Empty)
                return new ApiResponse<bool>("Id не можеть быть пустым!");

            var result = await _userCategoryRepository.DeleteUserCategoryAsync(id, cancellationToken);
            if(result)
            {
                return new ApiResponse<bool>("UserCategory не найден или уже удален.");
            }

            return new ApiResponse<bool>(true, "UserCategory успешно удален!");
        }
    }
}
