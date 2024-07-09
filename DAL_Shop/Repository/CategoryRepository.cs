using DAL_Shop.Interfaces;
using Database_Shop.Entity;


namespace DAL_Shop.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        public Task<Category> CreateCategory(Category category)
        {
            throw new NotImplementedException();
        }

        public Task DeleteCategory(Category category)
        {
            throw new NotImplementedException();
        }

        public Task<Category> GetCategoryById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Category> UpdateCategory(Category category)
        {
            throw new NotImplementedException();
        }
    }
}
