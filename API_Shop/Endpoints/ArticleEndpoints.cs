using BLL_Shop.Interfaces;
using Database_Shop.Entity;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API_Shop.Endpoints
{
    public class ArticleEndpoints
    {
        public static void GetEndpointsArticle(WebApplication app)
        {



            // ADD (ADMIN)
            app.MapPost("/article", [Authorize(Policy = "AdminOnly")]
                async ([FromServices] IArticleService articleService, [FromBody] Article article)
                    => await articleService.CreateArticle(article));




            // GET (ALLOWED)
/*ALL*/     app.MapGet("/article",
                async ([FromServices] IArticleService articleService) => await articleService.GetAllArticles());

/*ONE*/     app.MapGet("/article/{id:int}",
                async ([FromServices] IArticleService articleService, int id) => await articleService.GetArticleById(id));

/*NAME*/    app.MapGet("/article/{categoryName}",
                async ([FromServices] IArticleService articleService, string categoryName) => await articleService.GetArticleByCategory(categoryName));




            // UPDATE (ADMIN)
/*FULL*/    app.MapPut("/article/{id:int}",[Authorize(Policy = "AdminOnly")]
                async ([FromServices] IArticleService articleService, int id, [FromBody] Article article)
                    => await articleService.UpdateArticle(id, article));

/*NAME*/    app.MapPut("/article/name/{id:int}", [Authorize(Policy = "AdminOnly")]
                async ([FromServices] IArticleService articleService, int id, [FromBody] string name)
                    => await articleService.UpdateArticleName(id, name));

/*PRICE*/   app.MapPut("/article/price/{id:int}", [Authorize(Policy = "AdminOnly")]
                async ([FromServices] IArticleService articleService, int id, [FromBody] int price) 
                    => await articleService.UpdateArticlePrice(id, price));

/*STOCK*/   app.MapPut("/article/stock/{id:int}", [Authorize(Policy = "AdminOnly")]
                async ([FromServices] IArticleService articleService, int id, [FromBody] int stock) 
                    => await articleService.UpdateArticleStock(id, stock));

/*PROMO*/   app.MapPut("/article/promo/{id:int}", [Authorize(Policy = "AdminOnly")]
                async ([FromServices] IArticleService articleService, int id, [FromBody] bool promo) 
                => await articleService.UpdateArticlePromo(id, promo));




            // DELETE (ADMIN)
            app.MapDelete("/article/{id:int}", [Authorize(Policy = "AdminOnly")]
                async ([FromServices] IArticleService articleService, int id)
                    => await articleService.DeleteArticle(id));



        }
    }
}
