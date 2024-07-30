using BLL_Shop.DTO.Article.Create;
using BLL_Shop.DTO.Article.Update;
using BLL_Shop.Interfaces;
using BLL_Shop.Mappers;
using BLL_Shop.Validators;
using DAL_Shop.Interfaces;
using Database_Shop.Entity;

using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;


namespace BLL_Shop.Services
{
    public class ArticleService : IArticleService
    {


        #region DI
        private readonly IArticleRepository _repoArticle;
        private readonly ICategoryRepository _repoCategory;
        private readonly IValidator<ArticleCreateDTO> _articleCreateValidator;
        private readonly IValidator<ArticleUpdateDTO> _articleUpdateValidator;
        private readonly IValidator<ArticleNameUpdateDTO> _articleUpdateNameValidator;
        private readonly IValidator<ArticlePriceUpdateDTO> _articleUpdatePriceValidator;
        private readonly IValidator<ArticlePromoUpdateDTO> _articleUpdatePromoValidator;
        private readonly IValidator<ArticleStockUpdateDTO> _articleUpdateStockValidator;
        private readonly ILogger<ArticleService> _logger;

        public ArticleService(
            IArticleRepository repoArticle,
            ICategoryRepository repoCategory,
            IValidator<ArticleCreateDTO> articleCreateValidator,
            IValidator<ArticleUpdateDTO> articleUpdateValidator,
            IValidator<ArticleNameUpdateDTO> articleUpdateNameValidator,
            IValidator<ArticlePriceUpdateDTO> articleUpdatePriceValidator,
            IValidator<ArticlePromoUpdateDTO> articleUpdatePromoValidator,
            IValidator<ArticleStockUpdateDTO> articleUpdateStockValidator,
            ILogger<ArticleService> logger
            )
        {
            _repoArticle = repoArticle;
            _repoCategory = repoCategory;
            _articleCreateValidator = articleCreateValidator;
            _articleUpdateValidator = articleUpdateValidator;
            _articleUpdateNameValidator = articleUpdateNameValidator;
            _articleUpdatePriceValidator = articleUpdatePriceValidator;
            _articleUpdatePromoValidator = articleUpdatePromoValidator;
            _articleUpdateStockValidator = articleUpdateStockValidator;
            _logger = logger;
        }
        #endregion



        #region <-------------> CREATE <------------->
        public async Task<IResult> CreateArticle(ArticleCreateDTO article)
        {
            try
            {
                _logger.LogInformation("Create new article");


                var validationResult = await ValidatorModelState.ValidModelState(article, _articleCreateValidator);

                if (validationResult != Results.Ok())
                {
                    _logger.LogWarning("Validation failed for address creation");

                    return validationResult;
                }


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


                Article articleMapped = MapperArticle.DtoToEntity(article);

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
            catch (ArgumentNullException ex)
            {
                return TypedResults.BadRequest(ex.Message);
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
            catch (ArgumentNullException ex)
            {
                return TypedResults.BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving article by ID {ArticleId}", id);

                return TypedResults.BadRequest(new { Message = "Error retrieving article by ID" });
            }
        }
        #endregion




        #region <-------------> UPDATE <------------->
        public async Task<IResult> UpdateArticle(int id, ArticleUpdateDTO article)
        {
            try
            {
                _logger.LogInformation("Update article id : {id}", id);


                var validationResult = await ValidatorModelState.ValidModelState(article, _articleUpdateValidator);

                if (validationResult != Results.Ok())
                {
                    _logger.LogWarning("Validation failed for article update");

                    return validationResult;
                }



                var correspondingCategories = await _repoCategory.GetByIds(article.Categories);

                if (correspondingCategories is null)
                {
                    _logger.LogWarning("No reference match");
                    return TypedResults.BadRequest(new { Message = "No reference provided is correct" });
                }

                if (article.Categories.Count != correspondingCategories.Count)
                {
                    _logger.LogWarning("All supplied identifiers are not matched");
                    return TypedResults.BadRequest(new { Message = "Not all identifiers supplied are correct, please check and retry" });
                }


                Article articleMapped = MapperArticle.DtoToEntity(article);

                articleMapped.Id = id;

                // Update relation table
                articleMapped.ArticleCategories = correspondingCategories.Select(c => new ArticleCategory
                {
                    ArticleId = id,
                    CategoryId = c.Id
                }).ToList();

                var result = await _repoArticle.Update(id, articleMapped);

                return result is not null
                    ? TypedResults.Ok(result)
                    : TypedResults.BadRequest(new { Message = "Error updating article, please retry" });
            }
            catch (ArgumentNullException ex)
            {
                return TypedResults.BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating article with ID {ArticleId}", id);

                return TypedResults.BadRequest(new { Message = "Error updating article" });
            }
        }

        public async Task<IResult> UpdateArticleName(int id, ArticleNameUpdateDTO articleNameToUpdate)
        {
            try
            {
                _logger.LogInformation("Update article name, id article : {id}", id);


                var validationResult = await ValidatorModelState.ValidModelState(articleNameToUpdate, _articleUpdateNameValidator);

                if (validationResult != Results.Ok())
                {
                    _logger.LogWarning("Validation failed for article update value : name");

                    return validationResult;
                }


                var result = await _repoArticle.UpdateName(id, articleNameToUpdate.Name);

                return !string.IsNullOrEmpty(result)
                    ? TypedResults.Ok(result)
                    : TypedResults.BadRequest(new { Message = "Error updating article name, please retry" });
            }
            catch (ArgumentNullException ex)
            {
                return TypedResults.BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating article name with ID {ArticleId}", id);

                return TypedResults.BadRequest(new { Message = "Error updating article name" });
            }
        }

        public async Task<IResult> UpdateArticlePrice(int id, ArticlePriceUpdateDTO articlePriceToUpdate)
        {
            try
            {
                _logger.LogInformation("Update article price, id article : {id}", id);


                var validationResult = await ValidatorModelState.ValidModelState(articlePriceToUpdate, _articleUpdatePriceValidator);

                if (validationResult != Results.Ok())
                {
                    _logger.LogWarning("Validation failed for article update value : price");

                    return validationResult;
                }


                var result = await _repoArticle.UpdatePrice(id, articlePriceToUpdate.Price);

                return !string.IsNullOrEmpty(result)
                    ? TypedResults.Ok(result)
                    : TypedResults.BadRequest(new { Message = "Error updating article price, please retry" });
            }
            catch (ArgumentNullException ex)
            {
                return TypedResults.BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating article price with ID {ArticleId}", id);

                return TypedResults.BadRequest(new { Message = "Error updating article price" });
            }
        }

        public async Task<IResult> UpdateArticlePromo(int id, ArticlePromoUpdateDTO articlePromoToUpdate)
        {
            try
            {
                _logger.LogInformation("Update article promo, id article : {id}", id);


                var validationResult = await ValidatorModelState.ValidModelState(articlePromoToUpdate, _articleUpdatePromoValidator);

                if (validationResult != Results.Ok())
                {
                    _logger.LogWarning("Validation failed for article update value : promo");

                    return validationResult;
                }


                var result = await _repoArticle.UpdatePromo(id, articlePromoToUpdate.Promo);

                return !string.IsNullOrEmpty(result)
                    ? TypedResults.Ok(result)
                    : TypedResults.BadRequest(new { Message = "Error updating article promo, please retry" });
            }
            catch (ArgumentNullException ex)
            {
                return TypedResults.BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating article promo with ID {ArticleId}", id);

                return TypedResults.BadRequest(new { Message = "Error updating article promo" });
            }
        }

        public async Task<IResult> UpdateArticleStock(int id, ArticleStockUpdateDTO articleStockToUpdate)
        {
            try
            {
                _logger.LogInformation("Update article stock, id article : {id}", id);


                var validationResult = await ValidatorModelState.ValidModelState(articleStockToUpdate, _articleUpdateStockValidator);

                if (validationResult != Results.Ok())
                {
                    _logger.LogWarning("Validation failed for article update value : stock");

                    return validationResult;
                }


                var result = await _repoArticle.UpdateStock(id, articleStockToUpdate.Stock);

                return !string.IsNullOrEmpty(result)
                    ? TypedResults.Ok(result)
                    : TypedResults.BadRequest(new { Message = "Error updating article stock, please retry" });
            }
            catch (ArgumentNullException ex)
            {
                return TypedResults.BadRequest(ex.Message);
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
            catch (ArgumentNullException ex)
            {
                return TypedResults.BadRequest(ex.Message);
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
