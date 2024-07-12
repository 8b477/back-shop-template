using Database_Shop.Entity;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Database_Shop.EntityConfigurations
{
    internal class ArticleConfiguration : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(a => a.Stock)
                .IsRequired()
                .HasDefaultValue(0);

            builder.Property(a => a.Promo)
                .IsRequired();

            builder.Property(a => a.Price)
                .IsRequired()
                .HasDefaultValue(0);

            builder.HasMany(a => a.ArticleCategories)
                .WithOne(ac => ac.Article)
                .HasForeignKey(ac => ac.ArticleId);


            builder.HasData(
                 new Article
                 {
                     Id = 1,
                     Name = "Article 1",
                     Stock = 10,
                     Promo = false,
                     Price = 50
                 },
                new Article
                {
                    Id = 2,
                    Name = "Article 2",
                    Stock = 5,
                    Promo = true,
                    Price = 30
                },
                new Article
                {
                    Id = 3,
                    Name = "Article 3",
                    Stock = 20,
                    Promo = false,
                    Price = 75
                }
            );
        }
    }
}