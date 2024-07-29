

namespace DAL_Shop.DTO.Category
{
    public record CategoryViewDTO
    {
        public CategoryViewDTO(string name)
        {
            Name = name;
        }

        public string Name { get; init; }
    }
}
