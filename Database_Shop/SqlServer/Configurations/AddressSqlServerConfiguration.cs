using Database_Shop.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Database_Shop.SqlServer.Configurations
{
    internal class AddressSqlServerConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("Address");
            builder.HasKey(a => a.Id);

            builder.Property(a => a.PhoneNumber)
                .IsRequired(false)
                .HasColumnName("PhoneNumber")
                .HasColumnType("NVARCHAR(20)")
                .HasMaxLength(20)
                .HasComment("Numéro de téléphone");

            builder.Property(a => a.PostalCode)
                .IsRequired()
                .HasColumnName("PostalCode")
                .HasColumnType("NVARCHAR(20)")
                .HasMaxLength(20)
                .HasComment("Code postal")
                .HasAnnotation("MinLength", 1);

            builder.Property(a => a.StreetNumber)
                .IsRequired()
                .HasColumnName("StreetNumber")
                .HasColumnType("NVARCHAR(20)")
                .HasMaxLength(20)
                .HasComment("Numéro de rue")
                .HasAnnotation("MinLength", 1);

            builder.Property(a => a.StreetName)
                .IsRequired()
                .HasColumnName("StreetName")
                .HasColumnType("NVARCHAR(50)")
                .HasMaxLength(50)
                .HasComment("Nom de rue")
                .HasAnnotation("MinLength", 1);

            builder.Property(a => a.Country)
                .IsRequired()
                .HasColumnName("Country")
                .HasColumnType("NVARCHAR(50)")
                .HasMaxLength(50)
                .HasComment("Pays")
                .HasAnnotation("MinLength", 1);

            builder.Property(a => a.City)
                .IsRequired()
                .HasColumnName("City")
                .HasColumnType("NVARCHAR(50)")
                .HasMaxLength(50)
                .HasComment("Ville")
                .HasAnnotation("MinLength", 1);

            builder.HasOne(a => a.User)
                .WithOne(u => u.Address)
                .HasForeignKey<Address>(a => a.UserId)
                .OnDelete(DeleteBehavior.Cascade);


            builder.HasData(
                 new Address
                 {
                     Id = 1,
                     PhoneNumber = "",
                     PostalCode = "6000",
                     StreetNumber = "10",
                     StreetName = "rue de la Force",
                     Country = "Belgique",
                     City = "Charleroi",
                     UserId = 1
                 },
                new Address
                {
                    Id = 2,
                    PhoneNumber = "0687654321",
                    PostalCode = "69001",
                    StreetNumber = "5",
                    StreetName = "rue des fous",
                    Country = "France",
                    City = "Lille",
                    UserId = 2
                },
                new Address
                {
                    Id = 3,
                    PhoneNumber = "",
                    PostalCode = "5670",
                    StreetNumber = "5",
                    StreetName = "rue longue",
                    Country = "Belgique",
                    City = "Nismes",
                    UserId = 3
                }
            );
        }
    }
}