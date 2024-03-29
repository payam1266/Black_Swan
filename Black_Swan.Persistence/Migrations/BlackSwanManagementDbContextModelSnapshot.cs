﻿// <auto-generated />
using System;
using Black_Swan.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Black_Swan.Persistence.Migrations
{
    [DbContext(typeof(BlackSwanManagementDbContext))]
    partial class BlackSwanManagementDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1, 1);

            modelBuilder.Entity("Black_Swan_Domain.Brand", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1, 1);

                    b.Property<DateTime>("CreatedDay")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("brands");

                    b.HasData(
                        new
                        {
                            id = 1,
                            CreatedDay = new DateTime(2024, 1, 31, 11, 59, 2, 551, DateTimeKind.Local).AddTicks(2504),
                            LastModifiedDate = new DateTime(2024, 1, 31, 11, 59, 2, 551, DateTimeKind.Local).AddTicks(2512),
                            description = "wow",
                            name = "anahita"
                        },
                        new
                        {
                            id = 2,
                            CreatedDay = new DateTime(2024, 1, 31, 11, 59, 2, 551, DateTimeKind.Local).AddTicks(2514),
                            LastModifiedDate = new DateTime(2024, 1, 31, 11, 59, 2, 551, DateTimeKind.Local).AddTicks(2514),
                            description = "amazing",
                            name = "mitra"
                        });
                });

            modelBuilder.Entity("Black_Swan_Domain.CardItem", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1, 1);

                    b.Property<DateTime>("CreatedDay")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("productcount")
                        .HasColumnType("int");

                    b.Property<int>("productid")
                        .HasColumnType("int");

                    b.Property<string>("productname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("productprice")
                        .HasColumnType("real");

                    b.Property<string>("userid")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("cardItems");

                    b.HasData(
                        new
                        {
                            id = 1,
                            CreatedDay = new DateTime(2024, 1, 31, 11, 59, 2, 551, DateTimeKind.Local).AddTicks(2757),
                            LastModifiedDate = new DateTime(2024, 1, 31, 11, 59, 2, 551, DateTimeKind.Local).AddTicks(2759),
                            productcount = 5,
                            productid = 1,
                            productname = "sekiro",
                            productprice = 50f
                        },
                        new
                        {
                            id = 2,
                            CreatedDay = new DateTime(2024, 1, 31, 11, 59, 2, 551, DateTimeKind.Local).AddTicks(2761),
                            LastModifiedDate = new DateTime(2024, 1, 31, 11, 59, 2, 551, DateTimeKind.Local).AddTicks(2761),
                            productcount = 5,
                            productid = 1,
                            productname = "santa",
                            productprice = 50f
                        });
                });

            modelBuilder.Entity("Black_Swan_Domain.City", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1, 1);

                    b.Property<DateTime>("CreatedDay")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("cities");

                    b.HasData(
                        new
                        {
                            id = 1,
                            CreatedDay = new DateTime(2024, 1, 31, 11, 59, 2, 551, DateTimeKind.Local).AddTicks(2854),
                            LastModifiedDate = new DateTime(2024, 1, 31, 11, 59, 2, 551, DateTimeKind.Local).AddTicks(2855),
                            name = "shiraz"
                        },
                        new
                        {
                            id = 2,
                            CreatedDay = new DateTime(2024, 1, 31, 11, 59, 2, 551, DateTimeKind.Local).AddTicks(2856),
                            LastModifiedDate = new DateTime(2024, 1, 31, 11, 59, 2, 551, DateTimeKind.Local).AddTicks(2856),
                            name = "Tehran"
                        });
                });

            modelBuilder.Entity("Black_Swan_Domain.Order", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1, 1);

                    b.Property<DateTime>("CreatedDay")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("city")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("customerid")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("paymentmethod")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("postalcode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("status")
                        .HasColumnType("int");

                    b.Property<float>("totalPrice")
                        .HasColumnType("real");

                    b.HasKey("id");

                    b.ToTable("orders");

                    b.HasData(
                        new
                        {
                            id = 1,
                            CreatedDay = new DateTime(2024, 1, 31, 11, 59, 2, 551, DateTimeKind.Local).AddTicks(2935),
                            LastModifiedDate = new DateTime(2024, 1, 31, 11, 59, 2, 551, DateTimeKind.Local).AddTicks(2936),
                            address = "shiraz",
                            city = "shiraz",
                            paymentmethod = "pay in place",
                            phone = "09364154728",
                            postalcode = "1234567891",
                            status = 1,
                            totalPrice = 500f
                        },
                        new
                        {
                            id = 2,
                            CreatedDay = new DateTime(2024, 1, 31, 11, 59, 2, 551, DateTimeKind.Local).AddTicks(2938),
                            LastModifiedDate = new DateTime(2024, 1, 31, 11, 59, 2, 551, DateTimeKind.Local).AddTicks(2938),
                            address = "boshehr",
                            city = "shiraz",
                            paymentmethod = "pay in place",
                            phone = "09364154728",
                            postalcode = "1234567891",
                            status = 0,
                            totalPrice = 1000f
                        });
                });

            modelBuilder.Entity("Black_Swan_Domain.OrderDetails", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1, 1);

                    b.Property<DateTime>("CreatedDay")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("orderId")
                        .HasColumnType("int");

                    b.Property<int>("productId")
                        .HasColumnType("int");

                    b.Property<string>("productName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("productPrice")
                        .HasColumnType("real");

                    b.Property<int>("quantity")
                        .HasColumnType("int");

                    b.Property<float>("subtotal")
                        .HasColumnType("real");

                    b.HasKey("id");

                    b.HasIndex("orderId");

                    b.HasIndex("productId");

                    b.ToTable("OrderDetails");

                    b.HasData(
                        new
                        {
                            id = 1,
                            CreatedDay = new DateTime(2024, 1, 31, 11, 59, 2, 551, DateTimeKind.Local).AddTicks(3029),
                            LastModifiedDate = new DateTime(2024, 1, 31, 11, 59, 2, 551, DateTimeKind.Local).AddTicks(3029),
                            orderId = 1,
                            productId = 1,
                            productName = "jackob",
                            productPrice = 100f,
                            quantity = 5,
                            subtotal = 500f
                        });
                });

            modelBuilder.Entity("Black_Swan_Domain.Product", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1, 1);

                    b.Property<DateTime>("CreatedDay")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsAvalaible")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("brandId")
                        .HasColumnType("int");

                    b.Property<int>("cityId")
                        .HasColumnType("int");

                    b.Property<string>("color")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("count")
                        .HasColumnType("int");

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("img")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("price")
                        .HasColumnType("real");

                    b.Property<int>("productCategoryId")
                        .HasColumnType("int");

                    b.Property<string>("sellerid")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("size")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("brandId");

                    b.HasIndex("cityId");

                    b.HasIndex("productCategoryId");

                    b.ToTable("products");

                    b.HasData(
                        new
                        {
                            id = 1,
                            CreatedDay = new DateTime(2024, 1, 31, 11, 59, 2, 551, DateTimeKind.Local).AddTicks(3192),
                            IsAvalaible = true,
                            LastModifiedDate = new DateTime(2024, 1, 31, 11, 59, 2, 551, DateTimeKind.Local).AddTicks(3193),
                            brandId = 1,
                            cityId = 1,
                            color = "black",
                            count = 50,
                            description = "its nice",
                            name = "Jackob",
                            price = 120f,
                            productCategoryId = 1,
                            sellerid = "",
                            size = "large"
                        },
                        new
                        {
                            id = 2,
                            CreatedDay = new DateTime(2024, 1, 31, 11, 59, 2, 551, DateTimeKind.Local).AddTicks(3195),
                            IsAvalaible = true,
                            LastModifiedDate = new DateTime(2024, 1, 31, 11, 59, 2, 551, DateTimeKind.Local).AddTicks(3195),
                            brandId = 2,
                            cityId = 2,
                            color = "brown",
                            count = 20,
                            description = "its nice",
                            name = "mitra",
                            price = 200f,
                            productCategoryId = 2,
                            sellerid = "",
                            size = "small"
                        });
                });

            modelBuilder.Entity("Black_Swan_Domain.ProductCategory", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1, 1);

                    b.Property<DateTime>("CreatedDay")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("productCategories");

                    b.HasData(
                        new
                        {
                            id = 1,
                            CreatedDay = new DateTime(2024, 1, 31, 11, 59, 2, 551, DateTimeKind.Local).AddTicks(3110),
                            LastModifiedDate = new DateTime(2024, 1, 31, 11, 59, 2, 551, DateTimeKind.Local).AddTicks(3111),
                            name = "shoe"
                        },
                        new
                        {
                            id = 2,
                            CreatedDay = new DateTime(2024, 1, 31, 11, 59, 2, 551, DateTimeKind.Local).AddTicks(3112),
                            LastModifiedDate = new DateTime(2024, 1, 31, 11, 59, 2, 551, DateTimeKind.Local).AddTicks(3113),
                            name = "dress"
                        });
                });

            modelBuilder.Entity("Black_Swan_Domain.OrderDetails", b =>
                {
                    b.HasOne("Black_Swan_Domain.Order", "Order")
                        .WithMany()
                        .HasForeignKey("orderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Black_Swan_Domain.Product", "product")
                        .WithMany("orderDetails")
                        .HasForeignKey("productId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("product");
                });

            modelBuilder.Entity("Black_Swan_Domain.Product", b =>
                {
                    b.HasOne("Black_Swan_Domain.Brand", "brand")
                        .WithMany("products")
                        .HasForeignKey("brandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Black_Swan_Domain.City", "city")
                        .WithMany("products")
                        .HasForeignKey("cityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Black_Swan_Domain.ProductCategory", "productCategory")
                        .WithMany("products")
                        .HasForeignKey("productCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("brand");

                    b.Navigation("city");

                    b.Navigation("productCategory");
                });

            modelBuilder.Entity("Black_Swan_Domain.Brand", b =>
                {
                    b.Navigation("products");
                });

            modelBuilder.Entity("Black_Swan_Domain.City", b =>
                {
                    b.Navigation("products");
                });

            modelBuilder.Entity("Black_Swan_Domain.Product", b =>
                {
                    b.Navigation("orderDetails");
                });

            modelBuilder.Entity("Black_Swan_Domain.ProductCategory", b =>
                {
                    b.Navigation("products");
                });
#pragma warning restore 612, 618
        }
    }
}
