using BLL_Shop.Services;

using Database_Shop.Entity;

namespace API_Shop.Endpoints
{
    public class ArticleEndpoints
    {
        public static void GetEndpointsArticle(WebApplication app)
        {

            // ADD
            app.MapPost("/article",
                async (ArticleService articleService, Article article) => await articleService.CreateArticle(article));

            // GET
            app.MapGet("/article",
                async (ArticleService articleService) => await articleService.GetAllArticles());

            app.MapGet("/article/{id:int}",
                async (ArticleService articleService, int id) => await articleService.GetArticleById(id));

            app.MapGet("/article/{categoryName}",
                async (ArticleService articleService, string categoryName) => await articleService.GetArticleByCategory(categoryName));


            // UPDATE
            app.MapPut("/article/{id:int}",
                async (ArticleService articleService, int id, Article article) => await articleService.UpdateArticle(id, article));

            app.MapPut("/article/name/{id:int}/{name}",
                async (ArticleService articleService,int id, string name) => await articleService.UpdateArticleName(id, name));

            app.MapPut("/article/price/{id:int}/{price:int}",
                async (ArticleService articleService, int id, int price) => await articleService.UpdateArticlePrice(id, price));

            app.MapPut("/article/stock/{id:int}/{stock:int}",
                async (ArticleService articleService, int id, int stock) => await articleService.UpdateArticleStock(id, stock));

            app.MapPut("/article/promo/{id:int}/{promo}",
                async (ArticleService articleService, int id, bool promo) => await articleService.UpdateArticlePromo(id, promo));

            //DELETE
            app.MapDelete("/article/{id:int}",
                async (ArticleService articleService, int id) => await articleService.DeleteArticle(id));
        }
    }
}
