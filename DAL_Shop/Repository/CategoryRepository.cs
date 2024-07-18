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

                if (result != null)
                {
                    _logger.LogInformation($"Retrieved category by ID: {id}");
                }
                else
                {
                    _logger.LogWarning($"Category not found for ID: {id}");
                }
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error retrieving category by ID: {id}");

                return null;
            }
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
                    _logger.LogWarning($"Category not found for update: {id}");

                    return null;
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
                    _logger.LogWarning($"Category not found for deletion: {id}");

                    return false;
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
