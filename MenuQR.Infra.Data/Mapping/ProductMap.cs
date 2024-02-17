using MenuQR.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MenuQR.Infra.Data.Mapping
{
    internal class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");

            builder.HasKey(prop => new { prop.Id, prop.CompanyId });

            builder.Property(prop => prop.Id)
                .ValueGeneratedOnAdd();

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

            builder.Property(prop => prop.Active)
                .IsRequired()
                .HasColumnName("Active")
                .HasColumnType("bit");

            builder.Property(prop => prop.Image)
               .HasColumnName("Image")
               .HasColumnType("varchar(MAX)");

            builder.HasData(new Product() { Id = 1, CompanyId = 1, Image = "Teste", Name = "Pão", Price = 10.5, Description = "Pão artesanal" });

        }
    }
}
