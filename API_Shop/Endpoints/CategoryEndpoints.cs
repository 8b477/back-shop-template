using BLL_Shop.DTO.Category.Create;
using BLL_Shop.DTO.Category.Update;
using BLL_Shop.Interfaces;

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
                async ([FromServices] ICategoryService categoryService, [FromBody] CategoryCreateDTO category)
                    => await categoryService.CreateCategory(category));



            // GET
            app.MapGet("/category", [Authorize(Policy = "UserOrAdmin")]
                async ([FromServices] ICategoryService categoryService)
                    => await categoryService.GetAllCategories());

            app.MapGet("/category/{id:int}", [Authorize(Policy = "UserOrAdmin")]
                async ([FromServices] ICategoryService categoryService,[FromRoute] int id)
                    => await categoryService.GetCategoryById(id));



            // UPDATE
            app.MapPut("/category/{id:int}", [Authorize(Policy = "AdminOnly")]
                async ([FromServices] ICategoryService categoryService,[FromRoute] int id, [FromBody] CategoryUpdateDTO categoryNameToUpdate)
                    => await categoryService.UpdateCategory(id, categoryNameToUpdate));



            // DELETE
            app.MapDelete("/category/{id:int}", [Authorize(Policy = "AdminOnly")]
                async ([FromServices] ICategoryService categoryService,[FromRoute] int id)
                    => await categoryService.DeleteCategory(id));



        }
    }
}
