using Database_Shop.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Database_Shop.SqlLite.Configurations
{
    internal class OrderArticleSqlLiteConfiguration : IEntityTypeConfiguration<OrderArticle>
    {
        public void Configure(EntityTypeBuilder<OrderArticle> builder)
        {
            builder.HasKey(oa => oa.Id);

            builder.HasOne(oa => oa.Order)
                .WithMany(o => o.OrderArticles)
                .HasForeignKey(oa => oa.OrderId);

            builder.HasOne(oa => oa.Article)
                .WithMany(a => a.OrdersArticles)
                .HasForeignKey(oa => oa.ArticleId);



            builder.HasData(
                new OrderArticle { Id = 1, OrderId = 1, ArticleId = 1 },


                new OrderArticle { Id = 2, OrderId = 2, ArticleId = 1 },
                new OrderArticle { Id = 3, OrderId = 2, ArticleId = 2 },


                new OrderArticle { Id = 4, OrderId = 3, ArticleId = 1 },
                new OrderArticle { Id = 5, OrderId = 3, ArticleId = 2 },
                new OrderArticle { Id = 6, OrderId = 3, ArticleId = 3 },


                new OrderArticle { Id = 7, OrderId = 4, ArticleId = 1 },
                new OrderArticle { Id = 8, OrderId = 4, ArticleId = 2 },
                new OrderArticle { Id = 9, OrderId = 4, ArticleId = 3 },
                new OrderArticle { Id = 10, OrderId = 4, ArticleId = 4 },


                new OrderArticle { Id = 11, OrderId = 5, ArticleId = 1 },
                new OrderArticle { Id = 12, OrderId = 5, ArticleId = 2 },
                new OrderArticle { Id = 13, OrderId = 5, ArticleId = 3 },
                new OrderArticle { Id = 14, OrderId = 5, ArticleId = 4 },
                new OrderArticle { Id = 15, OrderId = 5, ArticleId = 5 },
                new OrderArticle { Id = 16, OrderId = 5, ArticleId = 6 },
                new OrderArticle { Id = 17, OrderId = 5, ArticleId = 7 }


            );
        }
    }
}
