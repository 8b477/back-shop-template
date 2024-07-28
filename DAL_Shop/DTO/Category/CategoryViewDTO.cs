

namespace DAL_Shop.DTO.Category
{
    public record CategoryViewDTO
    {
        public CategoryViewDTO(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; init; }
        public string Name { get; init; }
    }
}
