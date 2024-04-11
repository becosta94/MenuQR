using OrderQR.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace OrderQR.Infra.Data.Mapping
{
    public class ProductOffListMap : IEntityTypeConfiguration<ProductOffList>
    {
        public void Configure(EntityTypeBuilder<ProductOffList> builder)
        {
            builder.ToTable("ProductOffList");

            builder.HasKey(prop => new { prop.Id, prop.CompanyId });

            builder.Property(prop => prop.Id)
                .ValueGeneratedOnAdd();

            builder.Property(prop => prop.Amount)
               .IsRequired()
               .HasColumnName("Amount")
               .HasColumnType("int");

            builder.Property(prop => prop.Price)
               .IsRequired()
               .HasColumnName("Price")
               .HasColumnType("decimal(6,2)");

            builder.Property(prop => prop.Name)
               .IsRequired()
               .HasColumnName("Name")
               .HasColumnType("varchar(200)");

            builder.Property(prop => prop.BillId)
               .IsRequired()
               .HasColumnName("BillId")
               .HasColumnType("int");

            builder.Property(prop => prop.BillCompanyId)
               .IsRequired()
               .HasColumnName("BillCompanyId")
               .HasColumnType("int");

            builder.Property(prop => prop.CustomerDocument)
               .IsRequired()
               .HasColumnName("CustomerDocument")
               .HasColumnType("varchar(50)");
        }
    }
}
