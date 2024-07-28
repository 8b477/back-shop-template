using Database_Shop.Entity;

namespace DAL_Shop.Interfaces
{
    public interface ICategoryRepository
    {



        #region <-------------> CREATE <------------->
        /// <summary>
        /// Creates a new category.
        /// </summary>
        /// <param name="category">The category to create.</param>
        /// <returns>The created category, or null if creation failed.</returns>
        Task<Category?> Create(Category category);
        #endregion




        #region <-------------> GET <------------->
        /// <summary>
        /// Retrieves all categories.
        /// </summary>
        /// <returns>A list of all categories.</returns>
        Task<IReadOnlyCollection<Category>> GetAll();

        /// <summary>
        /// Retrieves a category by its ID.
        /// </summary>
        /// <param name="id">The ID of the category to retrieve.</param>
        /// <returns>The category with the specified ID, or null if not found.</returns>
        Task<Category?> GetById(int id);

        /// <summary>
        /// Retrieves all categories corresponding to the list ID.
        /// </summary>
        /// <param name="ids">List of categories identifier to be retrieved.</param>
        /// <returns>Returns categories matching the specified IDs, or null if there is no match.</returns>
        Task<List<Category>?> GetByIds(List<int> ids);
        #endregion




        #region <-------------> UPDATE <------------->
        /// <summary>
        /// Updates the name of a category.
        /// </summary>
        /// <param name="id">The ID of the category to update.</param>
        /// <param name="name">The new name of the category.</param>
        /// <returns>The updated category, or null if update failed.</returns>
        Task<Category?> Update(int id, string name);
        #endregion




        #region <-------------> DELETE <------------->
        /// <summary>
        /// Deletes a category by its ID.
        /// </summary>
        /// <param name="id">The ID of the category to delete.</param>
        /// <returns>True if the category was successfully deleted, false otherwise.</returns>
        Task<bool> Delete(int id);
        #endregion



    }

}
