using DAL_Shop.Interfaces;
using Database_Shop.Context;
using Database_Shop.Entity;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;


namespace DAL_Shop.Repository
{
    public class CategoryRepository : ICategoryRepository
    {


        #region DI
        private readonly ShopDB _db;
        private readonly ILogger<CategoryRepository> _logger;

        public CategoryRepository(ShopDB db, ILogger<CategoryRepository> logger)
        {
            _db = db;
            _logger = logger;
        }
        #endregion



        #region <-------------> CREATE <------------->
        public async Task<Category?> Create(Category category)
        {
            try
            {
                var result = await _db.Category.AddAsync(category);

                await _db.SaveChangesAsync();

                _logger.LogInformation($"Category created successfully: {category.Name}");

                return result.Entity;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error creating category: {category.Name}");

                return null;
            }
        }
        #endregion



        #region <-------------> GET <------------->
        public async Task<IReadOnlyCollection<Category>> GetAll()
        {
            try
            {
                var result = await _db.Category.ToListAsync();

                _logger.LogInformation("Retrieved all categories successfully");

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving all categories");

                return new List<Category>();
            }
        }

        public async Task<Category?> GetById(int id)
        {
            try
            {
                var result = await _db.Category.FindAsync(id);

                if (result is null)
                {
                    _logger.LogWarning("Category with ID : {id} not found", id);

                    throw new ArgumentNullException("No matching search !");
                }

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error retrieving category by ID: {id}");

                return null;
            }
        }

        public async Task<List<Category>?> GetByIds(List<int> ids)
        {
            var result = await _db.Category.Where(c => ids.Contains(c.Id)).ToListAsync();

            if (result is null)
                return null;

            return result;
        }
        #endregion



        #region <-------------> UPDATE <------------->
        public async Task<Category?> Update(int id, string name)
        {
            try
            {
                var existingCategory = await _db.Category.FindAsync(id);

                if (existingCategory is null)
                {
                    _logger.LogWarning("Category with ID : {id} not found", id);

                    throw new ArgumentNullException("No matching search !");
                }

                existingCategory.Name = name;

                await _db.SaveChangesAsync();

                _logger.LogInformation($"Category updated successfully: {id}");

                return existingCategory;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error updating category: {id}");

                return null;
            }
        }
        #endregion




        #region <-------------> DELETE <------------->
        public async Task<bool> Delete(int id)
        {
            try
            {
                var existingCategory = await _db.Category.FindAsync(id);

                if (existingCategory is null)
                {
                    _logger.LogWarning("Category with ID : {id} not found", id);

                    throw new ArgumentNullException("No matching search !");
                }

                _db.Category.Remove(existingCategory);

                await _db.SaveChangesAsync();

                _logger.LogInformation($"Category deleted successfully: {id}");

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error deleting category: {id}");

                return false;
            }
        }
        #endregion



    }
}
