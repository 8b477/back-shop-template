using BLL_Shop.Interfaces;
using Database_Shop.Entity;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API_Shop.Endpoints
{
    public class CategoryEndpoints
    {
        public static void GetEndpointsCategory(WebApplication app)
        {



            // ADD (ADMIN)
            app.MapPost("/category", [Authorize(Policy = "AdminOnly")]
                async ([FromServices] ICategoryService categoryService, [FromBody] Category category)
                    => await categoryService.CreateCategory(category));



            // GET
            app.MapGet("/category", [Authorize(Policy = "UserOrAdmin")]
                async ([FromServices] ICategoryService categoryService)
                    => await categoryService.GetAllCategories());

            app.MapGet("/category/{id:int}", [Authorize(Policy = "UserOrAdmin")]
                async ([FromServices] ICategoryService categoryService, int id)
                    => await categoryService.GetCategoryById(id));



            // UPDATE
            app.MapPut("/category/{id:int}", [Authorize(Policy = "AdminOnly")]
                async ([FromServices] ICategoryService categoryService, int id, [FromBody] string name)
                    => await categoryService.UpdateCategory(id, name));



            // DELETE
            app.MapDelete("/category/{id:int}", [Authorize(Policy = "AdminOnly")]
                async ([FromServices] ICategoryService categoryService, int id)
                    => await categoryService.DeleteCategory(id));



        }
    }
}
