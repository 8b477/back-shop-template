using BLL_Shop.Interfaces;
using DAL_Shop.Interfaces;
using Database_Shop.Entity;

using Microsoft.AspNetCore.Http;


namespace BLL_Shop.Services
{
    public class ArticleService: IArticleService
    {

        #region DI
        private readonly IArticleRepository _repoArticle;
        public ArticleService(IArticleRepository repoArticle)
        {
            _repoArticle = repoArticle;
        }
        #endregion



        #region <-------------> CREATE <------------->
        public async Task<IResult> CreateArticle(Article article)
        {
            var result = await _repoArticle.Create(article);

            return
                result is null 
                ? TypedResults.BadRequest() 
                : TypedResults.Ok(article);
        }
        #endregion



        #region <-------------> GET <------------->
        public async Task<IResult> GetAllArticles()
        {
            var result = await _repoArticle.GetAll();

            return TypedResults.Ok(result);
        }

        public async Task<IResult> GetArticleByCategory(string categoryName)
        {
            var result = await _repoArticle.GetByCategory(categoryName);

            return 
                result.Count == 0
                ? TypedResults.Ok(result) 
                : TypedResults.BadRequest(new { Message = "Aucune correspondance !" });
        }

        public async Task<IResult> GetArticleById(int id)
        {
            var result = await _repoArticle.GetById(id);

            return
                result is not null
                ? TypedResults.Ok(result)
                : TypedResults.BadRequest(new { Message = "Aucune correspondance !" });
        }
        #endregion



        #region <-------------> UPDATE <------------->
        public async Task<IResult> UpdateArticle(int id, Article article)
        {
            var result = await _repoArticle.Update(id, article);

            return
                result is not null
                ? TypedResults.Ok(result)
                : TypedResults.BadRequest(new { Message = "Something was wrong, please retry" });
        }

        public async Task<IResult> UpdateArticleName(int id, string name)
        {
            var result = await _repoArticle.UpdateName(id, name);

            return
                ! string.IsNullOrEmpty(result)
                ? TypedResults.Ok(result)
                : TypedResults.BadRequest(new { Message = "Something was wrong, please retry" });
        }

        public async Task<IResult> UpdateArticlePrice(int id, int price)
        {
            var result = await _repoArticle.UpdatePrice(id, price);

            return
                !string.IsNullOrEmpty(result)
                ? TypedResults.Ok(result)
                : TypedResults.BadRequest(new { Message = "Something was wrong, please retry" });
        }

        public async Task<IResult> UpdateArticlePromo(int id, bool promo)
        {
            var result = await _repoArticle.UpdatePromo(id, promo);

            return
                !string.IsNullOrEmpty(result)
                ? TypedResults.Ok(result)
                : TypedResults.BadRequest(new { Message = "Something was wrong, please retry" });
        }

        public async Task<IResult> UpdateArticleStock(int id, int stock)
        {
            var result = await _repoArticle.UpdateStock(id, stock);

            return
                !string.IsNullOrEmpty(result)
                ? TypedResults.Ok(result)
                : TypedResults.BadRequest(new { Message = "Something was wrong, please retry" });
        }
        #endregion



        #region <-------------> DELETE <------------->
        public async Task<IResult> DeleteArticle(int id)
        {
            var result = await _repoArticle.Delete(id);

            return
                result
                ? TypedResults.NoContent()
                : TypedResults.BadRequest();
        }
        #endregion

    }
}
