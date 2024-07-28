using BLL_Shop.DTO.Article.Create;
using BLL_Shop.Interfaces;
using BLL_Shop.Mappers;
using DAL_Shop.Interfaces;
using Database_Shop.Entity;

using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;


namespace BLL_Shop.Services
{
    public class ArticleService : IArticleService
    {


        #region DI
        private readonly IArticleRepository _repoArticle;
        private readonly ICategoryRepository _repoCategory;
        private readonly ILogger<ArticleService> _logger;

        public ArticleService(IArticleRepository repoArticle, ICategoryRepository repoCategory, ILogger<ArticleService> logger)
        {
            _repoArticle = repoArticle;
            _repoCategory = repoCategory;
            _logger = logger;
        }
        #endregion



        #region <-------------> CREATE <------------->
        public async Task<IResult> CreateArticle(ArticleCreateDTO article)
        {
            try
            {
                _logger.LogInformation("Create new article");


                //VALIDTOR !!!
                //....


                var correspondingCategories = await _repoCategory.GetByIds(article.Categories);

                if (correspondingCategories is null)
                {
                    _logger.LogWarning("No reference match");
                    return TypedResults.BadRequest(new { Message = "No reference provided is correct" });
                }

                if(article.Categories.Count != correspondingCategories.Count)
                {
                    _logger.LogWarning("All supplied identifiers are not matched");
                    return TypedResults.BadRequest(new { Message = "Not all identifiers supplied are correct, please check and retry" });
                }


                Article articleMapped = MapperArticle.FromArticleCreateDTOToEntity(article);

                // Update relation table
                articleMapped.ArticleCategories = correspondingCategories.Select(c => new ArticleCategory 
                {
                    CategoryId = c.Id
                }).ToList();


                var result = await _repoArticle.Create(articleMapped);

                return result is null
                    ? TypedResults.BadRequest()
                    : TypedResults.Ok(article);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating article");

                return TypedResults.BadRequest(new { Message = "Error creating article" });
            }
        }
        #endregion




        #region <-------------> GET <------------->
        public async Task<IResult> GetAllArticles()
        {
            try
            {
                var result = await _repoArticle.GetAll();

                return TypedResults.Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving all articles");

                return TypedResults.BadRequest(new { Message = "Error retrieving articles" });
            }
        }

        public async Task<IResult> GetArticleByCategory(string categoryName)
        {
            try
            {
                var result = await _repoArticle.GetByCategory(categoryName);

                return result.Count != 0
                    ? TypedResults.Ok(result)
                    : TypedResults.NotFound(new { Message = "No articles found in this category" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving articles by category {CategoryName}", categoryName);

                return TypedResults.BadRequest(new { Message = "Error retrieving articles by category" });
            }
        }

        public async Task<IResult> GetArticleById(int id)
        {
            try
            {
                var result = await _repoArticle.GetById(id);

                return result is not null
                    ? TypedResults.Ok(result)
                    : TypedResults.NotFound(new { Message = "No article found with this ID" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving article by ID {ArticleId}", id);

                return TypedResults.BadRequest(new { Message = "Error retrieving article by ID" });
            }
        }
        #endregion




        #region <-------------> UPDATE <------------->
        public async Task<IResult> UpdateArticle(int id, Article article)
        {
            try
            {
                var result = await _repoArticle.Update(id, article);

                return result is not null
                    ? TypedResults.Ok(result)
                    : TypedResults.BadRequest(new { Message = "Error updating article, please retry" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating article with ID {ArticleId}", id);

                return TypedResults.BadRequest(new { Message = "Error updating article" });
            }
        }

        public async Task<IResult> UpdateArticleName(int id, string name)
        {
            try
            {
                var result = await _repoArticle.UpdateName(id, name);

                return !string.IsNullOrEmpty(result)
                    ? TypedResults.Ok(result)
                    : TypedResults.BadRequest(new { Message = "Error updating article name, please retry" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating article name with ID {ArticleId}", id);

                return TypedResults.BadRequest(new { Message = "Error updating article name" });
            }
        }

        public async Task<IResult> UpdateArticlePrice(int id, int price)
        {
            try
            {
                var result = await _repoArticle.UpdatePrice(id, price);

                return !string.IsNullOrEmpty(result)
                    ? TypedResults.Ok(result)
                    : TypedResults.BadRequest(new { Message = "Error updating article price, please retry" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating article price with ID {ArticleId}", id);

                return TypedResults.BadRequest(new { Message = "Error updating article price" });
            }
        }

        public async Task<IResult> UpdateArticlePromo(int id, bool promo)
        {
            try
            {
                var result = await _repoArticle.UpdatePromo(id, promo);

                return !string.IsNullOrEmpty(result)
                    ? TypedResults.Ok(result)
                    : TypedResults.BadRequest(new { Message = "Error updating article promo, please retry" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating article promo with ID {ArticleId}", id);

                return TypedResults.BadRequest(new { Message = "Error updating article promo" });
            }
        }

        public async Task<IResult> UpdateArticleStock(int id, int stock)
        {
            try
            {
                var result = await _repoArticle.UpdateStock(id, stock);

                return !string.IsNullOrEmpty(result)
                    ? TypedResults.Ok(result)
                    : TypedResults.BadRequest(new { Message = "Error updating article stock, please retry" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating article stock with ID {ArticleId}", id);

                return TypedResults.BadRequest(new { Message = "Error updating article stock" });
            }
        }
        #endregion




        #region <-------------> DELETE <------------->
        public async Task<IResult> DeleteArticle(int id)
        {
            try
            {
                var result = await _repoArticle.Delete(id);

                return result
                    ? TypedResults.NoContent()
                    : TypedResults.BadRequest(new { Message = "Error deleting article, please retry" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting article with ID {ArticleId}", id);

                return TypedResults.BadRequest(new { Message = "Error deleting article" });
            }
        }
        #endregion



    }

}
