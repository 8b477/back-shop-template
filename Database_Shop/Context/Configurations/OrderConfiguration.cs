using Database_Shop.Entity;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Database_Shop.Context.Configurations
{
    internal class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");

            builder.HasKey(o => o.Id);

            builder.Property(o => o.Status)
                   .HasMaxLength(50)
                   .IsRequired();

            builder.Property(o => o.CreatedAt)
                   .HasColumnType("TEXT")
                   .IsRequired();

            builder.Property(o => o.SentAt)
                   .HasColumnType("TEXT");

            builder.HasOne(o => o.User)
                   .WithMany(u => u.Orders)
                   .HasForeignKey(o => o.UserId)
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
