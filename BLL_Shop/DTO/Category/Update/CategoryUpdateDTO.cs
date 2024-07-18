

namespace BLL_Shop.DTO.Category.Update
{
    public record CategoryUpdateDTO
    {
        public CategoryUpdateDTO(string name) => Name = name;

        public string Name { get; init; }
    }
}
