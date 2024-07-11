using Database_Shop.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Database_Shop.EntityConfigurations
{
    internal class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("Addresses");

            builder.HasKey(a => a.Id);

            builder.Property(a => a.PhoneNumber)
                .IsRequired()
                .HasColumnName("PhoneNumber")
                .HasColumnType("TEXT")
                .HasComment("Numéro de téléphone");

            builder.Property(a => a.PostalCode)
                .IsRequired()
                .HasColumnName("PostalCode")
                .HasColumnType("TEXT")
                .HasDefaultValue(0)
                .HasComment("Code postal");

            builder.Property(a => a.StreetNumber)
                .IsRequired()
                .HasColumnName("StreetNumber")
                .HasColumnType("TEXT")
                .HasDefaultValue(0)
                .HasComment("Numéro de rue");

            builder.Property(a => a.Country)
                .IsRequired()
                .HasMaxLength(35)
                .HasColumnName("Country")
                .HasComment("Pays");

            builder.Property(a => a.City)
                .IsRequired()
                .HasMaxLength(85)
                .HasColumnName("City")
                .HasComment("Ville");

            builder.HasOne(a => a.User)
                .WithOne(u => u.Address)
                .HasForeignKey<Address>(a => a.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}