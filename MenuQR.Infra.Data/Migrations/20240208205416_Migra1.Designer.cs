﻿// <auto-generated />
using System;
using MenuQR.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MenuQR.Infra.Data.Migrations
{
    [DbContext(typeof(SqlContext))]
    [Migration("20240208205416_Migra1")]
    partial class Migra1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MenuQR.Domain.Entities.Bill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CompanyId")
                        .HasColumnType("int")
                        .HasColumnName("CompanyId");

                    b.Property<bool>("Open")
                        .HasColumnType("bit")
                        .HasColumnName("OpenBill");

                    b.Property<int>("TableId")
                        .HasColumnType("int")
                        .HasColumnName("TableId");

                    b.Property<double>("Total")
                        .HasColumnType("float")
                        .HasColumnName("Total");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId")
                        .HasDatabaseName("IX_Order_Company");

                    b.HasIndex("TableId")
                        .IsUnique();

                    b.ToTable("Bill", (string)null);
                });

            modelBuilder.Entity("MenuQR.Domain.Entities.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Adress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<string>("DocumentNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ResponsibleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("MenuQR.Domain.Entities.Customer", b =>
                {
                    b.Property<string>("Document")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("MacAdress")
                        .IsRequired()
                        .HasColumnType("varchar(250)")
                        .HasColumnName("MacAdress");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(200)")
                        .HasColumnName("Name");

                    b.HasKey("Document");

                    b.ToTable("Customer", (string)null);
                });

            modelBuilder.Entity("MenuQR.Domain.Entities.CustomerHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CompanyId")
                        .HasColumnType("int")
                        .HasColumnName("CompanyId");

                    b.Property<string>("CustomerDocument")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<bool>("OnPlace")
                        .HasColumnType("bit")
                        .HasColumnName("OnPlace");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId")
                        .HasDatabaseName("IX_Order_Company");

                    b.HasIndex("CustomerDocument");

                    b.ToTable("CustomerHistory", (string)null);
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

                    b.Property<string>("CustomerDocument")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2")
                        .HasColumnName("Date");

                    b.Property<bool>("Deliverd")
                        .HasColumnType("bit");

                    b.Property<int?>("TableId")
                        .HasColumnType("int");

                    b.HasKey("Id", "CompanyId");

                    b.HasIndex("CompanyId")
                        .HasDatabaseName("IX_Order_Company");

                    b.HasIndex("CustomerDocument");

                    b.HasIndex("TableId");

                    b.ToTable("Order", (string)null);
                });

            modelBuilder.Entity("MenuQR.Domain.Entities.OrderProduct", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Amount")
                        .HasColumnType("int")
                        .HasColumnName("Amount");

                    b.Property<int>("BillId")
                        .HasColumnType("int");

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<int>("OrderCompanyId")
                        .HasColumnType("int");

                    b.Property<int>("OrderId")
                        .HasColumnType("int")
                        .HasColumnName("OrderId");

                    b.Property<int>("ProductCompanyId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int")
                        .HasColumnName("ProductId");

                    b.Property<double>("Total")
                        .HasColumnType("float")
                        .HasColumnName("Total");

                    b.HasKey("Id");

                    b.HasIndex("BillId");

                    b.HasIndex("OrderId", "OrderCompanyId");

                    b.HasIndex("ProductId", "ProductCompanyId");

                    b.ToTable("OrderProduct", (string)null);
                });

            modelBuilder.Entity("MenuQR.Domain.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<bool>("Active")
                        .HasColumnType("bit")
                        .HasColumnName("Active");

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

                    b.HasKey("Id", "CompanyId");

                    b.ToTable("Product", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CompanyId = 1,
                            Active = true,
                            Description = "Pão artesanal",
                            Image = "Teste",
                            Name = "Pão",
                            Price = 10.5m
                        });
                });

            modelBuilder.Entity("MenuQR.Domain.Entities.Table", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CompanyId")
                        .HasColumnType("int")
                        .HasColumnName("CompanyId");

                    b.Property<string>("Identification")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Identification");

                    b.Property<string>("QRLink")
                        .IsRequired()
                        .HasColumnType("varchar(300)")
                        .HasColumnName("QRLink");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId")
                        .HasDatabaseName("IX_Order_Company");

                    b.ToTable("Table", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CompanyId = 0,
                            Identification = "Mesa1",
                            QRLink = "Teste"
                        });
                });

            modelBuilder.Entity("MenuQR.Domain.Entities.Bill", b =>
                {
                    b.HasOne("MenuQR.Domain.Entities.Table", "Table")
                        .WithOne("Bill")
                        .HasForeignKey("MenuQR.Domain.Entities.Bill", "TableId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Table");
                });

            modelBuilder.Entity("MenuQR.Domain.Entities.CustomerHistory", b =>
                {
                    b.HasOne("MenuQR.Domain.Entities.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerDocument")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("MenuQR.Domain.Entities.Order", b =>
                {
                    b.HasOne("MenuQR.Domain.Entities.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerDocument")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("MenuQR.Domain.Entities.Table", "Table")
                        .WithMany()
                        .HasForeignKey("TableId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Customer");

                    b.Navigation("Table");
                });

            modelBuilder.Entity("MenuQR.Domain.Entities.OrderProduct", b =>
                {
                    b.HasOne("MenuQR.Domain.Entities.Bill", "Bill")
                        .WithMany("OrderProducts")
                        .HasForeignKey("BillId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MenuQR.Domain.Entities.Order", "Order")
                        .WithMany("OrderProducts")
                        .HasForeignKey("OrderId", "OrderCompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MenuQR.Domain.Entities.Product", "Product")
                        .WithMany("OrderProducts")
                        .HasForeignKey("ProductId", "ProductCompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bill");

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("MenuQR.Domain.Entities.Bill", b =>
                {
                    b.Navigation("OrderProducts");
                });

            modelBuilder.Entity("MenuQR.Domain.Entities.Order", b =>
                {
                    b.Navigation("OrderProducts");
                });

            modelBuilder.Entity("MenuQR.Domain.Entities.Product", b =>
                {
                    b.Navigation("OrderProducts");
                });

            modelBuilder.Entity("MenuQR.Domain.Entities.Table", b =>
                {
                    b.Navigation("Bill")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}