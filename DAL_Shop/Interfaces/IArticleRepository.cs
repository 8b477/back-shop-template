using DAL_Shop.DTO.Article;

using Database_Shop.Entity;

namespace DAL_Shop.Interfaces
{
    public interface IArticleRepository
    {

        #region <-------------> CREATE <------------->
        /// <summary>
        /// Add a new Article to the database.
        /// </summary>
        /// <param name="article">Article to add.</param>
        /// <returns>If the insertion is successful, returns the added article; otherwise, returns null.</returns>
        Task<Article?> Create(Article article);
        #endregion



        #region <-------------> GET <------------->
        /// <summary>
        /// Retrieve all articles already in the database.
        /// </summary>
        /// <returns>Returns a list of articles.</returns>
        Task<IReadOnlyCollection<ArticleViewDTO>> GetAll();

        /// <summary>
        /// Retrieve articles by category name.
        /// </summary>
        /// <param name="categoryName">Name of the category.</param>
        /// <returns>Returns all articles found matching the category name, or null if none are matched.</returns>
        Task<IReadOnlyCollection<Article>> GetByCategory(string categoryName);

        /// <summary>
        /// Retrieve an article by its ID.
        /// </summary>
        /// <param name="id">ID of the article.</param>
        /// <returns>Returns the article found by ID, or null if not matched.</returns>
        Task<Article?> GetById(int id);

        /// <summary>
        /// Retrieve all articles already in the database with matching Identifiers.
        /// </summary>
        /// <returns>Returns a list of articles for which the identifier was found.</returns>
        Task<IReadOnlyCollection<Article>> GetByIdList(IReadOnlyCollection<int> ids);
        #endregion



        #region <-------------> UPDATE <------------->
        /// <summary>
        /// Update an article already in the database.
        /// </summary>
        /// <param name="id">ID of the article.</param>
        /// <param name="article">New values for the article.</param>
        /// <returns>If successful, returns the updated article; otherwise, returns null.</returns>
        Task<Article?> Update(int id, Article article);

        /// <summary>
        /// Update the name of an article already in the database.
        /// </summary>
        /// <param name="id">ID of the article.</param>
        /// <param name="name">New name for the article.</param>
        /// <returns>If successful, returns the updated article; otherwise, returns null.</returns>
        Task<string> UpdateName(int id, string name);

        /// <summary>
        /// Update the stock of an article already in the database.
        /// </summary>
        /// <param name="id">ID of the article.</param>
        /// <param name="stock">New stock quantity.</param>
        /// <returns>If successful, returns the updated article; otherwise, returns null.</returns>
        Task<string> UpdateStock(int id, int stock);

        /// <summary>
        /// Update the promo status of an article already in the database.
        /// </summary>
        /// <param name="id">ID of the article.</param>
        /// <param name="promo">New promo status (true/false).</param>
        /// <returns>If successful, returns the updated article; otherwise, returns null.</returns>
        Task<string> UpdatePromo(int id, bool promo);

        /// <summary>
        /// Update the price of an article already in the database.
        /// </summary>
        /// <param name="id">ID of the article.</param>
        /// <param name="price">New price of the article.</param>
        /// <returns>If successful, returns the updated article; otherwise, returns null.</returns>
        Task<string> UpdatePrice(int id, int price);
        #endregion



        #region <-------------> DELETE <------------->

        /// <summary>
        /// Delete an article from the database by its ID.
        /// </summary>
        /// <param name="id">ID of the article.</param>
        /// <returns>Returns an explicit string indicating the result of the deletion.</returns>
        Task<bool> Delete(int id);
        #endregion
    }
}
