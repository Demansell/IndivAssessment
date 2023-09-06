﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace IndivAssessment.Migrations
{
    [DbContext(typeof(IndivAssessmentDbContext))]
    [Migration("20230906183210_trieddeletingIcollevtion")]
    partial class trieddeletingIcollevtion
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("IndivAssessment.Models.Artist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Age")
                        .HasColumnType("integer");

                    b.Property<string>("Bio")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Artists");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Age = 27,
                            Bio = "Sample Bio",
                            Name = "Michael Jackson"
                        },
                        new
                        {
                            Id = 2,
                            Age = 50,
                            Bio = "Sample Bio",
                            Name = "Elvis"
                        },
                        new
                        {
                            Id = 3,
                            Age = 32,
                            Bio = "Sample Bio",
                            Name = "Montana of 300"
                        },
                        new
                        {
                            Id = 4,
                            Age = 29,
                            Bio = "Sample Bio",
                            Name = "Lil Wayne"
                        });
                });

            modelBuilder.Entity("IndivAssessment.Models.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Genres");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "This is pop"
                        },
                        new
                        {
                            Id = 2,
                            Description = "This is rock"
                        },
                        new
                        {
                            Id = 3,
                            Description = "This is drill rap"
                        },
                        new
                        {
                            Id = 4,
                            Description = "This is hip hop"
                        });
                });

            modelBuilder.Entity("IndivAssessment.Models.Song", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Album")
                        .HasColumnType("text");

                    b.Property<int>("ArtistId")
                        .HasColumnType("integer");

                    b.Property<int?>("GenreId")
                        .HasColumnType("integer");

                    b.Property<int?>("Length")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ArtistId");

                    b.HasIndex("GenreId");

                    b.ToTable("Songs");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Album = "Thriller 25",
                            ArtistId = 1,
                            Length = 110,
                            Title = "Beat it"
                        },
                        new
                        {
                            Id = 2,
                            Album = "Jail house rock",
                            ArtistId = 2,
                            Length = 130,
                            Title = "Jail house rock"
                        },
                        new
                        {
                            Id = 3,
                            Album = "Fire in the church",
                            ArtistId = 3,
                            Length = 170,
                            Title = "Fire in the church"
                        },
                        new
                        {
                            Id = 4,
                            Album = "Tha carter 3",
                            ArtistId = 4,
                            Length = 140,
                            Title = "A mili"
                        });
                });

            modelBuilder.Entity("IndivAssessment.Models.SongGenre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("GenreId")
                        .HasColumnType("integer");

                    b.Property<int>("SongId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("SongGenre");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            GenreId = 1,
                            SongId = 1
                        },
                        new
                        {
                            Id = 2,
                            GenreId = 2,
                            SongId = 2
                        },
                        new
                        {
                            Id = 3,
                            GenreId = 3,
                            SongId = 3
                        },
                        new
                        {
                            Id = 4,
                            GenreId = 4,
                            SongId = 4
                        });
                });

            modelBuilder.Entity("IndivAssessment.Models.Song", b =>
                {
                    b.HasOne("IndivAssessment.Models.Artist", null)
                        .WithMany("Songs")
                        .HasForeignKey("ArtistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IndivAssessment.Models.Genre", null)
                        .WithMany("Songs")
                        .HasForeignKey("GenreId");
                });

            modelBuilder.Entity("IndivAssessment.Models.Artist", b =>
                {
                    b.Navigation("Songs");
                });

            modelBuilder.Entity("IndivAssessment.Models.Genre", b =>
                {
                    b.Navigation("Songs");
                });
#pragma warning restore 612, 618
        }
    }
}
