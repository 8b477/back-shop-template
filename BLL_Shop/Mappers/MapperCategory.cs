using BLL_Shop.DTO.Category.Create;
using BLL_Shop.DTO.Category.Update;

using Database_Shop.Entity;


namespace BLL_Shop.Mappers
{
    internal static class MapperCategory
    {

        internal static Category DTOToEntity(CategoryCreateDTO category)
        {
            return new Category
            {
                Name = category.Name
            };
        }


    }
}
