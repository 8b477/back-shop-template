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

            builder.Property(a => a.StreetName)
                .IsRequired()
                .HasColumnName("StreetName")
                .HasColumnType("TEXT")
                .HasMaxLength(50)
                .HasComment("Nom de rue");

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


            builder.HasData(
                 new Address
                 {
                     Id = 1,
                     PhoneNumber = "",
                     PostalCode = 6000,
                     StreetNumber = 10,
                     StreetName = "rue de la Force",
                     Country = "Belgique",
                     City = "Charleroi",
                     UserId = 1
                 },
                new Address
                {
                    Id = 2,
                    PhoneNumber = "0687654321",
                    PostalCode = 69001,
                    StreetNumber = 5,
                    StreetName = "rue des fous",
                    Country = "France",
                    City = "Lille",
                    UserId = 2
                },
                new Address
                {
                    Id = 3,
                    PhoneNumber = "",
                    PostalCode = 5670,
                    StreetNumber = 5,
                    StreetName = "rue longue",
                    Country = "Belgique",
                    City = "Nismes",
                    UserId = 3
                }
            );
        }
    }
}