﻿using OrderQR.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OrderQR.Infra.Data.Mapping
{
    internal class OrderProductMap : IEntityTypeConfiguration<OrderProduct>
    {
        public void Configure(EntityTypeBuilder<OrderProduct> builder)
        {
            builder.ToTable("OrderProduct");

            builder.HasKey(prop => prop.Id);

            builder.Property(prop => prop.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            builder.Property(prop => prop.CreatedAt)
               .IsRequired()
               .HasColumnName("CreatedAt")
               .HasColumnType("datetime2");

            builder.Property(prop => prop.OrderId)
               .IsRequired()
               .HasColumnName("OrderId")
               .HasColumnType("int");

            builder.Property(prop => prop.OrderCompanyId)
               .IsRequired()
               .HasColumnName("OrderCompanyId")
               .HasColumnType("int");

            builder.Property(prop => prop.ProductId)
               .IsRequired()
               .HasColumnName("ProductId")
               .HasColumnType("int");

            builder.Property(prop => prop.ProductCompanyId)
               .IsRequired()
               .HasColumnName("ProductCompanyId")
               .HasColumnType("int");

            builder.Property(prop => prop.BillId)
               .IsRequired()
               .HasColumnName("BillId")
               .HasColumnType("int");            
            
            builder.Property(prop => prop.BillCompanyId)
               .IsRequired()
               .HasColumnName("BillCompanyId")
               .HasColumnType("int");

            builder.Property(prop => prop.Amount)
               .IsRequired()
               .HasColumnName("Amount")
               .HasColumnType("int");

            builder.Property(prop => prop.Total)
               .IsRequired()
               .HasColumnName("Total")
                .HasColumnType("decimal(6,2)");

            builder.Property(prop => prop.Profit)
               .IsRequired()
               .HasColumnName("Profit")
               .HasColumnType("decimal(6,2)");

        }
    }
}
