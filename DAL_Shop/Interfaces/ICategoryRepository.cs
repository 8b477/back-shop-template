using Database_Shop.Entity;

namespace DAL_Shop.Interfaces
{
    public interface ICategoryRepository
    {
        Task<Category> CreateCategory(Category category);

        Task<Category> UpdateCategory(Category category);

        Task DeleteCategory(Category category);

        Task<Category> GetCategoryById(int id);
    }
}
