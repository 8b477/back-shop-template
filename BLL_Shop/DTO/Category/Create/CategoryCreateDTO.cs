

namespace BLL_Shop.DTO.Category.Create
{
    public record CategoryCreateDTO
    {
        public CategoryCreateDTO(string name) => Name = name;

        public string Name { get; init; }
    }
}
