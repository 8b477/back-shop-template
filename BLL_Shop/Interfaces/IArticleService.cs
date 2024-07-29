using BLL_Shop.DTO.Article.Create;
using BLL_Shop.DTO.Article.Update;

using Microsoft.AspNetCore.Http;


namespace BLL_Shop.Interfaces
{
    public interface IArticleService
    {

        #region <-------------> CREATE <------------->
        /// <summary>
        /// Add a new Article to the database.
        /// </summary>
        /// <param name="article">Article to add.</param>
        /// <returns>If the insertion is successful, returns the added article; otherwise, returns null.</returns>
        Task<IResult> CreateArticle(ArticleCreateDTO article);
        #endregion



        #region <-------------> GET <------------->
        /// <summary>
        /// Retrieve all articles already in the database.
        /// </summary>
        /// <returns>Returns a list of articles.</returns>
        Task<IResult> GetAllArticles();

        /// <summary>
        /// Retrieve articles by category name.
        /// </summary>
        /// <param name="categoryName">Name of the category.</param>
        /// <returns>Returns all articles found matching the category name, or null if none are matched.</returns>
        Task<IResult> GetArticleByCategory(string categoryName);

        /// <summary>
        /// Retrieve an article by its ID.
        /// </summary>
        /// <param name="id">ID of the article.</param>
        /// <returns>Returns the article found by ID, or null if not matched.</returns>
        Task<IResult> GetArticleById(int id);
        #endregion



        #region <-------------> UPDATE <------------->
        /// <summary>
        /// Update an article already in the database.
        /// </summary>
        /// <param name="id">ID of the article.</param>
        /// <param name="article">New values for the article.</param>
        /// <returns>If successful, returns the updated article; otherwise, returns null.</returns>
        Task<IResult> UpdateArticle(int id, ArticleUpdateDTO article);

        /// <summary>
        /// Update the name of an article already in the database.
        /// </summary>
        /// <param name="id">ID of the article.</param>
        /// <param name="articleNameToUpdate">New name for the article.</param>
        /// <returns>If successful, returns the updated article; otherwise, returns null.</returns>
        Task<IResult> UpdateArticleName(int id, ArticleNameUpdateDTO articleNameToUpdate);

        /// <summary>
        /// Update the stock of an article already in the database.
        /// </summary>
        /// <param name="id">ID of the article.</param>
        /// <param name="articleStockToUpdate">New stock quantity.</param>
        /// <returns>If successful, returns the updated article; otherwise, returns null.</returns>
        Task<IResult> UpdateArticleStock(int id, ArticleStockUpdateDTO articleStockToUpdate);

        /// <summary>
        /// Update the promo status of an article already in the database.
        /// </summary>
        /// <param name="id">ID of the article.</param>
        /// <param name="articlePromoToUpdate">New promo status (true/false).</param>
        /// <returns>If successful, returns the updated article; otherwise, returns null.</returns>
        Task<IResult> UpdateArticlePromo(int id, ArticlePromoUpdateDTO articlePromoToUpdate);

        /// <summary>
        /// Update the price of an article already in the database.
        /// </summary>
        /// <param name="id">ID of the article.</param>
        /// <param name="articlePriceToUpdate">New price of the article.</param>
        /// <returns>If successful, returns the updated article; otherwise, returns null.</returns>
        Task<IResult> UpdateArticlePrice(int id, ArticlePriceUpdateDTO articlePriceToUpdate);
        #endregion



        #region <-------------> DELETE <------------->

        /// <summary>
        /// Delete an article from the database by its ID.
        /// </summary>
        /// <param name="id">ID of the article.</param>
        /// <returns>Returns an explicit string indicating the result of the deletion.</returns>
        Task<IResult> DeleteArticle(int id);
        #endregion
    }
}
