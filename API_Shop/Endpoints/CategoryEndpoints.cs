using BLL_Shop.Services;

using Database_Shop.Entity;

namespace API_Shop.Endpoints
{
    public class CategoryEndpoints
    {
        public static void GetEndpointsCategory(WebApplication app)
        {

            // ADD
            app.MapPost("/category",
                async (CategoryService categoryService, Category category) => await categoryService.CreateCategory(category));


            // GET
            app.MapGet("/category",
                async (CategoryService categoryService) => await categoryService.GetAllCategories());

            app.MapGet("/category/{id:int}",
                async (CategoryService categoryService, int id) => await categoryService.GetCategoryById(id));


            // UPDATE
            app.MapPut("/category/{id:int}/{name}",
                async(CategoryService categoryService, int id, string name) => await categoryService.UpdateCategory(id, name));


            //DELETE
            app.MapDelete("/category/{id:int}",
                async (CategoryService categoryService, int id) => await categoryService.DeleteCategory(id));

        }
    }
}
