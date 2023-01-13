﻿// <auto-generated />
using System;
using Avram_Alin_Proiect.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Avram_Alin_Proiect.Migrations
{
    [DbContext(typeof(Avram_Alin_ProiectContext))]
    [Migration("20230109175826_SupplierUpdateNow")]
    partial class SupplierUpdateNow
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Avram_Alin_Proiect.Models.AutoPart", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<DateTime>("AcquisitionDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CarID")
                        .HasColumnType("int");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(6,2)");

                    b.Property<int?>("SupplierID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("CarID");

                    b.HasIndex("SupplierID");

                    b.ToTable("AutoPart");
                });

            modelBuilder.Entity("Avram_Alin_Proiect.Models.AutoPartCategory", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int>("AutoPartID")
                        .HasColumnType("int");

                    b.Property<int>("CategoryID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("AutoPartID");

                    b.HasIndex("CategoryID");

                    b.ToTable("AutoPartCategory");
                });

            modelBuilder.Entity("Avram_Alin_Proiect.Models.Car", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("CarName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Car");
                });

            modelBuilder.Entity("Avram_Alin_Proiect.Models.Category", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("Avram_Alin_Proiect.Models.Supplier", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TaxID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Supplier");
                });

            modelBuilder.Entity("Avram_Alin_Proiect.Models.AutoPart", b =>
                {
                    b.HasOne("Avram_Alin_Proiect.Models.Car", "Car")
                        .WithMany("Autoparts")
                        .HasForeignKey("CarID");

                    b.HasOne("Avram_Alin_Proiect.Models.Supplier", "Supplier")
                        .WithMany("Autoparts")
                        .HasForeignKey("SupplierID");

                    b.Navigation("Car");

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("Avram_Alin_Proiect.Models.AutoPartCategory", b =>
                {
                    b.HasOne("Avram_Alin_Proiect.Models.AutoPart", "AutoPart")
                        .WithMany("AutoPartCategories")
                        .HasForeignKey("AutoPartID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Avram_Alin_Proiect.Models.Category", "Category")
                        .WithMany("AutoPartCategories")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AutoPart");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Avram_Alin_Proiect.Models.AutoPart", b =>
                {
                    b.Navigation("AutoPartCategories");
                });

            modelBuilder.Entity("Avram_Alin_Proiect.Models.Car", b =>
                {
                    b.Navigation("Autoparts");
                });

            modelBuilder.Entity("Avram_Alin_Proiect.Models.Category", b =>
                {
                    b.Navigation("AutoPartCategories");
                });

            modelBuilder.Entity("Avram_Alin_Proiect.Models.Supplier", b =>
                {
                    b.Navigation("Autoparts");
                });
#pragma warning restore 612, 618
        }
    }
}