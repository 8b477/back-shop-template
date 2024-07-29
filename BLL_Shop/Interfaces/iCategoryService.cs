using BLL_Shop.DTO.Category.Create;
using BLL_Shop.DTO.Category.Update;

using Microsoft.AspNetCore.Http;


namespace BLL_Shop.Interfaces
{
    public interface ICategoryService
    {



        #region <-------------> CREATE <------------->
        /// <summary>
        /// Creates a new category.
        /// </summary>
        /// <param name="category">The category to create.</param>
        /// <returns>An <see cref="IResult"/> indicating the outcome of the creation process.</returns>
        Task<IResult> CreateCategory(CategoryCreateDTO category);
        #endregion




        #region <-------------> GET <------------->
        /// <summary>
        /// Retrieves all categories.
        /// </summary>
        /// <returns>An <see cref="IResult"/> containing a list of all categories.</returns>
        Task<IResult> GetAllCategories();

        /// <summary>
        /// Retrieves a category by its ID.
        /// </summary>
        /// <param name="id">The ID of the category to retrieve.</param>
        /// <returns>An <see cref="IResult"/> containing the category with the specified ID.</returns>
        Task<IResult> GetCategoryById(int id);
        #endregion




        #region <-------------> UPDATE <------------->
        /// <summary>
        /// Updates the name of a category.
        /// </summary>
        /// <param name="id">The ID of the category to update.</param>
        /// <param name="name">The new name of the category.</param>
        /// <returns>An <see cref="IResult"/> indicating the outcome of the update process.</returns>
        Task<IResult> UpdateCategory(int id, CategoryUpdateDTO categoryNameToUpdate);
        #endregion




        #region <-------------> DELETE <------------->
        /// <summary>
        /// Deletes a category by its ID.
        /// </summary>
        /// <param name="id">The ID of the category to delete.</param>
        /// <returns>An <see cref="IResult"/> indicating the outcome of the deletion process.</returns>
        Task<IResult> DeleteCategory(int id);
        #endregion



    }
}
