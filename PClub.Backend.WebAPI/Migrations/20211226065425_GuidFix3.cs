using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PClub.Backend.WebAPI.Migrations
{
    public partial class GuidFix3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entries_ClubUsers_ClubUserId1",
                table: "Entries");

            migrationBuilder.DropIndex(
                name: "IX_Entries_ClubUserId1",
                table: "Entries");

            migrationBuilder.DropColumn(
                name: "ClubUserId",
                table: "Entries");

            migrationBuilder.DropColumn(
                name: "ClubUserId1",
                table: "Entries");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ClubUserId",
                table: "Entries",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<Guid>(
                name: "ClubUserId1",
                table: "Entries",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Entries_ClubUserId1",
                table: "Entries",
                column: "ClubUserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Entries_ClubUsers_ClubUserId1",
                table: "Entries",
                column: "ClubUserId1",
                principalTable: "ClubUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
