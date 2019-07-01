using Microsoft.EntityFrameworkCore.Migrations;

namespace JustInfo.Migrations
{
    public partial class contexti : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Scraps_UserInfo_IdentityId",
                table: "Scraps");

            migrationBuilder.DropIndex(
                name: "IX_Scraps_IdentityId",
                table: "Scraps");

            migrationBuilder.AlterColumn<string>(
                name: "IdentityId",
                table: "Scraps",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserInfoId",
                table: "Scraps",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Scraps_UserInfoId",
                table: "Scraps",
                column: "UserInfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Scraps_UserInfo_UserInfoId",
                table: "Scraps",
                column: "UserInfoId",
                principalTable: "UserInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Scraps_UserInfo_UserInfoId",
                table: "Scraps");

            migrationBuilder.DropIndex(
                name: "IX_Scraps_UserInfoId",
                table: "Scraps");

            migrationBuilder.DropColumn(
                name: "UserInfoId",
                table: "Scraps");

            migrationBuilder.AlterColumn<string>(
                name: "IdentityId",
                table: "Scraps",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Scraps_IdentityId",
                table: "Scraps",
                column: "IdentityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Scraps_UserInfo_IdentityId",
                table: "Scraps",
                column: "IdentityId",
                principalTable: "UserInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
