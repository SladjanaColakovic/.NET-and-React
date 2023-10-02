﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using WebApplication_Backend.Model;

namespace WebApplication_Backend.Migrations
{
    [DbContext(typeof(MyDbContext))]
    partial class MyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityByDefaultColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("WebApplication_Backend.Model.Address", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("City")
                        .HasColumnType("text");

                    b.Property<string>("Country")
                        .HasColumnType("text");

                    b.Property<string>("Street")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Addresses");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            City = "Novi Sad",
                            Country = "Srbija",
                            Street = "Zmaj Jovina 1"
                        },
                        new
                        {
                            Id = 2L,
                            City = "Beograd",
                            Country = "Srbija",
                            Street = "Dunavksa 3"
                        });
                });

            modelBuilder.Entity("WebApplication_Backend.Model.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityByDefaultColumn();

                    b.Property<long>("AddressId")
                        .HasColumnType("bigint");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<string>("Role")
                        .HasColumnType("text");

                    b.Property<string>("Surname")
                        .HasColumnType("text");

                    b.Property<string>("Username")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            AddressId = 1L,
                            Email = "ana@gmail.com",
                            Name = "Ana",
                            Password = "123",
                            Role = "Seller",
                            Surname = "Bogdanovic",
                            Username = "ana"
                        },
                        new
                        {
                            Id = 2L,
                            AddressId = 2L,
                            Email = "luka@gmail.com",
                            Name = "Luka",
                            Password = "123",
                            Role = "Admin",
                            Surname = "Lukic",
                            Username = "luka"
                        });
                });

            modelBuilder.Entity("WebApplication_Backend.Model.User", b =>
                {
                    b.HasOne("WebApplication_Backend.Model.Address", "Address")
                        .WithMany("Users")
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");
                });

            modelBuilder.Entity("WebApplication_Backend.Model.Address", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
