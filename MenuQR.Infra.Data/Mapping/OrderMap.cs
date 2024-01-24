﻿using MenuQR.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MenuQR.Infra.Data.Mapping
{
    internal class OrderMap : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Order");

            builder.HasKey(prop => prop.Id);

            builder.Property(prop => prop.CompanyId)
               .IsRequired()
               .HasColumnName("CompanyId")
               .HasColumnType("int");

            builder.Property(prop => prop.Date)
               .IsRequired()
               .HasColumnName("Date")
               .HasColumnType("datetime2");

            builder.HasOne(prop => prop.Table)
                .WithMany()
                .HasForeignKey(prop => prop.TableId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(prop => prop.Customer)
                .WithMany()
                .HasForeignKey(prop => prop.CustomerDocument)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(prop => prop.CompanyId)
                .HasDatabaseName("IX_Order_Company");

        }
    }
}
