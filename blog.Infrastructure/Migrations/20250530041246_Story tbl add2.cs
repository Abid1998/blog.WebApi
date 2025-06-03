using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace blog.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Storytbladd2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WebStoryPage_TblWebStory_StoryId",
                table: "WebStoryPage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WebStoryPage",
                table: "WebStoryPage");

            migrationBuilder.RenameTable(
                name: "WebStoryPage",
                newName: "TblWebStoryPage");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "TblWebStory",
                newName: "title");

            migrationBuilder.RenameColumn(
                name: "Slug",
                table: "TblWebStory",
                newName: "slug");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "TblWebStory",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "CoverImageUrl",
                table: "TblWebStory",
                newName: "cover_image_url");

            migrationBuilder.RenameColumn(
                name: "StoryId",
                table: "TblWebStory",
                newName: "story_id");

            migrationBuilder.RenameColumn(
                name: "TextContent",
                table: "TblWebStoryPage",
                newName: "text_content");

            migrationBuilder.RenameColumn(
                name: "StoryId",
                table: "TblWebStoryPage",
                newName: "story_id");

            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "TblWebStoryPage",
                newName: "image_url");

            migrationBuilder.RenameColumn(
                name: "PageId",
                table: "TblWebStoryPage",
                newName: "page_id");

            migrationBuilder.RenameIndex(
                name: "IX_WebStoryPage_StoryId",
                table: "TblWebStoryPage",
                newName: "IX_TblWebStoryPage_story_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TblWebStoryPage",
                table: "TblWebStoryPage",
                column: "page_id");

            migrationBuilder.AddForeignKey(
                name: "FK_TblWebStoryPage_TblWebStory_story_id",
                table: "TblWebStoryPage",
                column: "story_id",
                principalTable: "TblWebStory",
                principalColumn: "story_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblWebStoryPage_TblWebStory_story_id",
                table: "TblWebStoryPage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TblWebStoryPage",
                table: "TblWebStoryPage");

            migrationBuilder.RenameTable(
                name: "TblWebStoryPage",
                newName: "WebStoryPage");

            migrationBuilder.RenameColumn(
                name: "title",
                table: "TblWebStory",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "slug",
                table: "TblWebStory",
                newName: "Slug");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "TblWebStory",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "cover_image_url",
                table: "TblWebStory",
                newName: "CoverImageUrl");

            migrationBuilder.RenameColumn(
                name: "story_id",
                table: "TblWebStory",
                newName: "StoryId");

            migrationBuilder.RenameColumn(
                name: "text_content",
                table: "WebStoryPage",
                newName: "TextContent");

            migrationBuilder.RenameColumn(
                name: "story_id",
                table: "WebStoryPage",
                newName: "StoryId");

            migrationBuilder.RenameColumn(
                name: "image_url",
                table: "WebStoryPage",
                newName: "ImageUrl");

            migrationBuilder.RenameColumn(
                name: "page_id",
                table: "WebStoryPage",
                newName: "PageId");

            migrationBuilder.RenameIndex(
                name: "IX_TblWebStoryPage_story_id",
                table: "WebStoryPage",
                newName: "IX_WebStoryPage_StoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WebStoryPage",
                table: "WebStoryPage",
                column: "PageId");

            migrationBuilder.AddForeignKey(
                name: "FK_WebStoryPage_TblWebStory_StoryId",
                table: "WebStoryPage",
                column: "StoryId",
                principalTable: "TblWebStory",
                principalColumn: "StoryId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
