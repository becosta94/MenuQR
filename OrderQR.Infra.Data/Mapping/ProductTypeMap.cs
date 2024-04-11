using OrderQR.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OrderQR.Infra.Data.Mapping
{
    public class ProductTypeMap : IEntityTypeConfiguration<ProductType>
    {
        public void Configure(EntityTypeBuilder<ProductType> builder)
        {
            builder.ToTable("ProductType");

            builder.HasKey(prop => new { prop.Id, prop.CompanyId });

            builder.Property(prop => prop.Id)
                .ValueGeneratedOnAdd();

            builder.Property(prop => prop.CreatedAt)
                .IsRequired()
                .HasColumnName("CreatedAt")
                .HasColumnType("datetime2");

            builder.Property(prop => prop.TypeName)
                .IsRequired()
                .HasColumnName("TypeName")
                .HasColumnType("varchar(200)");

            builder.HasData(new ProductType() { Id = 1, CompanyId = 1, TypeName = "Petiscos" });
            builder.HasData(new ProductType() { Id = 2, CompanyId = 1, TypeName = "Pratos" });
            builder.HasData(new ProductType() { Id = 3, CompanyId = 1, TypeName = "Bebida não alcoolicas" });
            builder.HasData(new ProductType() { Id = 4, CompanyId = 1, TypeName = "Bebida alcoolicas" });
        }
    }
}
