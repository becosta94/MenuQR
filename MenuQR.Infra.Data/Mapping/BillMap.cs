using MenuQR.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuQR.Infra.Data.Mapping
{
    public class BillMap : IEntityTypeConfiguration<Bill>
    {
        public void Configure(EntityTypeBuilder<Bill> builder)
        {
            builder.ToTable("Bill");

            builder.HasKey(prop => prop.Id);

            builder.Property(prop => prop.CompanyId)
               .IsRequired()
               .HasColumnName("CompanyId")
               .HasColumnType("int");

            builder.Property(prop => prop.Total)
               .IsRequired()
               .HasColumnName("Total")
               .HasColumnType("float");

            builder.Property(prop => prop.TableId)
               .IsRequired()
               .HasColumnName("TableId")
               .HasColumnType("int");

            builder.Property(prop => prop.Open)
               .IsRequired()
               .HasColumnName("OpenBill")
               .HasColumnType("bit");

            builder.HasIndex(prop => prop.CompanyId)
                .HasDatabaseName("IX_Order_Company");

            builder.HasMany(prop => prop.OrderProducts)
                .WithOne(prop => prop.Bill)
                .HasForeignKey(prop => prop.Id)
                .IsRequired();
        }
    }
}
