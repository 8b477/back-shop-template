

namespace BLL_Shop.DTO.Article.Update
{
    public record ArticleNameUpdateDTO
    {
        public ArticleNameUpdateDTO(string name) =>  Name = name;

        public string Name { get; init; }
    }
}
