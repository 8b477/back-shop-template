using Database_Shop.Entity;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Database_Shop.EntityConfigurations
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
        }
    }
}
