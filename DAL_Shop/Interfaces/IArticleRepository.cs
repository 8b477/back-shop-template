using Database_Shop.Entity;

namespace DAL_Shop.Interfaces
{
    public interface IArticleRepository
    {
        /// <summary>
        /// Add a new Article to the database.
        /// </summary>
        /// <param name="article">Article to add.</param>
        /// <returns>If the insertion is successful, returns the added article; otherwise, returns null.</returns>
        Task<Article?> CreateArticle(Article article);

        /// <summary>
        /// Retrieve all articles already in the database.
        /// </summary>
        /// <returns>Returns a list of articles.</returns>
        Task<List<Article>> GetAllArticles();

        /// <summary>
        /// Retrieve articles by category name.
        /// </summary>
        /// <param name="categoryName">Name of the category.</param>
        /// <returns>Returns all articles found matching the category name, or null if none are matched.</returns>
        Task<List<Article?>> GetArticleByCategory(string categoryName);

        /// <summary>
        /// Retrieve an article by its ID.
        /// </summary>
        /// <param name="id">ID of the article.</param>
        /// <returns>Returns the article found by ID, or null if not matched.</returns>
        Task<Article?> GetArticleById(int id);

        /// <summary>
        /// Delete an article from the database by its ID.
        /// </summary>
        /// <param name="id">ID of the article.</param>
        /// <returns>Returns an explicit string indicating the result of the deletion.</returns>
        Task<string> DeleteArticle(int id);

        /// <summary>
        /// Update an article already in the database.
        /// </summary>
        /// <param name="id">ID of the article.</param>
        /// <param name="article">New values for the article.</param>
        /// <returns>If successful, returns the updated article; otherwise, returns null.</returns>
        Task<Article?> UpdateArticle(int id, Article article);

        /// <summary>
        /// Update the name of an article already in the database.
        /// </summary>
        /// <param name="id">ID of the article.</param>
        /// <param name="name">New name for the article.</param>
        /// <returns>If successful, returns the updated article; otherwise, returns null.</returns>
        Task<Article?> UpdateArticleName(int id, string name);

        /// <summary>
        /// Update the stock of an article already in the database.
        /// </summary>
        /// <param name="id">ID of the article.</param>
        /// <param name="stock">New stock quantity.</param>
        /// <returns>If successful, returns the updated article; otherwise, returns null.</returns>
        Task<Article?> UpdateArticleStock(int id, int stock);

        /// <summary>
        /// Update the promo status of an article already in the database.
        /// </summary>
        /// <param name="id">ID of the article.</param>
        /// <param name="promo">New promo status (true/false).</param>
        /// <returns>If successful, returns the updated article; otherwise, returns null.</returns>
        Task<Article?> UpdateArticlePromo(int id, bool promo);

        /// <summary>
        /// Update the price of an article already in the database.
        /// </summary>
        /// <param name="id">ID of the article.</param>
        /// <param name="price">New price of the article.</param>
        /// <returns>If successful, returns the updated article; otherwise, returns null.</returns>
        Task<Article?> UpdateArticlePrice(int id, int price);
    }
}
