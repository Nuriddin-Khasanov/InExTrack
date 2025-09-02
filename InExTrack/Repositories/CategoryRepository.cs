using InExTrack.DataContext;
using InExTrack.Interfaces.Repositories;
using InExTrack.Models;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace InExTrack.Repositories
{
    public class CategoryRepository(AppDBContext _context) : ICategoryRepository
    {

        public async Task<List<Category>> GetCategories(CancellationToken cancellationToken = default)
        {
            return await _context.Categories.ToListAsync(cancellationToken);
        }

        public async Task<Category?> GetCategoryById(Guid id, CancellationToken cancellationToken = default)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id, cancellationToken);

            return category;
        }

        public async Task<Category> CreateCategory(Category category, CancellationToken cancellationToken = default)
        {
            await _context.Categories.AddAsync(category, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return category;
        }

        public async Task<Category?> UpdateCategory(Guid id, Category updatedCategory, CancellationToken cancellationToken = default)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id, cancellationToken);

            if (category == null)
                return null;

            updatedCategory.Adapt(category);
            category.Id = id; // явно сохраняем Id, если нужно

            //category.Name = updatedCategory.Name;
            //category.Type = updatedCategory.Type;

            await _context.SaveChangesAsync(cancellationToken);

            return category;
        }

        public async Task<bool> DeleteCategory(Guid id, CancellationToken cancellationToken = default)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id, cancellationToken);

            if (category == null)
                return false;
            
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }

    }
}
