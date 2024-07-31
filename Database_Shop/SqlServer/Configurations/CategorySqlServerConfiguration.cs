using Database_Shop.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Database_Shop.SqlServer.Configurations
{
    internal class CategorySqlServerConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                .IsRequired()
                .HasColumnName("Name")
                .HasColumnType("NVARCHAR(50)")
                .HasMaxLength(50)
                .HasAnnotation("MinLength", 1);

            builder
                .HasMany(c => c.ArticleCategories)
                .WithOne(ac => ac.Category)
                .HasForeignKey(ac => ac.CategoryId);


            builder.HasData(
                new Category
                {
                    Id = 1,
                    Name = "Boisson"
                },
                new Category
                {
                    Id = 2,
                    Name = "Alcool"
                },
                new Category
                {
                    Id = 3,
                    Name = "Snack"
                },
                new Category
                {
                    Id = 4,
                    Name = "Frais"
                },
                new Category
                {
                    Id = 5,
                    Name = "Surgeler"
                },
                new Category
                {
                    Id = 6,
                    Name = "Légume"
                },
                new Category
                {
                    Id = 7,
                    Name = "Fruit"
                },
                new Category
                {
                    Id = 8,
                    Name = "Sec"
                },
                new Category
                {
                    Id = 9,
                    Name = "Conserve"
                }
            );
        }
    }
}