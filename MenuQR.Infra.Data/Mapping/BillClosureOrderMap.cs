using MenuQR.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MenuQR.Infra.Data.Mapping
{
    public class BillClosureOrderMap : IEntityTypeConfiguration<BillClosureOrder>
    {
        public void Configure(EntityTypeBuilder<BillClosureOrder> builder)
        {
            builder.ToTable("BillClosureOrder");

            builder.HasKey(prop => prop.Id);

            builder.Property(prop => prop.CompanyId)
               .IsRequired()
               .HasColumnName("CompanyId")
               .HasColumnType("int");

            builder.Property(prop => prop.CreatedAt)
               .IsRequired()
               .HasColumnName("CreatedAt")
               .HasColumnType("datetime2");

            builder.Property(prop => prop.Value)
               .IsRequired()
               .HasColumnName("Value")
               .HasColumnType("float");

            builder.Property(prop => prop.TableId)
               .IsRequired()
               .HasColumnName("TableId")
               .HasColumnType("int");

            builder.Property(prop => prop.CloseTotal)
               .IsRequired()
               .HasColumnName("CloseTotal")
               .HasColumnType("bit");

            builder.Property(prop => prop.OrderCompleted)
               .IsRequired()
               .HasColumnName("OrderCompleted")
               .HasColumnType("bit");

            builder.Property(prop => prop.CustomerDocument)
               .IsRequired()
               .HasColumnName("CustomerDocument")
               .HasColumnType("varchar(50)");

            builder.HasIndex(prop => prop.CompanyId)
                .HasDatabaseName("IX_Order_Company");

            builder.HasOne(prop => prop.Customer)
                .WithMany()
                .HasForeignKey(prop => prop.CustomerDocument);

            builder.HasOne(prop => prop.Table)
                .WithMany();
        }
    }
}
