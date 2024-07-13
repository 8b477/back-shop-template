using Database_Shop.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Database_Shop.Context.Configurations
{
    internal class ArticleCategoryConfiguration : IEntityTypeConfiguration<ArticleCategory>
    {
        public void Configure(EntityTypeBuilder<ArticleCategory> builder)
        {
            builder.HasKey(a => a.Id);

            builder
                .HasOne(ac => ac.Article)
                .WithMany(a => a.ArticleCategories)
                .HasForeignKey(ac => ac.ArticleId);

            builder
                .HasOne(ac => ac.Category)
                .WithMany(c => c.ArticleCategories)
                .HasForeignKey(ac => ac.CategoryId);



            builder.HasData(
                 new ArticleCategory
                 {
                     Id = 1,
                     ArticleId = 1,
                     CategoryId = 1
                 },
                new ArticleCategory
                {
                    Id = 2,
                    ArticleId = 1,
                    CategoryId = 2
                },
                new ArticleCategory
                {
                    Id = 3,
                    ArticleId = 2,
                    CategoryId = 2
                },
                new ArticleCategory
                {
                    Id = 4,
                    ArticleId = 3,
                    CategoryId = 3
                }
            );
        }
    }
}
