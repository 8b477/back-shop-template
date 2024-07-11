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
        }
    }
}