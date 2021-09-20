using Microsoft.EntityFrameworkCore.Migrations;

namespace NeSoyledi.Data.Migrations
{
    public partial class CommentEntitieUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CommentPostSlug",
                table: "Comments",
                maxLength: 1000,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CommentPostTitle",
                table: "Comments",
                maxLength: 1000,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CommentPostSlug",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "CommentPostTitle",
                table: "Comments");
        }
    }
}
