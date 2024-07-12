using Database_Shop.Entity;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Database_Shop.EntityConfigurations
{
    internal class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder
                .HasMany(c => c.ArticleCategories)
                .WithOne(ac => ac.Category)
                .HasForeignKey(ac => ac.CategoryId);


            builder.HasData(
                new Category
                {
                    Id = 1,
                    Name = "Catégorie 1"
                },
                new Category
                {
                    Id = 2,
                    Name = "Catégorie 2"
                },
                new Category
                {
                    Id = 3,
                    Name = "Catégorie 3"
                }
            );
        }
    }
}