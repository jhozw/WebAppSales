﻿// <auto-generated />
using System;
using AppWebMvcSales.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AppWebMvcSales.Migrations
{
    [DbContext(typeof(AppWebMvcSalesContext))]
    partial class AppWebMvcSalesContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AppWebMvcSales.Models.Departament", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Departament");
                });

            modelBuilder.Entity("AppWebMvcSales.Models.SelesRecord", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int?>("SellerId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SellerId");

                    b.ToTable("SellersRecord");
                });

            modelBuilder.Entity("AppWebMvcSales.Models.Seller", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<decimal>("BaseSalary")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("Departamentid")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Departamentid");

                    b.ToTable("Seller");
                });

            modelBuilder.Entity("AppWebMvcSales.Models.SelesRecord", b =>
                {
                    b.HasOne("AppWebMvcSales.Models.Seller", "Seller")
                        .WithMany("Selles")
                        .HasForeignKey("SellerId");

                    b.Navigation("Seller");
                });

            modelBuilder.Entity("AppWebMvcSales.Models.Seller", b =>
                {
                    b.HasOne("AppWebMvcSales.Models.Departament", "Departament")
                        .WithMany("Sellers")
                        .HasForeignKey("Departamentid");

                    b.Navigation("Departament");
                });

            modelBuilder.Entity("AppWebMvcSales.Models.Departament", b =>
                {
                    b.Navigation("Sellers");
                });

            modelBuilder.Entity("AppWebMvcSales.Models.Seller", b =>
                {
                    b.Navigation("Selles");
                });
#pragma warning restore 612, 618
        }
    }
}
