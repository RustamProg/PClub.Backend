// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PClub.Backend.WebAPI.DataAccess;

namespace PClub.Backend.WebAPI.Migrations
{
    [DbContext(typeof(PClubDbContext))]
    partial class PClubDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PClub.Backend.Models.ClubUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecondName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ClubUsers");
                });

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

            modelBuilder.Entity("PClub.Backend.Models.Entry", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<Guid>("ClubUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<long>("ComputerId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("VisitEndDateTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("VisitStartDateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ClubUserId");

                    b.HasIndex("ComputerId");

                    b.ToTable("Entries");
                });

            modelBuilder.Entity("PClub.Backend.Models.Entry", b =>
                {
                    b.HasOne("PClub.Backend.Models.ClubUser", "ClubUser")
                        .WithMany()
                        .HasForeignKey("ClubUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PClub.Backend.Models.Computer", "Computer")
                        .WithMany()
                        .HasForeignKey("ComputerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ClubUser");

                    b.Navigation("Computer");
                });
#pragma warning restore 612, 618
        }
    }
}
