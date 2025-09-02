using InExTrack.DataContext;
using InExTrack.DTOs;
using InExTrack.Interfaces.Repositories;
using InExTrack.Models;
using Microsoft.EntityFrameworkCore;

namespace InExTrack.Repositories
{
    public class UserCategoryRepository(AppDBContext _cantext) : IUserCategoryRepository
    {

        public async Task<IEnumerable<UserCategory>> GetUserCategoriesAsync(CancellationToken cancellationToken = default)
        {
            var userCategories = await _cantext.UserCategories.Where(uc => uc.IsActive).ToListAsync(cancellationToken);

            return userCategories;
        }

        public async Task<UserCategory> GetUserCategoryByIdAsync(Guid userId, CancellationToken cancellationToken = default)
        {
            var userCategory = await _cantext.UserCategories.FirstOrDefaultAsync(uc => uc.Id == userId, cancellationToken);

            return userCategory ?? throw new InvalidOperationException($"UserCategory с UserId '{userId}' не найден.");
        }



        public async Task<UserCategory> AddUserCategoryAsync(UserCategory userCategoryDto, CancellationToken cancellationToken = default)
        {
            await  _cantext.UserCategories.AddAsync(userCategoryDto, cancellationToken);
            await  _cantext.SaveChangesAsync(cancellationToken);

            return userCategoryDto;
        }

        public async Task<UserCategory> UpdateUserCategoryAsync(Guid id, UserCategoryDto userCategoryDto, CancellationToken cancellationToken = default)
        {
            var existingUserCategory = await _cantext.UserCategories.Where(uc => uc.IsActive).FirstOrDefaultAsync(uc => uc.Id == id, cancellationToken);
            if (existingUserCategory == null)
                throw new InvalidOperationException($"UserCategory with ID '{id}' not found.");
        
            existingUserCategory.UserId = userCategoryDto.UserId;
            existingUserCategory.CategoryId = userCategoryDto.CategoryId;
            _cantext.UserCategories.Update(existingUserCategory);
            await _cantext.SaveChangesAsync(cancellationToken);

            return existingUserCategory;
        }

        public async Task<bool> DeleteUserCategoryAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var userCategory = await _cantext.UserCategories.Where(uc => uc.IsActive).FirstOrDefaultAsync(uc => uc.Id == id, cancellationToken);
            if (userCategory != null)
            {
                userCategory.IsActive = false;
                var result = await _cantext.SaveChangesAsync(cancellationToken) > 0;

                return result;
            }

            throw new InvalidOperationException($"UserCategory with ID '{id}' not found.");
        }

        public async Task<UserCategory?> HasUserCategoryAsync(Guid userId, Guid categoryId, CancellationToken cancellationToken = default)
        {
            var result = await _cantext.UserCategories.FirstOrDefaultAsync(uc => uc.UserId == userId && uc.CategoryId == categoryId, cancellationToken);
        
            if(result == null)
                return null;
            if (!result.IsActive)
            {
                result.IsActive = true;
                await _cantext.SaveChangesAsync(cancellationToken);
            }

            return result;
        }
    }
}
