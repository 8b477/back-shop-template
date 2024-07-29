using BLL_Shop.DTO.Article.Create;
using BLL_Shop.DTO.Article.Update;
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
            async ([FromServices] IArticleService articleService, [FromBody] ArticleCreateDTO article)
                    => await articleService.CreateArticle(article));




            // GET (ALLOWED)
/*ALL*/     app.MapGet("/article",
                async ([FromServices] IArticleService articleService) => await articleService.GetAllArticles());

/*ONE*/     app.MapGet("/article/{id:int}",
                async ([FromServices] IArticleService articleService, [FromRoute] int id) => await articleService.GetArticleById(id));

/*NAME*/    app.MapGet("/article/{categoryName}",
                async ([FromServices] IArticleService articleService,[FromRoute] string categoryName) => await articleService.GetArticleByCategory(categoryName));




            // UPDATE (ADMIN)
/*FULL*/    app.MapPut("/article/{id:int}",[Authorize(Policy = "AdminOnly")]
                async ([FromServices] IArticleService articleService, [FromRoute] int id, [FromBody] ArticleUpdateDTO article)
                    => await articleService.UpdateArticle(id, article));

/*NAME*/    app.MapPut("/article/name/{id:int}", [Authorize(Policy = "AdminOnly")]
                async ([FromServices] IArticleService articleService, [FromRoute] int id, [FromBody] ArticleNameUpdateDTO articleNameToUpdate)
                    => await articleService.UpdateArticleName(id, articleNameToUpdate));

/*PRICE*/   app.MapPut("/article/price/{id:int}", [Authorize(Policy = "AdminOnly")]
                async ([FromServices] IArticleService articleService, [FromRoute] int id, [FromBody] ArticlePriceUpdateDTO articlePriceToUpdate) 
                    => await articleService.UpdateArticlePrice(id, articlePriceToUpdate));

/*STOCK*/   app.MapPut("/article/stock/{id:int}", [Authorize(Policy = "AdminOnly")]
                async ([FromServices] IArticleService articleService, [FromRoute] int id, [FromBody] ArticleStockUpdateDTO articleStockToUpdate) 
                    => await articleService.UpdateArticleStock(id, articleStockToUpdate));

/*PROMO*/   app.MapPut("/article/promo/{id:int}", [Authorize(Policy = "AdminOnly")]
                async ([FromServices] IArticleService articleService, [FromRoute] int id, [FromBody] ArticlePromoUpdateDTO articlePromoToUpdate) 
                => await articleService.UpdateArticlePromo(id, articlePromoToUpdate));




            // DELETE (ADMIN)
            app.MapDelete("/article/{id:int}", [Authorize(Policy = "AdminOnly")]
                async ([FromServices] IArticleService articleService, [FromRoute] int id)
                    => await articleService.DeleteArticle(id));



        }
    }
}
