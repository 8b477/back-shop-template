using DAL_Shop.Interfaces;
using Database_Shop.Context;
using Database_Shop.Entity;

using Microsoft.EntityFrameworkCore;


namespace DAL_Shop.Repository
{
    public class CategoryRepository : ICategoryRepository
    {

        #region DI
        private readonly ShopDB _db;
        public CategoryRepository(ShopDB db) => _db = db;
        #endregion



        #region <-------------> CREATE <------------->
        public async Task<Category?> Create(Category category)
        {
            var result = await _db.Category.AddAsync(category);

            await _db.SaveChangesAsync();

            return result.Entity;
        }

        #endregion



        #region <-------------> GET <------------->
        public async Task<List<Category>> GetAll()
        {
            var result = await _db.Category.ToListAsync();

            return result;
        }

        public async Task<Category?> GetById(int id)
        {
            var result = await _db.Category.FindAsync(id);

            return result;
        }
        #endregion



        #region <-------------> UPDATE <------------->
        public async Task<Category?> Update(int id, string name)
        {
            var existingCategory = await _db.Category.FindAsync(id);

            if (existingCategory is null)
                return null;

            existingCategory.Name = name;

            await _db.SaveChangesAsync();

            return existingCategory;
        }

        #endregion



        #region <-------------> DELETE <------------->
        public async Task<bool> Delete(int id)
        {
            var existingCategory = await _db.Category.FindAsync(id);

            if (existingCategory is null)
                return false;

            _db.Category.Remove(existingCategory);

            return true;
        }
        #endregion

    }
}
