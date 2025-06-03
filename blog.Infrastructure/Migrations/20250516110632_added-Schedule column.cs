using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace blog.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addedSchedulecolumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "tutorial_slug",
                table: "TblTutorial",
                type: "varchar(200)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(200)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "schedule",
                table: "TblTutorial",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "schedule",
                table: "TblTutorial");

            migrationBuilder.AlterColumn<string>(
                name: "tutorial_slug",
                table: "TblTutorial",
                type: "varchar(200)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(200)");
        }
    }
}
