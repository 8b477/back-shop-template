using Database_Shop.Entity;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Database_Shop.Context.Configurations
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Pseudo)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(u => u.Mail)
                .IsRequired();

            builder.Property(u => u.Pwd)
                .IsRequired();
            
            builder.Property(u => u.Role);

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
