
namespace BLL_Shop.DTO.Article.Update
{
    public record ArticlePromoUpdateDTO
    {
        public ArticlePromoUpdateDTO(bool promo) => Promo = promo;

        public bool Promo { get; init; }
    }
}
