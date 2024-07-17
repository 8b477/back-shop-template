using DAL_Shop.Interfaces;
using Database_Shop.Context;
using Database_Shop.Entity;


namespace DAL_Shop.Repository
{
    using Microsoft.Extensions.Logging;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;

    public class ArticleRepository : IArticleRepository
    {



        #region DI
        private readonly ShopDB _ctx;
        private readonly ILogger<ArticleRepository> _logger;

        public ArticleRepository(ShopDB ctx, ILogger<ArticleRepository> logger)
        {
            _ctx = ctx;
            _logger = logger;
        }
        #endregion



        #region <-------------> CREATE <------------->
        public async Task<Article?> Create(Article article)
        {
            try
            {
                var result = await _ctx.Article.AddAsync(article);
                await _ctx.SaveChangesAsync();
                _logger.LogInformation("Article created with ID {ArticleId}", result.Entity.Id);
                return result.Entity;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating article");
                return null;
            }
        }
        #endregion




        #region <-------------> GET <------------->
        public async Task<List<Article>> GetAll()
        {
            try
            {
                return await _ctx.Article.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving all articles");
                return new List<Article>();
            }
        }

        public async Task<List<Article>> GetByCategory(string categoryName)
        {
            try
            {
                var result = await _ctx.Category.Where(c => c.Name == categoryName)
                    .SelectMany(c => c.ArticleCategories)
                    .Select(ac => ac.Article)
                    .ToListAsync();

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving articles by category {CategoryName}", categoryName);
                return new List<Article>();
            }
        }

        public async Task<List<Article>> GetByIdList(List<int> ids)
        {
            try
            {
                return await _ctx.Article.Where(a => ids.Contains(a.Id)).ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving articles by ID list");
                return new List<Article>();
            }
        }

        public async Task<Article?> GetById(int id)
        {
            try
            {
                return await _ctx.Article.FindAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving article by ID {ArticleId}", id);
                return null;
            }
        }
        #endregion




        #region <-------------> UPDATE <------------->
        public async Task<Article?> Update(int id, Article article)
        {
            try
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
                _ctx.Article.Update(existingArticle);

                await _ctx.SaveChangesAsync();

                _logger.LogInformation("Article with ID {ArticleId} updated", id);
                return existingArticle;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating article with ID {ArticleId}", id);
                return null;
            }
        }

        public async Task<string> UpdateName(int id, string name)
        {
            try
            {
                var existingArticle = await _ctx.Article.FindAsync(id);

                if (existingArticle is null)
                    return "";

                existingArticle.Name = name;
                _ctx.Article.Update(existingArticle);
                await _ctx.SaveChangesAsync();

                _logger.LogInformation("Updated name of article with ID {ArticleId} to {Name}", id, name);
                return $"Nouveau nom '{name}' mis à jour";
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating name of article with ID {ArticleId}", id);
                return "";
            }
        }

        public async Task<string> UpdatePrice(int id, int price)
        {
            try
            {
                var existingArticle = await _ctx.Article.FindAsync(id);

                if (existingArticle is null)
                    return "";

                existingArticle.Price = price;
                _ctx.Article.Update(existingArticle);
                await _ctx.SaveChangesAsync();

                _logger.LogInformation("Updated price of article with ID {ArticleId} to {Price}", id, price);
                return $"Nouveau prix '{price}' mis à jour";
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating price of article with ID {ArticleId}", id);
                return "";
            }
        }

        public async Task<string> UpdatePromo(int id, bool promo)
        {
            try
            {
                var existingArticle = await _ctx.Article.FindAsync(id);

                if (existingArticle is null)
                    return "";

                existingArticle.Promo = promo;
                _ctx.Article.Update(existingArticle);
                await _ctx.SaveChangesAsync();

                _logger.LogInformation("Updated promo of article with ID {ArticleId} to {Promo}", id, promo);
                return "Mis à jour de la promotion de l'article, nouvelle valeur : '{promo}'";
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating promo of article with ID {ArticleId}", id);
                return "";
            }
        }

        public async Task<string> UpdateStock(int id, int stock)
        {
            try
            {
                var existingArticle = await _ctx.Article.FindAsync(id);

                if (existingArticle is null)
                    return "";

                existingArticle.Stock = stock;
                _ctx.Article.Update(existingArticle);
                await _ctx.SaveChangesAsync();

                _logger.LogInformation("Updated stock of article with ID {ArticleId} to {Stock}", id, stock);
                return "Mis à jour du stock de l'article, nouveau stock : '{stock}'";
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating stock of article with ID {ArticleId}", id);
                return "";
            }
        }
        #endregion




        #region <-------------> DELETE <------------->
        public async Task<bool> Delete(int id)
        {
            try
            {
                var existingArticle = await _ctx.Article.FindAsync(id);

                if (existingArticle is null)
                    return false;

                _ctx.Article.Remove(existingArticle);
                await _ctx.SaveChangesAsync();

                _logger.LogInformation("Deleted article with ID {ArticleId}", id);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting article with ID {ArticleId}", id);
                return false;
            }
        }
        #endregion



    }
}
