using Database_Shop.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Database_Shop.SqlLite.Configurations
{
    internal class UserSqlLiteConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Pseudo)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("Pseudo")
                .HasColumnType("TEXT")
                .HasComment("Pseudo de l'utilisateur")
                .HasAnnotation("MinLength", 2);

            builder.Property(u => u.Mail)
                .IsRequired()
                .HasColumnName("Mail")
                .HasColumnType("TEXT")
                .HasComment("Email de l'utilisateur");

            builder.Property(u => u.Pwd)
                .IsRequired()
                .HasColumnName("Password")
                .HasColumnType("TEXT")
                .HasComment("Password de l'utilisateur");

            builder.Property(u => u.Role)
                .IsRequired()
                .HasColumnName("Role")
                .HasColumnType("TEXT")
                .HasDefaultValue("User")
                .HasComment("Rôle de l'utilisateur");

            builder.HasOne(u => u.Address)
                .WithOne(a => a.User)
                .HasForeignKey<Address>(a => a.UserId)
                .OnDelete(DeleteBehavior.Cascade);


            builder.HasData(
             new User
             {
                 Id = 1,
                 Pseudo = "admin",
                 Mail = "admin@mail.be",
                 Pwd = BCrypt.Net.BCrypt.HashPassword("Test1234*"),
                 Role = "Admin"
             },
             new User
             {
                 Id = 2,
                 Pseudo = "user",
                 Mail = "user@mail.be",
                 Pwd = BCrypt.Net.BCrypt.HashPassword("Test1234*"),
                 Role = "User"
             },
             new User
             {
                 Id = 3,
                 Pseudo = "user2",
                 Mail = "user2@mail.be",
                 Pwd = BCrypt.Net.BCrypt.HashPassword("Test1234*"),
                 Role = "User"
             },
             new User
             {
                 Id = 4,
                 Pseudo = "user3",
                 Mail = "user3@mail.be",
                 Pwd = BCrypt.Net.BCrypt.HashPassword("Test1234*"),
                 Role = "User"
             },
             new User
             {
                 Id = 5,
                 Pseudo = "user4",
                 Mail = "user4@mail.be",
                 Pwd = BCrypt.Net.BCrypt.HashPassword("Test1234*"),
                 Role = "User"
             }
         );

        }
    }
}
