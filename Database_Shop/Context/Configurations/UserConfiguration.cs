using Database_Shop.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Database_Shop.Configurations
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
        }
    }
}
