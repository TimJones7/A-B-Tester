﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Pizza.API.Data;

#nullable disable

namespace Pizza.API.Migrations
{
    [DbContext(typeof(PizzaDbContext))]
    partial class PizzaDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.7");

            modelBuilder.Entity("ElementSession", b =>
                {
                    b.Property<Guid>("ElementsId")
                        .HasColumnType("TEXT");

                    b.Property<int>("SessionsId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ElementsId", "SessionsId");

                    b.HasIndex("SessionsId");

                    b.ToTable("ElementSession");
                });

            modelBuilder.Entity("Entities.Models.Component", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("ElementId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ElementId");

                    b.ToTable("Components");
                });

            modelBuilder.Entity("Entities.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(75)
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Entities.Models.CustomerInteractions", b =>
                {
                    b.Property<int>("CustomerId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SessionId")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("ElementId")
                        .HasColumnType("TEXT");

                    b.Property<int>("Action")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("OccuranceDateTime")
                        .HasColumnType("TEXT");

                    b.HasKey("CustomerId", "SessionId", "ElementId");

                    b.HasIndex("ElementId");

                    b.HasIndex("SessionId");

                    b.ToTable("Interactions");
                });

            modelBuilder.Entity("Entities.Models.Element", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("FirstChildId")
                        .HasColumnType("TEXT");

                    b.Property<string>("HtmlClasses")
                        .HasColumnType("TEXT");

                    b.Property<string>("HtmlId")
                        .HasColumnType("TEXT");

                    b.Property<string>("HtmlName")
                        .HasColumnType("TEXT");

                    b.Property<string>("HtmlStyles")
                        .HasColumnType("TEXT");

                    b.Property<string>("HtmlValue")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsRoot")
                        .HasColumnType("INTEGER");

                    b.Property<Guid?>("NextSiblingId")
                        .HasColumnType("TEXT");

                    b.Property<string>("NodeType")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("ParentId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Elements");
                });

            modelBuilder.Entity("Entities.Models.Session", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CustomerId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<bool>("ResultedInOrder")
                        .HasColumnType("INTEGER");

                    b.Property<double?>("TotalSpent")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Sessions");
                });

            modelBuilder.Entity("ElementSession", b =>
                {
                    b.HasOne("Entities.Models.Element", null)
                        .WithMany()
                        .HasForeignKey("ElementsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Models.Session", null)
                        .WithMany()
                        .HasForeignKey("SessionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Entities.Models.Component", b =>
                {
                    b.HasOne("Entities.Models.Element", "Root")
                        .WithMany()
                        .HasForeignKey("ElementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Root");
                });

            modelBuilder.Entity("Entities.Models.CustomerInteractions", b =>
                {
                    b.HasOne("Entities.Models.Customer", "Customer")
                        .WithMany("Interactions")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Entities.Models.Element", "Element")
                        .WithMany("Interactions")
                        .HasForeignKey("ElementId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Entities.Models.Session", "Session")
                        .WithMany("Interactions")
                        .HasForeignKey("SessionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Element");

                    b.Navigation("Session");
                });

            modelBuilder.Entity("Entities.Models.Session", b =>
                {
                    b.HasOne("Entities.Models.Customer", "Customer")
                        .WithMany("Sessions")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("Entities.Models.Customer", b =>
                {
                    b.Navigation("Interactions");

                    b.Navigation("Sessions");
                });

            modelBuilder.Entity("Entities.Models.Element", b =>
                {
                    b.Navigation("Interactions");
                });

            modelBuilder.Entity("Entities.Models.Session", b =>
                {
                    b.Navigation("Interactions");
                });
#pragma warning restore 612, 618
        }
    }
}
