using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PClub.Backend.WebAPI.Migrations
{
    public partial class TablesReady : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClubUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecondName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClubUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Entries",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VisitStartDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VisitEndDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ComputerId = table.Column<long>(type: "bigint", nullable: false),
                    ClubUserId = table.Column<long>(type: "bigint", nullable: false),
                    ClubUserId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Entries_ClubUsers_ClubUserId1",
                        column: x => x.ClubUserId1,
                        principalTable: "ClubUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Entries_Computers_ComputerId",
                        column: x => x.ComputerId,
                        principalTable: "Computers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Entries_ClubUserId1",
                table: "Entries",
                column: "ClubUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Entries_ComputerId",
                table: "Entries",
                column: "ComputerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Entries");

            migrationBuilder.DropTable(
                name: "ClubUsers");
        }
    }
}
