using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NeSoyledi.Data.Migrations
{
    public partial class NewsAndReactionsAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "News",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NewsTitle = table.Column<string>(maxLength: 1000, nullable: true),
                    NewsContent = table.Column<string>(nullable: true),
                    NewsImage = table.Column<string>(maxLength: 255, nullable: true),
                    NewsVideo = table.Column<string>(maxLength: 1500, nullable: true),
                    NewsBefore = table.Column<string>(maxLength: 4000, nullable: true),
                    NewsAfter = table.Column<string>(maxLength: 4000, nullable: true),
                    CommentStatus = table.Column<bool>(nullable: false),
                    PostType = table.Column<string>(maxLength: 255, nullable: true),
                    PostAuthor = table.Column<string>(maxLength: 255, nullable: true),
                    PostAuthorIP = table.Column<string>(maxLength: 255, nullable: true),
                    PostSlug = table.Column<string>(maxLength: 1000, nullable: true),
                    PostDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    PostModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    PostReads = table.Column<int>(nullable: true),
                    PostShares = table.Column<int>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_News", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reactions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostId = table.Column<int>(nullable: false),
                    PostType = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: true),
                    UserIP = table.Column<string>(maxLength: 255, nullable: true),
                    ReactionDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reactions", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "News");

            migrationBuilder.DropTable(
                name: "Reactions");
        }
    }
}
