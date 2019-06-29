using Microsoft.EntityFrameworkCore.Migrations;

namespace JustInfo.Migrations
{
    public partial class scrap_comment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Scraps",
                columns: table => new
                {
                    ScrapId = table.Column<string>(nullable: false),
                    Post = table.Column<string>(maxLength: 5000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scraps", x => x.ScrapId);
                });

            migrationBuilder.CreateTable(
                name: "ScrapComments",
                columns: table => new
                {
                    CommentId = table.Column<string>(nullable: false),
                    CommentDescription = table.Column<string>(maxLength: 5000, nullable: false),
                    ScrapId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScrapComments", x => x.CommentId);
                    table.ForeignKey(
                        name: "FK_ScrapComments_Scraps_ScrapId",
                        column: x => x.ScrapId,
                        principalTable: "Scraps",
                        principalColumn: "ScrapId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ScrapComments_ScrapId",
                table: "ScrapComments",
                column: "ScrapId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ScrapComments");

            migrationBuilder.DropTable(
                name: "Scraps");
        }
    }
}
