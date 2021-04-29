using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NeSoyledi.Data.Migrations
{
    public partial class DbCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(maxLength: 255, nullable: true),
                    CategoryDescription = table.Column<string>(nullable: true),
                    CategorySlug = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Options",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OptionName = table.Column<string>(maxLength: 500, nullable: true),
                    OptionValue = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Options", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Organizations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrganizationName = table.Column<string>(maxLength: 255, nullable: true),
                    OrganizationHistory = table.Column<string>(nullable: true),
                    OrganizationLogo = table.Column<string>(maxLength: 255, nullable: true),
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
                    table.PrimaryKey("PK_Organizations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Profiles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfileName = table.Column<string>(maxLength: 255, nullable: true),
                    ProfileTitle = table.Column<string>(maxLength: 255, nullable: true),
                    ProfileBio = table.Column<string>(nullable: true),
                    ProfileImage = table.Column<string>(maxLength: 255, nullable: true),
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
                    table.PrimaryKey("PK_Profiles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserNameSurname = table.Column<string>(maxLength: 255, nullable: true),
                    UserLoginName = table.Column<string>(maxLength: 255, nullable: true),
                    UserNiceName = table.Column<string>(maxLength: 255, nullable: true),
                    UserEmail = table.Column<string>(maxLength: 255, nullable: true),
                    UserPass = table.Column<string>(maxLength: 255, nullable: true),
                    UserUrl = table.Column<string>(maxLength: 100, nullable: true),
                    UserAvatar = table.Column<string>(maxLength: 100, nullable: true),
                    UserGender = table.Column<string>(maxLength: 255, nullable: true),
                    UserBirthday = table.Column<string>(maxLength: 255, nullable: true),
                    UserRegistered = table.Column<DateTime>(type: "datetime", nullable: false),
                    UserActivationKey = table.Column<string>(maxLength: 255, nullable: true),
                    UserStatus = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Versus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VersusTitle = table.Column<string>(maxLength: 1000, nullable: true),
                    VersusContent = table.Column<string>(nullable: true),
                    DiscourseId1 = table.Column<int>(nullable: false),
                    DiscourseId2 = table.Column<int>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false),
                    VersusImage = table.Column<string>(maxLength: 255, nullable: true),
                    VersusVideo = table.Column<string>(maxLength: 1500, nullable: true),
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
                    table.PrimaryKey("PK_Versus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Versus_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommentPostId = table.Column<int>(nullable: false),
                    CommentPostType = table.Column<string>(maxLength: 255, nullable: true),
                    CommentContent = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: true),
                    UserIP = table.Column<string>(maxLength: 255, nullable: true),
                    UserName = table.Column<string>(maxLength: 255, nullable: true),
                    UserEmail = table.Column<string>(maxLength: 255, nullable: true),
                    UserAgent = table.Column<string>(maxLength: 255, nullable: true),
                    CommentStatus = table.Column<bool>(nullable: false),
                    CommentParent = table.Column<int>(nullable: true),
                    CommentDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Discourses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiscourseTitle = table.Column<string>(maxLength: 1000, nullable: true),
                    DiscourseContent = table.Column<string>(nullable: true),
                    ProfileId = table.Column<int>(nullable: true),
                    UserId = table.Column<int>(nullable: true),
                    OrganizationId = table.Column<int>(nullable: true),
                    CategoryId = table.Column<int>(nullable: false),
                    DiscourseImage = table.Column<string>(maxLength: 255, nullable: true),
                    DiscourseVideo = table.Column<string>(maxLength: 1500, nullable: true),
                    DiscourseBefore = table.Column<string>(maxLength: 4000, nullable: true),
                    DiscourseAfter = table.Column<string>(maxLength: 4000, nullable: true),
                    DiscourseSourceName = table.Column<string>(maxLength: 255, nullable: true),
                    DiscourseSourceUrl = table.Column<string>(maxLength: 500, nullable: true),
                    DiscourseDate = table.Column<DateTime>(type: "datetime", nullable: false),
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
                    table.PrimaryKey("PK_Discourses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Discourses_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Discourses_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Discourses_Profiles_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Discourses_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Discourses_CategoryId",
                table: "Discourses",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Discourses_OrganizationId",
                table: "Discourses",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Discourses_ProfileId",
                table: "Discourses",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Discourses_UserId",
                table: "Discourses",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Versus_CategoryId",
                table: "Versus",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Discourses");

            migrationBuilder.DropTable(
                name: "Options");

            migrationBuilder.DropTable(
                name: "Versus");

            migrationBuilder.DropTable(
                name: "Organizations");

            migrationBuilder.DropTable(
                name: "Profiles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
