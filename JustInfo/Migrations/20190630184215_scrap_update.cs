using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JustInfo.Migrations
{
    public partial class scrap_update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedTime",
                table: "UserInfo",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedTime",
                table: "Scraps",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CommentTime",
                table: "ScrapComments",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedTime",
                table: "UserInfo");

            migrationBuilder.DropColumn(
                name: "CreatedTime",
                table: "Scraps");

            migrationBuilder.DropColumn(
                name: "CommentTime",
                table: "ScrapComments");
        }
    }
}
