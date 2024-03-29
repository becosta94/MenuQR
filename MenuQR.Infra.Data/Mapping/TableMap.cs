using MenuQR.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MenuQR.Infra.Data.Mapping
{
    public class TableMap : IEntityTypeConfiguration<Table>
    {
        public void Configure(EntityTypeBuilder<Table> builder)
        {
            builder.HasKey(prop => new { prop.Id, prop.CompanyId });

            builder.Property(prop => prop.Id)
                .ValueGeneratedOnAdd();

            builder.Property(prop => prop.Unique)
                   .IsRequired()
                   .HasColumnName("Unique")
                   .HasColumnType("uniqueidentifier");

            builder.Property(prop => prop.CompanyId)
                   .IsRequired()
                   .HasColumnName("CompanyId")
                   .HasColumnType("int");

            builder.Property(prop => prop.Identification)
                   .IsRequired()
                   .HasColumnName("Identification")
                   .HasColumnType("varchar(100)");

            builder.Property(prop => prop.QRLink)
                   .IsRequired()
                   .HasColumnName("QRLink")
                   .HasColumnType("varchar(300)");

            builder.HasIndex(prop => prop.CompanyId)
                .HasDatabaseName("IX_Order_Company");


            builder.HasData(new Table("Mesa1", 0) { Id = 1, CompanyId = 1, Unique = Guid.Parse("440cdeee-5b8a-462a-96fd-20b24bd82f55"), QRLink = "Teste" });

        }
    }
}
