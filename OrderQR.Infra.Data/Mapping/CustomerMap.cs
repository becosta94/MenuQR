﻿using OrderQR.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OrderQR.Infra.Data.Mapping
{
    public class CustomerMap : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customer");

            builder.HasKey(prop => prop.Document);

            builder.Property(prop => prop.CreatedAt)
               .IsRequired()
               .HasColumnName("CreatedAt")
               .HasColumnType("datetime2");

            builder.Property(prop => prop.Document)
                .IsRequired()
                .HasColumnName("CustomerDocument")
                .HasColumnType("varchar(50)");

            builder.Property(prop => prop.Id)
                .IsRequired()
                .HasColumnName("Id")
                .HasColumnType("int")
                .UseIdentityColumn();

            builder.Property(prop => prop.Name)
               .HasColumnName("Name")
               .HasColumnType("varchar(200)");

            }
    }
}
