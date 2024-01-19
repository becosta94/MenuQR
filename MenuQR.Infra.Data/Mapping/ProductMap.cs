using MenuQR.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Hosting;
using System.Reflection.Emit;

namespace MenuQR.Infra.Data.Mapping
{
    internal class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");

            builder.HasKey(prop => prop.Id);

            builder.Property(prop => prop.Name)
                .IsRequired()
                .HasColumnName("Name")
                .HasColumnType("varchar(200)");

            builder.Property(prop => prop.Description)
               .HasColumnName("Description")
               .HasColumnType("varchar(1000)");

            builder.Property(prop => prop.Price)
                .IsRequired()
                .HasColumnName("Price")
                .HasColumnType("decimal(6,2)");

            builder.Property(prop => prop.Image)
               .HasColumnName("Image")
               .HasColumnType("varchar(MAX)");

        }
    }
}
