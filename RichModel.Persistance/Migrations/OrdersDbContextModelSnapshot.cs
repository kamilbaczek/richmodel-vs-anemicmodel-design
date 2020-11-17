﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace RichModel.Persistance.Migrations
{
    [DbContext(typeof(OrdersDbContext))]
    class OrdersDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("RichModel.Domain.Orders.Order", b =>
            {
                b.Property<Guid>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("uniqueidentifier");

                b.Property<int>("Status")
                    .HasColumnType("int");

                b.HasKey("Id");

                b.ToTable("Orders", "orders");
            });

            modelBuilder.Entity("RichModel.Domain.Orders.OrderItem", b =>
            {
                b.Property<Guid>("OrderId")
                    .HasColumnType("uniqueidentifier");

                b.Property<Guid>("ProductId")
                    .HasColumnType("uniqueidentifier");

                b.HasKey("OrderId", "ProductId");

                b.HasIndex("ProductId");

                b.ToTable("OrderItems");
            });

            modelBuilder.Entity("RichModel.Domain.Products.Product", b =>
            {
                b.Property<Guid>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("uniqueidentifier");

                b.Property<string>("Name")
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnType("nvarchar(255)");

                b.Property<decimal>("Price")
                    .HasPrecision(15, 2)
                    .HasColumnType("decimal(15,2)");

                b.HasKey("Id");

                b.ToTable("Products", "orders");
            });

            modelBuilder.Entity("RichModel.Domain.Orders.OrderItem", b =>
            {
                b.HasOne("RichModel.Domain.Orders.Order", "Order")
                    .WithMany("Items")
                    .HasForeignKey("OrderId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.HasOne("RichModel.Domain.Products.Product", "Product")
                    .WithMany("Items")
                    .HasForeignKey("ProductId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.Navigation("Order");

                b.Navigation("Product");
            });

            modelBuilder.Entity("RichModel.Domain.Orders.Order", b => { b.Navigation("Items"); });

            modelBuilder.Entity("RichModel.Domain.Products.Product", b => { b.Navigation("Items"); });
#pragma warning restore 612, 618
        }
    }
}