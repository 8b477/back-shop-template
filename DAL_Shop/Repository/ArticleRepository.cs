using DAL_Shop.Interfaces;

using Database_Shop.Entity;

namespace DAL_Shop.Repository
{
    public class ArticleRepository : IArticleRepository
    {
        public Task<Article?> CreateArticle(Article article)
        {
            throw new NotImplementedException();
        }

        public Task<string> DeleteArticle(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Article>> GetAllArticles()
        {
            throw new NotImplementedException();
        }

        public Task<List<Article?>> GetArticleByCategory(string categoryName)
        {
            throw new NotImplementedException();
        }

        public Task<Article?> GetArticleById(int id)
        {
            throw new NotImplementedException();
        }

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
    }
}
