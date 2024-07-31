using Database_Shop.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Database_Shop.SqlServer.Configurations
{
    internal class ArticleCategorySqlServerConfiguration : IEntityTypeConfiguration<ArticleCategory>
    {
        public void Configure(EntityTypeBuilder<ArticleCategory> builder)
        {
            builder.HasKey(a => a.Id);

            builder
                .HasOne(ac => ac.Article)
                .WithMany(a => a.ArticleCategories)
                .HasForeignKey(ac => ac.ArticleId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(ac => ac.Category)
                .WithMany(c => c.ArticleCategories)
                .HasForeignKey(ac => ac.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);



            builder.HasData(
                 new ArticleCategory // TOMATE
                 {
                     Id = 1,
                     ArticleId = 1,
                     CategoryId = 4
                 },
                new ArticleCategory
                {
                    Id = 2,
                    ArticleId = 1,
                    CategoryId = 6
                },
                new ArticleCategory
                {
                    Id = 3,
                    ArticleId = 1,
                    CategoryId = 7
                },                   // ****



                new ArticleCategory // BANANE
                {
                    Id = 4,
                    ArticleId = 2,
                    CategoryId = 4
                },
                new ArticleCategory
                {
                    Id = 5,
                    ArticleId = 2,
                    CategoryId = 7
                },                   // ****



                new ArticleCategory // VODKA
                {
                    Id = 6,
                    ArticleId = 3,
                    CategoryId = 1
                },
                new ArticleCategory
                {
                    Id = 7,
                    ArticleId = 3,
                    CategoryId = 2
                },                   // ****



                new ArticleCategory // CHIPS LAYS NATURE
                {
                    Id = 8,
                    ArticleId = 4,
                    CategoryId = 3
                },
                new ArticleCategory
                {
                    Id = 9,
                    ArticleId = 4,
                    CategoryId = 8
                },                   // ****



                new ArticleCategory // CHIPS LAYS PAPRIKA
                {
                    Id = 10,
                    ArticleId = 5,
                    CategoryId = 3
                },
                new ArticleCategory
                {
                    Id = 11,
                    ArticleId = 5,
                    CategoryId = 8
                },                   // ****



                new ArticleCategory // FRITTE
                {
                    Id = 12,
                    ArticleId = 6,
                    CategoryId = 5
                },                  // ****



                new ArticleCategory // THON
                {
                    Id = 13,
                    ArticleId = 7,
                    CategoryId = 9
                }
            // ****


            );
        }
    }
}
