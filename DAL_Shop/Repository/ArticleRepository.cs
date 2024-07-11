using DAL_Shop.Interfaces;

using Database_Shop.DB.Context;
using Database_Shop.Entity;

using Microsoft.EntityFrameworkCore;

namespace DAL_Shop.Repository
{
    public class ArticleRepository : IArticleRepository
    {

        #region DI
        private readonly ShopDB _ctx;

        public ArticleRepository(ShopDB ctx)
        {
            _ctx = ctx;
        }
        #endregion

        #region <-------------> CREATE <------------->
        public async Task<Article?> CreateArticle(Article article)
        {
            var result = await _ctx.Article.AddAsync(article);
            await _ctx.SaveChangesAsync();

            return result.Entity;    
        }
        #endregion



        #region <-------------> GET <------------->
        public async Task<List<Article?>> GetAllArticles()
        {
            return await _ctx.Article.ToListAsync<Article?>();
        }

        public async Task<List<Article?>> GetArticleByCategory(string categoryName)
        {
            throw new NotImplementedException();
            //return await _ctx.Article.Where(a => a.Categories == categoryName).ToListAsync<Article?>();
        }

        public Task<Article?> GetArticleById(int id)
        {
            throw new NotImplementedException();
        }
        #endregion



        #region <-------------> UPDATE <------------->
        public Task<Article?> UpdateArticle(int id, Article article)
        {
            throw new NotImplementedException();
        }

        public Task<Article?> UpdateArticleName(int id, string name)
        {
            throw new NotImplementedException();
        }

        public Task<Article?> UpdateArticlePrice(int id, int price)
        {
            throw new NotImplementedException();
        }

        public Task<Article?> UpdateArticlePromo(int id, bool promo)
        {
            throw new NotImplementedException();
        }

        public Task<Article?> UpdateArticleStock(int id, int stock)
        {
            throw new NotImplementedException();
        }
        #endregion



        #region <-------------> DELETE <------------->
        public Task<string> DeleteArticle(int id)
        {
            throw new NotImplementedException();
        }
        #endregion


    }
}
