using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StockApp.Domain.Entities;
using BCrypt.Net;

namespace StockApp.Infra.Data.EntityConfiguration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Username)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(u => u.PasswordHash)
                .HasMaxLength(100)
                .IsRequired();

            Func<string, string> hashPassword = (password) =>
            {
                return BCrypt.Net.BCrypt.HashPassword(password);
            };

            builder.HasData(
                new User
                {
                    Id = -1,
                    Username = "admin",
                    PasswordHash = hashPassword("admin"),
                    Role = "admin"
                }
            );
        }
    }
}
