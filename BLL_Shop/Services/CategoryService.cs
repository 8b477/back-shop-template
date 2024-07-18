using BLL_Shop.Interfaces;
using DAL_Shop.Interfaces;
using Database_Shop.Entity;

using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;


namespace BLL_Shop.Services
{
    public class CategoryService : ICategoryService
    {


        #region DI
        private readonly ICategoryRepository _repoCategory;
        private readonly ILogger<CategoryService> _logger;

        public CategoryService(ICategoryRepository repoCategory, ILogger<CategoryService> logger)
        {
            _repoCategory = repoCategory;
            _logger = logger;
        }
        #endregion



        #region <-------------> CREATE <------------->
        public async Task<IResult> CreateCategory(Category category)
        {
            try
            {
                var result = await _repoCategory.Create(category);

                if (result is null)
                {
                    _logger.LogWarning($"Failed to create category: {category.Name}");

                    return TypedResults.BadRequest();
                }
                _logger.LogInformation($"Category created successfully: {result.Id}");

                return TypedResults.Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while creating category: {category.Name}");

                return TypedResults.StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        #endregion



        #region <-------------> GET <------------->
        public async Task<IResult> GetAllCategories()
        {
            try
            {
                var result = await _repoCategory.GetAll();

                if (result.Count == 0)
                {
                    _logger.LogInformation("No categories found");

                    return TypedResults.NotFound(new { Message = "Aucune correspondance" });
                }
                _logger.LogInformation($"Retrieved {result.Count} categories");

                return TypedResults.Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while retrieving all categories");

                return TypedResults.StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<IResult> GetCategoryById(int id)
        {
            try
            {
                var result = await _repoCategory.GetById(id);

                if (result is null)
                {
                    _logger.LogWarning($"Category not found: {id}");

                    return TypedResults.NotFound(new { Message = "Aucune correspondance" });
                }
                _logger.LogInformation($"Retrieved category: {id}");

                return TypedResults.Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while retrieving category: {id}");

                return TypedResults.StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        #endregion



        #region <-------------> UPDATE <------------->
        public async Task<IResult> UpdateCategory(int id, string name)
        {
            try
            {
                var result = await _repoCategory.Update(id, name);

                if (result is null)
                {
                    _logger.LogWarning($"Failed to update category: {id}");

                    return TypedResults.BadRequest();
                }
                _logger.LogInformation($"Category updated successfully: {id}");

                return TypedResults.Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while updating category: {id}");

                return TypedResults.StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        #endregion



        #region <-------------> DELETE <------------->
        public async Task<IResult> DeleteCategory(int id)
        {
            try
            {
                var result = await _repoCategory.Delete(id);

                if (!result)
                {
                    _logger.LogWarning($"Failed to delete category: {id}");

                    return TypedResults.BadRequest();
                }
                _logger.LogInformation($"Category deleted successfully: {id}");

                return TypedResults.NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while deleting category: {id}");

                return TypedResults.StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        #endregion



    }
}
