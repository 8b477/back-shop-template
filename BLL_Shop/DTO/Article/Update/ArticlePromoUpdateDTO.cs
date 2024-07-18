
namespace BLL_Shop.DTO.Article.Update
{
    public record ArticlePromoUpdateDTO
    {
        public ArticlePromoUpdateDTO(bool promo) => Promo = promo;


        public required bool Promo { get; init; }
    }
}
