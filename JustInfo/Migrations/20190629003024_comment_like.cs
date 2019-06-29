using Microsoft.EntityFrameworkCore.Migrations;

namespace JustInfo.Migrations
{
    public partial class comment_like : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IdentityId",
                table: "Scraps",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IdentityId",
                table: "ScrapComments",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ScrapCommentLikes",
                columns: table => new
                {
                    ScrapCommentLikeId = table.Column<string>(nullable: false),
                    ScrapCommentId = table.Column<string>(nullable: true),
                    IdentityId = table.Column<string>(nullable: true),
                    UserInfoId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScrapCommentLikes", x => x.ScrapCommentLikeId);
                    table.ForeignKey(
                        name: "FK_ScrapCommentLikes_ScrapComments_ScrapCommentId",
                        column: x => x.ScrapCommentId,
                        principalTable: "ScrapComments",
                        principalColumn: "CommentId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ScrapCommentLikes_UserInfo_UserInfoId",
                        column: x => x.UserInfoId,
                        principalTable: "UserInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ScrapLikes",
                columns: table => new
                {
                    LikeId = table.Column<string>(nullable: false),
                    ScrapId = table.Column<string>(nullable: true),
                    IdentityId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScrapLikes", x => x.LikeId);
                    table.ForeignKey(
                        name: "FK_ScrapLikes_UserInfo_IdentityId",
                        column: x => x.IdentityId,
                        principalTable: "UserInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ScrapLikes_Scraps_ScrapId",
                        column: x => x.ScrapId,
                        principalTable: "Scraps",
                        principalColumn: "ScrapId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Scraps_IdentityId",
                table: "Scraps",
                column: "IdentityId");

            migrationBuilder.CreateIndex(
                name: "IX_ScrapComments_IdentityId",
                table: "ScrapComments",
                column: "IdentityId");

            migrationBuilder.CreateIndex(
                name: "IX_ScrapCommentLikes_ScrapCommentId",
                table: "ScrapCommentLikes",
                column: "ScrapCommentId");

            migrationBuilder.CreateIndex(
                name: "IX_ScrapCommentLikes_UserInfoId",
                table: "ScrapCommentLikes",
                column: "UserInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_ScrapLikes_IdentityId",
                table: "ScrapLikes",
                column: "IdentityId");

            migrationBuilder.CreateIndex(
                name: "IX_ScrapLikes_ScrapId",
                table: "ScrapLikes",
                column: "ScrapId");

            migrationBuilder.AddForeignKey(
                name: "FK_ScrapComments_UserInfo_IdentityId",
                table: "ScrapComments",
                column: "IdentityId",
                principalTable: "UserInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Scraps_UserInfo_IdentityId",
                table: "Scraps",
                column: "IdentityId",
                principalTable: "UserInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ScrapComments_UserInfo_IdentityId",
                table: "ScrapComments");

            migrationBuilder.DropForeignKey(
                name: "FK_Scraps_UserInfo_IdentityId",
                table: "Scraps");

            migrationBuilder.DropTable(
                name: "ScrapCommentLikes");

            migrationBuilder.DropTable(
                name: "ScrapLikes");

            migrationBuilder.DropIndex(
                name: "IX_Scraps_IdentityId",
                table: "Scraps");

            migrationBuilder.DropIndex(
                name: "IX_ScrapComments_IdentityId",
                table: "ScrapComments");

            migrationBuilder.DropColumn(
                name: "IdentityId",
                table: "Scraps");

            migrationBuilder.DropColumn(
                name: "IdentityId",
                table: "ScrapComments");
        }
    }
}
