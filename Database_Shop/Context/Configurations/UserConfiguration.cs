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

            builder.Property(u => u.Mdp)
                .IsRequired();

            builder.Property(u => u.MdpConfirm)
                .IsRequired();

            builder.Property(u => u.Role);

            builder.HasOne(u => u.Address)
                .WithOne(a => a.User)
                .HasForeignKey<Address>(a => a.UserId);


            builder.HasData(
             new User
             {
                 Id = 1,
                 Pseudo = "user1",
                 Mail = "admin@mail.be",
                 Mdp = "Test1234*",
                 MdpConfirm = "Test1234*",
                 Role = "Admin"
             },
             new User
             {
                 Id = 2,
                 Pseudo = "user",
                 Mail = "user@mail.be",
                 Mdp = "Test1234*",
                 MdpConfirm = "Test1234*",
                 Role = "User"
             },
             new User
             {
                 Id = 3,
                 Pseudo = "user2",
                 Mail = "user2@mail.be",
                 Mdp = "Test1234*",
                 MdpConfirm = "Test1234*",
                 Role = "User"
             }
         );

        }
    }
}
