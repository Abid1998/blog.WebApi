using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace blog.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class renamecommenttbl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TblCommnet",
                table: "TblCommnet");

            migrationBuilder.RenameTable(
                name: "TblCommnet",
                newName: "TblComment");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TblComment",
                table: "TblComment",
                column: "comment_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TblComment",
                table: "TblComment");

            migrationBuilder.RenameTable(
                name: "TblComment",
                newName: "TblCommnet");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TblCommnet",
                table: "TblCommnet",
                column: "comment_id");
        }
    }
}
