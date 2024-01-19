﻿// <auto-generated />
using System;
using MenuQR.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MenuQR.Infra.Data.Migrations
{
    [DbContext(typeof(SqlContext))]
    partial class SqlContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MenuQR.Domain.Entities.Costumer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<string>("Document")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsOnPlace")
                        .HasColumnType("bit");

                    b.Property<string>("MacAdress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Costumer");
                });

            modelBuilder.Entity("MenuQR.Domain.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CompanyId")
                        .HasColumnType("int")
                        .HasColumnName("CompanyId");

                    b.Property<int>("CostumerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2")
                        .HasColumnName("Date");

                    b.Property<bool>("Deliverd")
                        .HasColumnType("bit");

                    b.Property<int>("TableId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId")
                        .HasDatabaseName("IX_Order_Company");

                    b.HasIndex("CostumerId");

                    b.HasIndex("TableId");

                    b.ToTable("Order", (string)null);
                });

            modelBuilder.Entity("MenuQR.Domain.Entities.OrderProduct", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderProducts");
                });

            modelBuilder.Entity("MenuQR.Domain.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(1000)")
                        .HasColumnName("Description");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("varchar(MAX)")
                        .HasColumnName("Image");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(200)")
                        .HasColumnName("Name");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(6,2)")
                        .HasColumnName("Price");

                    b.HasKey("Id");

                    b.ToTable("Product", (string)null);
                });

            modelBuilder.Entity("MenuQR.Domain.Entities.Table", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<string>("Identification")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Table");
                });

            modelBuilder.Entity("MenuQR.Domain.Entities.Order", b =>
                {
                    b.HasOne("MenuQR.Domain.Entities.Costumer", "Costumer")
                        .WithMany()
                        .HasForeignKey("CostumerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MenuQR.Domain.Entities.Table", "Table")
                        .WithMany()
                        .HasForeignKey("TableId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Costumer");

                    b.Navigation("Table");
                });

            modelBuilder.Entity("MenuQR.Domain.Entities.OrderProduct", b =>
                {
                    b.HasOne("MenuQR.Domain.Entities.Order", "Order")
                        .WithMany("OrderProducts")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MenuQR.Domain.Entities.Product", "Product")
                        .WithMany("OrderProducts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("MenuQR.Domain.Entities.Order", b =>
                {
                    b.Navigation("OrderProducts");
                });

            modelBuilder.Entity("MenuQR.Domain.Entities.Product", b =>
                {
                    b.Navigation("OrderProducts");
                });
#pragma warning restore 612, 618
        }
    }
}
