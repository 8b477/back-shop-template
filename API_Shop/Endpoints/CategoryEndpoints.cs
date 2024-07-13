using BLL_Shop.Interfaces;
using Database_Shop.Entity;

using Microsoft.AspNetCore.Mvc;

namespace API_Shop.Endpoints
{
    public class CategoryEndpoints
    {
        public static void GetEndpointsCategory(WebApplication app)
        {
            // ADD
            app.MapPost("/category",
                async ([FromServices] ICategoryService categoryService, [FromBody] Category category) => await categoryService.CreateCategory(category));

            // GET
            app.MapGet("/category",
                async ([FromServices] ICategoryService categoryService) => await categoryService.GetAllCategories());

            app.MapGet("/category/{id:int}",
                async ([FromServices] ICategoryService categoryService, int id) => await categoryService.GetCategoryById(id));

            // UPDATE
            app.MapPut("/category/{id:int}",
                async ([FromServices] ICategoryService categoryService, int id, [FromBody] string name) => await categoryService.UpdateCategory(id, name));

            // DELETE
            app.MapDelete("/category/{id:int}",
                async ([FromServices] ICategoryService categoryService, int id) => await categoryService.DeleteCategory(id));
        }
    }
}
