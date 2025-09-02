using InExTrack.Models;

namespace InExTrack.Interfaces.Repositories
{
    public interface ICategoryRepository
    {
        public Task<List<Category>> GetCategories(CancellationToken cancellationToken);
        public Task<Category?> GetCategoryById(Guid id, CancellationToken cancellationToken);
        public Task<Category> CreateCategory(Category category, CancellationToken cancellationToken);
        public Task<Category?> UpdateCategory(Guid id, Category updatedCategory, CancellationToken cancellationToken);
        public Task<bool> DeleteCategory(Guid id, CancellationToken cancellationToken);
    }
}
