using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RealManager.Repositories.Migrations
{
    public partial class AddForeignKeyPlayer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "TeamDbId",
                table: "Players",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Players_TeamDbId",
                table: "Players",
                column: "TeamDbId");

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Teams_TeamDbId",
                table: "Players",
                column: "TeamDbId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_Teams_TeamDbId",
                table: "Players");

            migrationBuilder.DropIndex(
                name: "IX_Players_TeamDbId",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "TeamDbId",
                table: "Players");
        }
    }
}
