﻿// <auto-generated />
using System;
using Inventory.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Inventory.Infrastructure.Data.Migrations
{
    [DbContext(typeof(InventoryContext))]
    [Migration("20201029183401_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0-rc.2.20475.6");

            modelBuilder.Entity("Inventory.Core.Entities.History", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<byte>("Action")
                        .HasColumnType("tinyint");

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Reason")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<int>("StuffId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StuffId");

                    b.ToTable("History");
                });

            modelBuilder.Entity("Inventory.Core.Entities.Stuff", b =>
                {
                    b.Property<int>("StuffTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Brand")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("PurchaseDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("StuffTypeId", "Brand", "PurchaseDate");

                    b.ToTable("Stuff");
                });

            modelBuilder.Entity("Inventory.Core.Entities.StuffType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("StuffType");
                });

            modelBuilder.Entity("Inventory.Core.Entities.History", b =>
                {
                    b.HasOne("Inventory.Core.Entities.Stuff", null)
                        .WithMany("Histories")
                        .HasForeignKey("StuffId")
                        .HasPrincipalKey("Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Inventory.Core.Entities.Stuff", b =>
                {
                    b.HasOne("Inventory.Core.Entities.StuffType", null)
                        .WithMany("Stuff")
                        .HasForeignKey("StuffTypeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Inventory.Core.Entities.Stuff", b =>
                {
                    b.Navigation("Histories");
                });

            modelBuilder.Entity("Inventory.Core.Entities.StuffType", b =>
                {
                    b.Navigation("Stuff");
                });
#pragma warning restore 612, 618
        }
    }
}
