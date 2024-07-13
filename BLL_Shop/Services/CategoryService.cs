using BLL_Shop.Interfaces;
using DAL_Shop.Interfaces;
using Database_Shop.Entity;

using Microsoft.AspNetCore.Http;


namespace BLL_Shop.Services
{
    public class CategoryService : ICategoryService
    {

        #region
        private readonly ICategoryRepository _repoCategory;
        public CategoryService(ICategoryRepository repoCategory) => _repoCategory = repoCategory;
        #endregion


        #region <-------------> CREATE <------------->
        public async Task<IResult> CreateCategory(Category category)
        {
            var result = await _repoCategory.Create(category);

            return 
                result is null 
                ? TypedResults.BadRequest() 
                : TypedResults.Ok(result);
        }
        #endregion



        #region <-------------> GET <------------->
        public async Task<IResult> GetAllCategories()
        {
            var result = await _repoCategory.GetAll();

            return 
                result.Count == 0
                ? TypedResults.NoContent()
                : TypedResults.Ok(result);

        }
        public async Task<IResult> GetCategoryById(int id)
        {
            var result = await _repoCategory.GetById(id);

            return
                result is null
                ? TypedResults.BadRequest()
                : TypedResults.Ok(result);
        }
        #endregion



        #region <-------------> UPDATE <------------->
        public async Task<IResult> UpdateCategory(int id, string name)
        {
            var result = await _repoCategory.Update(id, name);

            return
                result is null
                ? TypedResults.BadRequest()
                : TypedResults.Ok(result);

        }
        #endregion



        #region <-------------> DELETE <------------->
        public async Task<IResult> DeleteCategory(int id)
        {
            var result = await _repoCategory.Delete(id);

            return
                !result
                ? TypedResults.BadRequest()
                : TypedResults.NoContent();
        }
        #endregion
    }
}
