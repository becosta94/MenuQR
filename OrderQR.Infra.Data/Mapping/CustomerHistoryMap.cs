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
    internal class CustomerHistoryMap : IEntityTypeConfiguration<CustomerHistory>
    {
        public void Configure(EntityTypeBuilder<CustomerHistory> builder)
        {
            builder.ToTable("CustomerHistory");

            builder.HasKey(prop => new { prop.Id, prop.CompanyId});

            builder.Property(prop => prop.Id)
                   .ValueGeneratedOnAdd()
                   .UseIdentityColumn();

            builder.Property(prop => prop.CreatedAt)
               .IsRequired()
               .HasColumnName("CreatedAt")
               .HasColumnType("datetime2");

            builder.Property(prop => prop.CustomerDocument)
               .IsRequired()
               .HasColumnName("CustomerDocument")
               .HasColumnType("varchar(50)");

            builder.Property(prop => prop.OnPlace)
                .IsRequired()
                .HasColumnName("OnPlace")
                .HasColumnType("bit");

            builder.Property(prop => prop.BillId)
                .IsRequired()
                .HasColumnName("BillId")
                .HasColumnType("int");

            builder.Property(prop => prop.BillCompanyId)
                .IsRequired()
                .HasColumnName("BillCompanyId")
                .HasColumnType("int");

            builder.HasIndex(prop => prop.CompanyId)
                .HasDatabaseName("IX_Order_Company");

        }
    }
}
