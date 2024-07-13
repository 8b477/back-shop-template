using Database_Shop.Entity;

using Microsoft.AspNetCore.Http;


namespace BLL_Shop.Interfaces
{
    public interface ICategoryService
    {
        #region <-------------> CREATE <------------->
        Task<IResult> CreateCategory(Category category);
        #endregion



        #region <-------------> GET <------------->
        Task<IResult> GetAllCategories();
        Task<IResult> GetCategoryById(int id);
        #endregion



        #region <-------------> UPDATE <------------->
        Task<IResult> UpdateCategory(int id, string name);
        #endregion



        #region <-------------> DELETE <------------->
        Task<IResult> DeleteCategory(int id);
        #endregion
    }
}
