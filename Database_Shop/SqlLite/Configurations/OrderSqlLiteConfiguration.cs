using Database_Shop.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Database_Shop.SqlLite.Configurations
{
    internal class OrderSqlLiteConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Order");

            builder.HasKey(o => o.Id);

            builder.Property(o => o.Status)
                   .IsRequired()
                   .HasMaxLength(50)
                   .HasColumnName("Status")
                   .HasColumnType("TEXT")
                   .HasComment("Status de la commande")
                   .HasAnnotation("MinLength", 2);

            builder.Property(o => o.CreatedAt)
                   .IsRequired()
                   .HasColumnType("TEXT")
                   .HasComment("Date de création");

            builder.Property(o => o.SentAt)
                   .IsRequired(false)
                   .HasColumnName("SentAt")
                   .HasColumnType("TEXT")
                   .HasComment("Date d'envoie");

            builder.HasOne(o => o.User)
                   .WithMany(u => u.Orders)
                   .HasForeignKey(o => o.UserId)
                   .OnDelete(DeleteBehavior.Cascade)
                   .IsRequired();


            builder.HasData(
                new Order
                {
                    Id = 1,
                    UserId = 2,
                    Status = "Sent",
                    CreatedAt = new DateTime(2023, 6, 1),
                    SentAt = new DateTime(2023, 6, 5)
                },
                new Order
                {
                    Id = 2,
                    UserId = 2,
                    Status = "Pending",
                    CreatedAt = new DateTime(2023, 7, 10),
                    SentAt = null
                },
                new Order
                {
                    Id = 3,
                    UserId = 3,
                    Status = "Pending",
                    CreatedAt = new DateTime(2023, 7, 10),
                    SentAt = null
                },
                new Order
                {
                    Id = 4,
                    UserId = 4,
                    Status = "InProgress",
                    CreatedAt = new DateTime(2023, 7, 10),
                    SentAt = new DateTime(2023, 7, 15)
                },
                new Order
                {
                    Id = 5,
                    UserId = 4,
                    Status = "InProgress",
                    CreatedAt = new DateTime(2023, 8, 23),
                    SentAt = new DateTime(2023, 8, 28)
                }
            );
        }
    }
}
