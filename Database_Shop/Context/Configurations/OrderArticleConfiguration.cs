using Database_Shop.Entity;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Database_Shop.Context.Configurations
{
    internal class OrderArticleConfiguration : IEntityTypeConfiguration<OrderArticle>
    {
        public void Configure(EntityTypeBuilder<OrderArticle> builder)
        {
            // Défini clé primaire composite
            builder.HasKey(oa => new { oa.OrderId, oa.ArticleId });

            // Configure la relation avec Order
            builder.HasOne(oa => oa.Order)
                .WithMany(o => o.OrderArticles)
                .HasForeignKey(oa => oa.OrderId);

            // Configure la relation avec Article
            builder.HasOne(oa => oa.Article)
                .WithMany(a => a.OrderArticles)
                .HasForeignKey(oa => oa.ArticleId);



            builder.HasData(
                new OrderArticle { OrderId = 1, ArticleId = 1 },
                new OrderArticle { OrderId = 1, ArticleId = 2 },
                new OrderArticle { OrderId = 2, ArticleId = 2 },
                new OrderArticle { OrderId = 2, ArticleId = 3 }
            );
        }
    }
}
