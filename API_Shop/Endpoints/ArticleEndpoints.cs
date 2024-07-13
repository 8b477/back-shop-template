using BLL_Shop.Interfaces;
using Database_Shop.Entity;
using Microsoft.AspNetCore.Mvc;

namespace API_Shop.Endpoints
{
    public class ArticleEndpoints
    {
        public static void GetEndpointsArticle(WebApplication app)
        {
            // ADD
            app.MapPost("/article",
                async ([FromServices] IArticleService articleService, [FromBody] Article article) => await articleService.CreateArticle(article));

            // GET
            app.MapGet("/article",
                async ([FromServices] IArticleService articleService) => await articleService.GetAllArticles());

            app.MapGet("/article/{id:int}",
                async ([FromServices] IArticleService articleService, int id) => await articleService.GetArticleById(id));

            app.MapGet("/article/{categoryName}",
                async ([FromServices] IArticleService articleService, string categoryName) => await articleService.GetArticleByCategory(categoryName));

            // UPDATE
            app.MapPut("/article/{id:int}",
                async ([FromServices] IArticleService articleService, int id, [FromBody] Article article) => await articleService.UpdateArticle(id, article));

            app.MapPut("/article/name/{id:int}",
                async ([FromServices] IArticleService articleService, int id, [FromBody] string name) => await articleService.UpdateArticleName(id, name));

            app.MapPut("/article/price/{id:int}",
                async ([FromServices] IArticleService articleService, int id, [FromBody] int price) => await articleService.UpdateArticlePrice(id, price));

            app.MapPut("/article/stock/{id:int}",
                async ([FromServices] IArticleService articleService, int id, [FromBody] int stock) => await articleService.UpdateArticleStock(id, stock));

            app.MapPut("/article/promo/{id:int}",
                async ([FromServices] IArticleService articleService, int id, [FromBody] bool promo) => await articleService.UpdateArticlePromo(id, promo));

            // DELETE
            app.MapDelete("/article/{id:int}",
                async ([FromServices] IArticleService articleService, int id) => await articleService.DeleteArticle(id));
        }
    }
}
