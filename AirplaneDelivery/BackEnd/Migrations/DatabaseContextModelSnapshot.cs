﻿// <auto-generated />
using System;
using BackEnd;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace BackEnd.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.14")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("DAL.Models.Cart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("DAL.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Image")
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("DAL.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<float>("Carbohydrates")
                        .HasColumnType("real");

                    b.Property<int?>("CategoryProductId")
                        .HasColumnType("integer");

                    b.Property<int>("CountInStorage")
                        .HasColumnType("integer");

                    b.Property<float>("Fats")
                        .HasColumnType("real");

                    b.Property<string>("Image")
                        .HasColumnType("text");

                    b.Property<float>("Kkal")
                        .HasColumnType("real");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int>("Price")
                        .HasColumnType("integer");

                    b.Property<float>("Proteins")
                        .HasColumnType("real");

                    b.Property<int>("Weight")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CategoryProductId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("DAL.Models.Spot", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("CartId")
                        .HasColumnType("integer");

                    b.Property<int>("Count")
                        .HasColumnType("integer");

                    b.Property<int?>("ProductsId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CartId");

                    b.HasIndex("ProductsId");

                    b.ToTable("Spots");
                });

            modelBuilder.Entity("DAL.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<int?>("CartId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Number")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CartId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DAL.Models.Cart", b =>
                {
                    b.HasOne("DAL.Models.User", null)
                        .WithMany("HistoryOfOrders")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("DAL.Models.Product", b =>
                {
                    b.HasOne("DAL.Models.Category", "CategoryProduct")
                        .WithMany()
                        .HasForeignKey("CategoryProductId");

                    b.Navigation("CategoryProduct");
                });

            modelBuilder.Entity("DAL.Models.Spot", b =>
                {
                    b.HasOne("DAL.Models.Cart", null)
                        .WithMany("Spots")
                        .HasForeignKey("CartId");

                    b.HasOne("DAL.Models.Product", "Products")
                        .WithMany("Spot")
                        .HasForeignKey("ProductsId");

                    b.Navigation("Products");
                });

            modelBuilder.Entity("DAL.Models.User", b =>
                {
                    b.HasOne("DAL.Models.Cart", "Cart")
                        .WithMany()
                        .HasForeignKey("CartId");

                    b.Navigation("Cart");
                });

            modelBuilder.Entity("DAL.Models.Cart", b =>
                {
                    b.Navigation("Spots");
                });

            modelBuilder.Entity("DAL.Models.Product", b =>
                {
                    b.Navigation("Spot");
                });

            modelBuilder.Entity("DAL.Models.User", b =>
                {
                    b.Navigation("HistoryOfOrders");
                });
#pragma warning restore 612, 618
        }
    }
}