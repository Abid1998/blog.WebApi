using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace blog.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class new202505082 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblTags_TblTutorial_tutorial_id1",
                table: "TblTags");

            migrationBuilder.DropIndex(
                name: "IX_TblTags_tutorial_id1",
                table: "TblTags");

            migrationBuilder.DropColumn(
                name: "tutorial_id1",
                table: "TblTags");

            migrationBuilder.AlterColumn<int>(
                name: "tutorial_id",
                table: "TblTags",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TblTags_tutorial_id",
                table: "TblTags",
                column: "tutorial_id");

            migrationBuilder.AddForeignKey(
                name: "FK_TblTags_TblTutorial_tutorial_id",
                table: "TblTags",
                column: "tutorial_id",
                principalTable: "TblTutorial",
                principalColumn: "tutorial_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblTags_TblTutorial_tutorial_id",
                table: "TblTags");

            migrationBuilder.DropIndex(
                name: "IX_TblTags_tutorial_id",
                table: "TblTags");

            migrationBuilder.AlterColumn<int>(
                name: "tutorial_id",
                table: "TblTags",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "tutorial_id1",
                table: "TblTags",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TblTags_tutorial_id1",
                table: "TblTags",
                column: "tutorial_id1");

            migrationBuilder.AddForeignKey(
                name: "FK_TblTags_TblTutorial_tutorial_id1",
                table: "TblTags",
                column: "tutorial_id1",
                principalTable: "TblTutorial",
                principalColumn: "tutorial_id");
        }
    }
}
