﻿// <auto-generated />
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
    [Migration("20240708150712_restart")]
    partial class restart
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

                    b.Property<string>("FrenchName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ShelfId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ShelfId");

                    b.ToTable("books");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ArabicName = "الاب الفقير و الغني",
                            FrenchName = "Papa riche, papa pauvre",
                            Name = "Rich Dad Poor Dad",
                            ShelfId = 1
                        },
                        new
                        {
                            Id = 2,
                            ArabicName = "في دم بارد",
                            FrenchName = "De sang-froid",
                            Name = "In Cold Blood",
                            ShelfId = 2
                        },
                        new
                        {
                            Id = 3,
                            ArabicName = "الظلام في المدينة",
                            FrenchName = "L'ombre dans la ville",
                            Name = "The shadow in the city",
                            ShelfId = 3
                        },
                        new
                        {
                            Id = 4,
                            ArabicName = "الحديقة",
                            FrenchName = "le jardin",
                            Name = "The Garden",
                            ShelfId = 3
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

                    b.Property<string>("EnglishName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FrenchName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("shelves");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ArabicName = "المالية",
                            EnglishName = "Finance",
                            FrenchName = "financement"
                        },
                        new
                        {
                            Id = 2,
                            ArabicName = "جريمة",
                            EnglishName = "Crime",
                            FrenchName = "criminalité "
                        },
                        new
                        {
                            Id = 3,
                            ArabicName = "دراما",
                            EnglishName = "Drama",
                            FrenchName = "dramatique"
                        });
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
#pragma warning restore 612, 618
        }
    }
}
