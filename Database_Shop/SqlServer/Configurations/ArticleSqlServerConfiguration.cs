using Database_Shop.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Database_Shop.SqlServer.Configurations
{
    internal class ArticleSqlServerConfiguration : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Name)
                .IsRequired()
                .HasColumnName("Name")
                .HasColumnType("NVARCHAR(50)")
                .HasMaxLength(50)
                .HasAnnotation("MinLength", 1)
                .HasComment("Nom de l'article");

            builder.Property(a => a.Stock)
                .IsRequired()
                .HasColumnName("Stock")
                .HasColumnType("INT")
                .HasAnnotation("Range", new[] { 0, 10000 })
                .HasComment("Nombre d'articles en stock");

            builder.Property(a => a.Promo)
                .IsRequired()
                .HasColumnName("Promo")
                .HasColumnType("BIT")
                .HasComment("Article en promotion");

            builder.Property(a => a.Price)
                .IsRequired()
                .HasColumnName("Price")
                .HasColumnType("DECIMAL(18,2)")
                .HasAnnotation("Range", new[] { 0, 200 })
                .HasComment("Prix de l'article");

            builder.HasMany(a => a.ArticleCategories)
                .WithOne(ac => ac.Article)
                .OnDelete(DeleteBehavior.Cascade)
                .HasForeignKey(ac => ac.ArticleId);


            builder.HasData(
                 new Article
                 {
                     Id = 1,
                     Name = "Tomate",
                     Stock = 100,
                     Promo = false,
                     Price = 0.25
                 },
                new Article
                {
                    Id = 2,
                    Name = "Banane",
                    Stock = 50,
                    Promo = true,
                    Price = 1.30
                },
                new Article
                {
                    Id = 3,
                    Name = "Vodka",
                    Stock = 20,
                    Promo = false,
                    Price = 14.95
                },
                new Article
                {
                    Id = 4,
                    Name = "Chips Lays Nature",
                    Stock = 10,
                    Promo = false,
                    Price = 2.95
                },
                new Article
                {
                    Id = 5,
                    Name = "Chips Lays Paprika",
                    Stock = 200,
                    Promo = false,
                    Price = 4.99
                },
                new Article
                {
                    Id = 6,
                    Name = "Fritte",
                    Stock = 200,
                    Promo = false,
                    Price = 4.99
                },
                new Article
                {
                    Id = 7,
                    Name = "Thon",
                    Stock = 15,
                    Promo = false,
                    Price = 3.95
                }
            );
        }
    }
}