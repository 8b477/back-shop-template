using BLL_Shop.DTO.Category.Create;
using Database_Shop.Entity;


namespace BLL_Shop.Mappers
{
    internal static class MapperCategory
    {

        internal static Category DtoToEntity(CategoryCreateDTO category)
        {
            return new Category
            {
                Name = category.Name
            };
        }


    }
}
