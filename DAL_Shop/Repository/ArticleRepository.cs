using DAL_Shop.Interfaces;
using Database_Shop.Entity;
using DAL_Shop.Mapper;
using DAL_Shop.DTO.Article;

using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Database_Shop.SqlLite.Context;


namespace DAL_Shop.Repository
{
    public class ArticleRepository : IArticleRepository
    {



        #region DI
        private readonly ShopDbContextSqlLite _ctx;
        private readonly ILogger<ArticleRepository> _logger;

        public ArticleRepository(ShopDbContextSqlLite ctx, ILogger<ArticleRepository> logger)
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
        public async Task<IReadOnlyCollection<ArticleViewDTO>> GetAll()
        {
            try
            {
                var result = await _ctx.Article
                    .Include(a => a.ArticleCategories)
                    .ThenInclude(ac => ac.Category)
                    .ToListAsync();

                List<ArticleViewDTO> listMapped = MapperArticle.EntityToViewDTO(result);
                return listMapped;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving all articles");

                return [];
            }
        }

        public async Task<IReadOnlyCollection<ArticleViewDTO>> GetByCategory(string categoryName)
        {
            try
            {
                var result = await _ctx.Article
                    .Include(a => a.ArticleCategories)
                    .ThenInclude(ac => ac.Category)
                    .Where(ac => ac.ArticleCategories.Any(c => c.Category.Name.ToUpper() == categoryName.ToUpper()))
                    .ToListAsync();

                if (result is null)
                {
                    _logger.LogWarning("Category name with value {value} not found", categoryName);

                    throw new ArgumentNullException("No matching search !");
                }

                List<ArticleViewDTO> listMapped = MapperArticle.EntityToViewDTO(result);

                return listMapped;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving articles by category {CategoryName}", categoryName);

                return [];
            }
        }

        public async Task<IReadOnlyCollection<Article>> GetByIdList(IReadOnlyCollection<int> ids)
        {
            try
            {
                return await _ctx.Article.Where(a => ids.Contains(a.Id)).ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving articles by ID list");

                return [];
            }
        }

        public async Task<ArticleViewDTO?> GetById(int id)
        {
            try
            {
                var result = await _ctx.Article
                    .Include(a => a.ArticleCategories)
                    .ThenInclude(ac => ac.Category)
                    .FirstOrDefaultAsync(result => result.Id == id);

                if (result is null)
                {
                    _logger.LogWarning("Article with ID : {id} not found", id);

                    throw new ArgumentNullException("No matching search !");
                }

                ArticleViewDTO? listMapped = MapperArticle.EntityToViewDTO(result);

                return listMapped;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving article by ID {ArticleId}", id);

                return null;
            }
        }
        #endregion




        #region <-------------> UPDATE <------------->
        public async Task<ArticleViewDTO?> Update(int id, Article article)
        {
            try
            {
                var existingArticle = await _ctx.Article
                    .Include(a => a.ArticleCategories)
                    .FirstOrDefaultAsync(a => a.Id == id);

                if (existingArticle is null)
                {
                    _logger.LogWarning("Article with ID : {id} not found", id);

                    throw new ArgumentNullException("No matching search !");
                }

                _ctx.Entry(existingArticle).CurrentValues.SetValues(article);

                existingArticle.ArticleCategories.Clear();
                foreach (var category in article.ArticleCategories)
                {
                    existingArticle.ArticleCategories.Add(new ArticleCategory
                    {
                        CategoryId = category.CategoryId
                    });
                }

                await _ctx.SaveChangesAsync();
                _logger.LogInformation("Article with ID {ArticleId} updated", id);

                return MapperArticle.EntityToViewDTO(existingArticle);
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
                {
                    _logger.LogWarning("Article with ID : {id} not found", id);

                    throw new ArgumentNullException("No matching search !");
                }


                existingArticle.Name = name;

                _ctx.Article.Update(existingArticle);

                await _ctx.SaveChangesAsync();

                _logger.LogInformation("Updated name of article with ID {ArticleId} to {Name}", id, existingArticle.Name);

                return $"Nouveau nom '{name}' mis à jour pour l'article id : {id}";
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating name of article with ID {ArticleId}", id);

                return "";
            }
        }

        public async Task<string> UpdatePrice(int id, double price)
        {
            try
            {
                var existingArticle = await _ctx.Article.FindAsync(id);

                if (existingArticle is null)
                {
                    _logger.LogWarning("Article with ID : {id} not found", id);

                    throw new ArgumentNullException("No matching search !");
                }

                existingArticle.Price = price;

                _ctx.Article.Update(existingArticle);

                await _ctx.SaveChangesAsync();

                _logger.LogInformation("Updated price of article with ID {ArticleId} to {Price}", id, existingArticle.Price);

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
                {
                    _logger.LogWarning("Article with ID : {id} not found", id);

                    throw new ArgumentNullException("No matching search !");
                }

                existingArticle.Promo = promo;

                _ctx.Article.Update(existingArticle);

                await _ctx.SaveChangesAsync();

                _logger.LogInformation("Updated promo of article with ID {ArticleId} to {Promo}", id, existingArticle.Promo);

                return $"Mis à jour de la promotion de l'article id : {id}, nouvelle valeur : '{existingArticle.Promo}'";
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
                {
                    _logger.LogWarning("Article with ID : {id} not found", id);

                    throw new ArgumentNullException("No matching search !");
                }

                existingArticle.Stock = stock;

                _ctx.Article.Update(existingArticle);

                await _ctx.SaveChangesAsync();

                _logger.LogInformation("Updated stock of article with ID {ArticleId} to {Stock}", id, existingArticle.Stock);

                return $"Mis à jour du stock de l'article id : {id}, nouveau stock : '{existingArticle.Stock}'";
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
                {
                    _logger.LogWarning("Article with ID : {id} not found", id);

                    throw new ArgumentNullException("No matching search !");
                }

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
