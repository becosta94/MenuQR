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
    internal class CustomerHistoryMap : IEntityTypeConfiguration<CustomerHistory>
    {
        public void Configure(EntityTypeBuilder<CustomerHistory> builder)
        {
            builder.ToTable("CustomerHistory");

            builder.HasKey(prop => prop.Id);

            builder.Property(prop => prop.CompanyId)
               .IsRequired()
               .HasColumnName("CompanyId")
               .HasColumnType("int");

            builder.Property(prop => prop.OnPlace)
                .IsRequired()
                .HasColumnName("OnPlace")
                .HasColumnType("bit");

            builder.HasIndex(prop => prop.CompanyId)
                .HasDatabaseName("IX_Order_Company");

        }
    }
}
