﻿using OrderQR.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OrderQR.Infra.Data.Mapping
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

            builder.Property(prop => prop.CreatedAt)
                   .IsRequired()
                   .HasColumnName("CreatedAt")
                   .HasColumnType("datetime2");

            builder.Property(prop => prop.CompanyId)
                   .IsRequired()
                   .HasColumnName("CompanyId")
                   .HasColumnType("int");

            builder.Property(prop => prop.Identification)
                   .IsRequired()
                   .HasColumnName("Identification")
                   .HasColumnType("varchar(100)");

            builder.Property(prop => prop.Link)
                   .IsRequired()
                   .HasColumnName("Link")
                   .HasColumnType("varchar(300)");

            builder.HasIndex(prop => prop.CompanyId)
                .HasDatabaseName("IX_Order_Company");


            builder.HasData(new Table("Mesa1", 0) { Id = 1, CompanyId = 1, Unique = Guid.Parse("440cdeee-5b8a-462a-96fd-20b24bd82f55"), Link = "https://localhost:44361/1/6/customer/login/" });

        }
    }
}
