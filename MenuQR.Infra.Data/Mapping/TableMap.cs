using MenuQR.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MenuQR.Infra.Data.Mapping
{
    public class TableMap : IEntityTypeConfiguration<Table>
    {
        public void Configure(EntityTypeBuilder<Table> builder)
        {
            builder.ToTable("Table");

            builder.HasKey(prop => prop.Id);

            builder.Property(prop => prop.CompanyId)
               .IsRequired()
               .HasColumnName("CompanyId")
               .HasColumnType("int");

            builder.Property(prop => prop.Identification)
                   .IsRequired()
                   .HasColumnName("CompanyId")
                   .HasColumnType("varchar(100)");

            builder.HasIndex(prop => prop.CompanyId)
                .HasDatabaseName("IX_Order_Company");

        }
    }
}
