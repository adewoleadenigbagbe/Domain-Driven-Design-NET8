﻿// <auto-generated />
using System;
using App.Data.MySQL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace App.Data.MySQL.Migrations
{
    [DbContext(typeof(MySqlReadWriteAppContext))]
    [Migration("20241029214257_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("App.Data.Entities.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("Dob")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<bool>("IsDeprecated")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("CreatedOn");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("App.Data.Entities.Customers.Address", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("AddressLine")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("char(36)");

                    b.Property<bool>("IsDeprecated")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("CreatedOn");

                    b.HasIndex("CustomerId");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("App.Data.Entities.Orders.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("char(36)");

                    b.Property<bool>("IsDeprecated")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CreatedOn");

                    b.HasIndex("CustomerId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("App.Data.Entities.Orders.Orderline", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("IsDeprecated")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("char(36)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("char(36)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<decimal>("Vat")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("CreatedOn");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("Orderlines");
                });

            modelBuilder.Entity("App.Data.Entities.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<int>("Category")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("IsDeprecated")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Vat")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("App.Data.Entities.Customers.Address", b =>
                {
                    b.HasOne("App.Data.Entities.Customer", "Customer")
                        .WithMany("Addresses")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("App.Data.Entities.Orders.Orderline", b =>
                {
                    b.HasOne("App.Data.Entities.Orders.Order", "Order")
                        .WithMany("Orderlines")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");
                });

            modelBuilder.Entity("App.Data.Entities.Customer", b =>
                {
                    b.Navigation("Addresses");
                });

            modelBuilder.Entity("App.Data.Entities.Orders.Order", b =>
                {
                    b.Navigation("Orderlines");
                });
#pragma warning restore 612, 618
        }
    }
}
