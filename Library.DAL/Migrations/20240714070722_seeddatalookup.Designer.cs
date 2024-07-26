﻿// <auto-generated />
using System;
using Library.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Library.Migrations
{
    [DbContext(typeof(LibraryDbContext))]
    [Migration("20240714070722_seeddatalookup")]
    partial class seeddatalookup
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Library.Models.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ArabicName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FrenchName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ShelfId")
                        .HasColumnType("int");

                    b.Property<byte[]>("pdfContent")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("pdfFileName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("ShelfId");

                    b.ToTable("books");
                });

            modelBuilder.Entity("Library.Models.LookUp", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ArabicName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FrenchName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LookUpCategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("LookUpCategoryId");

                    b.ToTable("lookUp");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ArabicName = "دراما",
                            CreateAt = new DateTime(2024, 7, 14, 7, 7, 21, 30, DateTimeKind.Utc).AddTicks(7430),
                            FrenchName = "drame",
                            LookUpCategoryId = 1,
                            Name = "Drama"
                        },
                        new
                        {
                            Id = 2,
                            ArabicName = "أعمال",
                            CreateAt = new DateTime(2024, 7, 14, 7, 7, 21, 30, DateTimeKind.Utc).AddTicks(7432),
                            FrenchName = "entreprise",
                            LookUpCategoryId = 1,
                            Name = "business"
                        },
                        new
                        {
                            Id = 3,
                            ArabicName = "خيال علمي",
                            CreateAt = new DateTime(2024, 7, 14, 7, 7, 21, 30, DateTimeKind.Utc).AddTicks(7433),
                            FrenchName = "la science-fiction",
                            LookUpCategoryId = 1,
                            Name = "Science fiction"
                        },
                        new
                        {
                            Id = 4,
                            ArabicName = "فانتازي",
                            CreateAt = new DateTime(2024, 7, 14, 7, 7, 21, 30, DateTimeKind.Utc).AddTicks(7434),
                            FrenchName = "Fantaisie",
                            LookUpCategoryId = 1,
                            Name = "Fantasy"
                        },
                        new
                        {
                            Id = 5,
                            ArabicName = "تشويق",
                            CreateAt = new DateTime(2024, 7, 14, 7, 7, 21, 30, DateTimeKind.Utc).AddTicks(7435),
                            FrenchName = "le film à suspense",
                            LookUpCategoryId = 1,
                            Name = "Thriller"
                        },
                        new
                        {
                            Id = 6,
                            ArabicName = "غموض",
                            CreateAt = new DateTime(2024, 7, 14, 7, 7, 21, 30, DateTimeKind.Utc).AddTicks(7436),
                            FrenchName = "Mystère",
                            LookUpCategoryId = 1,
                            Name = "Mystery"
                        });
                });

            modelBuilder.Entity("Library.Models.LookUpCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Code")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("lookUpCategory");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Code = 1,
                            CreateAt = new DateTime(2024, 7, 14, 7, 7, 21, 30, DateTimeKind.Utc).AddTicks(7312),
                            Name = "TypeOfShelf"
                        });
                });

            modelBuilder.Entity("Library.Models.Shelf", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ArabicName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("BookCount")
                        .HasColumnType("int");

                    b.Property<string>("EnglishName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FrenchName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsAvalible")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("shelves");
                });

            modelBuilder.Entity("Library.Models.Book", b =>
                {
                    b.HasOne("Library.Models.Shelf", "shelf")
                        .WithMany()
                        .HasForeignKey("ShelfId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("shelf");
                });

            modelBuilder.Entity("Library.Models.LookUp", b =>
                {
                    b.HasOne("Library.Models.LookUpCategory", "LookUpCategory")
                        .WithMany("LookUps")
                        .HasForeignKey("LookUpCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LookUpCategory");
                });

            modelBuilder.Entity("Library.Models.LookUpCategory", b =>
                {
                    b.Navigation("LookUps");
                });
#pragma warning restore 612, 618
        }
    }
}