using DAL_Shop.DTO.Article;
using DAL_Shop.DTO.Category;

using Database_Shop.Entity;

using System.Collections.Generic;

namespace DAL_Shop.Mapper
{
    internal static class MapperArticle
    {
        internal static ArticleViewDTO EntityToViewDTO(Article article)
        {
            var debug = article;

            return new ArticleViewDTO
            (
                article.Id,
                article.Name,
                article.Stock,
                article.Promo,
                article.Price,
                article.ArticleCategories.Where(ac => ac.ArticleId == article.Id).Select(ac =>
                new CategoryViewDTO
                (
                    ac.Id,
                    ac.Category.Name
                )).ToList()
            );
        }

        internal static List<ArticleViewDTO> EntityToViewDTO(List<Article> articles)
        {
            List<ArticleViewDTO> list = [];

            foreach (Article a in articles)
            {
                list.Add(EntityToViewDTO(a));
            }
            return list;
        }
    }
}
