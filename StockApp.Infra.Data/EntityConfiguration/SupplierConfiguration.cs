using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StockApp.Domain.Entities;

namespace StockApp.Infra.Data.EntityConfiguration
{
    internal class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.ToTable("Suppliers");

            builder.HasKey(s => s.Id);

            builder.Property(s => s.Id)
                .ValueGeneratedOnAdd();

            builder.Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(s => s.ContactEmail)
                .HasMaxLength(100); 

            builder.Property(s => s.PhoneNumber)
                .HasMaxLength(20);

            builder.HasData(
                new Supplier { Id = 1, Name = "Supplier 1", ContactEmail = "contact1@example.com", PhoneNumber = "1234567890" },
                new Supplier { Id = 2, Name = "Supplier 2", ContactEmail = "contact2@example.com", PhoneNumber = "0987654321" }
            );
        }
    }
}
