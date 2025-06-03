using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace blog.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class new20250508 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TblCategories",
                columns: table => new
                {
                    category_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    category_name = table.Column<string>(type: "varchar(50)", nullable: true),
                    category_slug = table.Column<string>(type: "varchar(60)", nullable: true),
                    category_meta = table.Column<string>(type: "varchar(200)", nullable: true),
                    category_description = table.Column<string>(type: "varchar(MAX)", nullable: true),
                    category_image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    category_tags = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    category_type = table.Column<string>(type: "varchar(20)", nullable: false),
                    status = table.Column<string>(type: "varchar(20)", nullable: false),
                    created_at = table.Column<DateOnly>(type: "date", nullable: false),
                    created_by = table.Column<int>(type: "int", nullable: false),
                    updated_at = table.Column<DateOnly>(type: "date", nullable: true),
                    updated_by = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblCategories", x => x.category_id);
                });

            migrationBuilder.CreateTable(
                name: "TblCommnet",
                columns: table => new
                {
                    comment_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    comment_name = table.Column<string>(type: "varchar(100)", nullable: true),
                    comment_email = table.Column<string>(type: "varchar(50)", nullable: true),
                    comment_phone = table.Column<string>(type: "varchar(15)", nullable: true),
                    comment_url = table.Column<string>(type: "varchar(50)", nullable: true),
                    comment_message = table.Column<string>(type: "varchar(300)", nullable: true),
                    comment_reply = table.Column<string>(type: "varchar(300)", nullable: true),
                    tutorial_id = table.Column<int>(type: "int", nullable: false),
                    status = table.Column<string>(type: "varchar(20)", nullable: false),
                    created_at = table.Column<DateOnly>(type: "date", nullable: false),
                    created_by = table.Column<int>(type: "int", nullable: false),
                    updated_at = table.Column<DateOnly>(type: "date", nullable: true),
                    updated_by = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblCommnet", x => x.comment_id);
                });

            migrationBuilder.CreateTable(
                name: "TblTutorial",
                columns: table => new
                {
                    tutorial_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tutorial_title = table.Column<string>(type: "varchar(200)", nullable: false),
                    tutorial_slug = table.Column<string>(type: "varchar(200)", nullable: false),
                    tutorial_meta = table.Column<string>(type: "varchar(200)", nullable: false),
                    tutorial_image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    category_id = table.Column<int>(type: "int", nullable: false),
                    status = table.Column<string>(type: "varchar(20)", nullable: false),
                    created_at = table.Column<DateOnly>(type: "date", nullable: false),
                    created_by = table.Column<int>(type: "int", nullable: false),
                    updated_at = table.Column<DateOnly>(type: "date", nullable: true),
                    updated_by = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblTutorial", x => x.tutorial_id);
                    table.ForeignKey(
                        name: "FK_TblTutorial_TblCategories_category_id",
                        column: x => x.category_id,
                        principalTable: "TblCategories",
                        principalColumn: "category_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TblGallery",
                columns: table => new
                {
                    gallery_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    gallery_img = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    tutorial_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblGallery", x => x.gallery_id);
                    table.ForeignKey(
                        name: "FK_TblGallery_TblTutorial_tutorial_id",
                        column: x => x.tutorial_id,
                        principalTable: "TblTutorial",
                        principalColumn: "tutorial_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TblTags",
                columns: table => new
                {
                    tag_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tag_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    tutorial_id = table.Column<int>(type: "int", nullable: true),
                    tutorial_id1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblTags", x => x.tag_id);
                    table.ForeignKey(
                        name: "FK_TblTags_TblTutorial_tutorial_id1",
                        column: x => x.tutorial_id1,
                        principalTable: "TblTutorial",
                        principalColumn: "tutorial_id");
                });

            migrationBuilder.CreateTable(
                name: "TblTutorial_Details",
                columns: table => new
                {
                    tutorial_details_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tutorial_description = table.Column<string>(type: "varchar(200)", nullable: true),
                    languages = table.Column<int>(type: "int", nullable: false),
                    tutorial_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblTutorial_Details", x => x.tutorial_details_id);
                    table.ForeignKey(
                        name: "FK_TblTutorial_Details_TblTutorial_tutorial_id",
                        column: x => x.tutorial_id,
                        principalTable: "TblTutorial",
                        principalColumn: "tutorial_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TblGallery_tutorial_id",
                table: "TblGallery",
                column: "tutorial_id");

            migrationBuilder.CreateIndex(
                name: "IX_TblTags_tutorial_id1",
                table: "TblTags",
                column: "tutorial_id1");

            migrationBuilder.CreateIndex(
                name: "IX_TblTutorial_category_id",
                table: "TblTutorial",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_TblTutorial_Details_tutorial_id",
                table: "TblTutorial_Details",
                column: "tutorial_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TblCommnet");

            migrationBuilder.DropTable(
                name: "TblGallery");

            migrationBuilder.DropTable(
                name: "TblTags");

            migrationBuilder.DropTable(
                name: "TblTutorial_Details");

            migrationBuilder.DropTable(
                name: "TblTutorial");

            migrationBuilder.DropTable(
                name: "TblCategories");
        }
    }
}
