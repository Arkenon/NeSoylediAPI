using Microsoft.EntityFrameworkCore.Migrations;

namespace NeSoyledi.Data.Migrations
{
    public partial class ReactionEntitieEdit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReactionType",
                table: "Reactions",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReactionType",
                table: "Reactions");
        }
    }
}
