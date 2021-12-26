using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PClub.Backend.WebAPI.Migrations
{
    public partial class GuidFix4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ClubUserId",
                table: "Entries",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Entries_ClubUserId",
                table: "Entries",
                column: "ClubUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Entries_ClubUsers_ClubUserId",
                table: "Entries",
                column: "ClubUserId",
                principalTable: "ClubUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entries_ClubUsers_ClubUserId",
                table: "Entries");

            migrationBuilder.DropIndex(
                name: "IX_Entries_ClubUserId",
                table: "Entries");

            migrationBuilder.DropColumn(
                name: "ClubUserId",
                table: "Entries");
        }
    }
}
