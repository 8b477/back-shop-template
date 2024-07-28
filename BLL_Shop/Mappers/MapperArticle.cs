using BLL_Shop.DTO.Article.Create;

using Database_Shop.Entity;


namespace BLL_Shop.Mappers
{
    internal static class MapperArticle
    {
        internal static Article FromArticleCreateDTOToEntity(ArticleCreateDTO articleDTO)
        {
            return new Article
            {
                Name = articleDTO.Name,
                Price = articleDTO.Price,
                Promo = articleDTO.Promo,
                Stock = articleDTO.Stock
            };
        }
    }
}
