using Database_Shop.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Database_Shop.SqlServer.Configurations
{
    internal class UserSqlServerConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Pseudo)
                .IsRequired()
                .HasColumnName("Pseudo")
                .HasColumnType("NVARCHAR(50)")
                .HasMaxLength(50)
                .HasComment("Pseudo de l'utilisateur")
                .HasAnnotation("MinLength", 2);

            builder.Property(u => u.Mail)
                .IsRequired()
                .HasColumnName("Mail")
                .HasComment("Email de l'utilisateur");

            builder.Property(u => u.Pwd)
                .IsRequired()
                .HasColumnName("Password")
                .HasComment("Password de l'utilisateur");

            builder.Property(u => u.Role)
                .IsRequired()
                .HasColumnName("Role")
                .HasColumnType("NVARCHAR(50)")
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
