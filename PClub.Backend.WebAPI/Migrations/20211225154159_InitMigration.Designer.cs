﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PClub.Backend.WebAPI.DataAccess;

namespace PClub.Backend.WebAPI.Migrations
{
    [DbContext(typeof(PClubDbContext))]
    [Migration("20211225154159_InitMigration")]
    partial class InitMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PClub.Backend.Models.Computer", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Cpu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Earphones")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gpu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Keypad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Monitor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mouse")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RAM")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Storage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Webcamera")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Computers");
                });
#pragma warning restore 612, 618
        }
    }
}