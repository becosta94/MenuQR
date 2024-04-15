using OrderQR.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderQR.Infra.Data.Mapping
{
    public class BillMap : IEntityTypeConfiguration<Bill>
    {
        public void Configure(EntityTypeBuilder<Bill> builder)
        {
            builder.ToTable("Bill");

            builder.HasKey(prop => new { prop.Id, prop.CompanyId });

            builder.Property(prop => prop.Id)
                .ValueGeneratedOnAdd();

            builder.Property(prop => prop.CompanyId)
               .IsRequired()
               .HasColumnName("CompanyId")
               .HasColumnType("int");

            builder.Property(prop => prop.CreatedAt)
               .IsRequired()
               .HasColumnName("CreatedAt")
               .HasColumnType("datetime2");

            builder.Property(prop => prop.ClosingDate)
               .HasColumnName("ClosingDate")
               .HasColumnType("datetime2");

            builder.Property(prop => prop.Total)
               .IsRequired()
               .HasColumnName("Total")
               .HasColumnType("decimal(6,2)");

            builder.Property(prop => prop.Profit)
               .IsRequired()
               .HasColumnName("Profit")
               .HasColumnType("decimal(6,2)");

            builder.Property(prop => prop.TableId)
               .IsRequired()
               .HasColumnName("TableId")
               .HasColumnType("int");

            builder.Property(prop => prop.TableCompanyId)
               .IsRequired()
               .HasColumnName("TableCompanyId")
               .HasColumnType("int");

            builder.Property(prop => prop.Open)
               .IsRequired()
               .HasColumnName("OpenBill")
               .HasColumnType("bit");

            builder.HasIndex(prop => prop.CompanyId)
                .HasDatabaseName("IX_Order_Company");

            builder.HasMany(prop => prop.OrderProducts)
                .WithOne(prop => prop.Bill);

            builder.HasMany(prop => prop.ProductOffLists)
                .WithOne(prop => prop.Bill);


        }
    }
}
