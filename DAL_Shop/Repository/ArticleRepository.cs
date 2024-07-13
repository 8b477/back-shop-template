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
        public async Task<Article?> Create(Article article)
        {
            var result = await _ctx.Article.AddAsync(article);
            await _ctx.SaveChangesAsync();

            return result.Entity;    
        }
        #endregion



        #region <-------------> GET <------------->
        public async Task<List<Article>> GetAll()
        {
            return await _ctx.Article.ToListAsync();
        }

        public async Task<List<Article>> GetByCategory(string categoryName)
        {
            var result = await _ctx.Category.Where(c => c.Name == categoryName)
                .SelectMany(c => c.ArticleCategories)
                .Select(ac => ac.Article)
                .ToListAsync();

            return result;
        }

        public async Task<Article?> GetById(int id)
        {
            return await _ctx.Article.FindAsync(id);
        }
        #endregion



        #region <-------------> UPDATE <------------->
        public async Task<Article?> Update(int id, Article article)
        {
            var existingArticle = await _ctx.Article.FindAsync(id);

            if (existingArticle is null)
                return null;

            foreach (var property in _ctx.Entry(existingArticle).Properties)
            {
                if (property.Metadata.Name != "Id")
                {
                    property.CurrentValue = _ctx.Entry(article).Property(property.Metadata.Name).CurrentValue;
                }
            }
            _ctx.Article.Update(article);

            await _ctx.SaveChangesAsync();

            return article;
        }

        public async Task<string> UpdateName(int id, string name)
        {
            var existingArticle = await _ctx.Article.FindAsync(id);

            if (existingArticle is null)
                return "";

            existingArticle.Name = name;
            _ctx.Article.Update(existingArticle);
            await _ctx.SaveChangesAsync();

            return $"Nouveau nom '{name}' mis à jour";
        }

        public async Task<string> UpdatePrice(int id, int price)
        {
            var existingArticle = await _ctx.Article.FindAsync(id);

            if (existingArticle is null)
                return "";

            existingArticle.Price = price;
            _ctx.Article.Update(existingArticle);
            await _ctx.SaveChangesAsync();

            return $"Nouveau prix '{price}' mis à jour";
        }

        public async Task<string> UpdatePromo(int id, bool promo)
        {
            var existingArticle = await _ctx.Article.FindAsync(id);

            if (existingArticle is null)
                return "";

            existingArticle.Promo = promo;
            _ctx.Article.Update(existingArticle);
            await _ctx.SaveChangesAsync();

            return "Mis à jour de la promotion de l'article, nouvelle valeur : '{promo}'";
        }

        public async Task<string> UpdateStock(int id, int stock)
        {
            var existingArticle = await _ctx.Article.FindAsync(id);

            if (existingArticle is null)
                return "";

            existingArticle.Stock = stock;
            _ctx.Article.Update(existingArticle);
            await _ctx.SaveChangesAsync();

            return "Mis à jour du stock de l'article, nouveau stock : '{stock}'";
        }
        #endregion



        #region <-------------> DELETE <------------->
        public async Task<bool> Delete(int id)
        {
            var existingArticle = await _ctx.Article.FindAsync(id);

            if (existingArticle is null)
                return false;

            _ctx.Article.Remove(existingArticle);
            await _ctx.SaveChangesAsync();

            return true;
        }
        #endregion


    }
}
