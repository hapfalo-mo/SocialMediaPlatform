using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Models.Migrations
{
    /// <inheritdoc />
    public partial class Create_Connect_Between_Post_Comment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PostId",
                table: "comments",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_comments_PostId",
                table: "comments",
                column: "PostId");

            migrationBuilder.AddForeignKey(
                name: "comments_post_id_fkey",
                table: "comments",
                column: "PostId",
                principalTable: "post",
                principalColumn: "post_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "comments_post_id_fkey",
                table: "comments");

            migrationBuilder.DropIndex(
                name: "IX_comments_PostId",
                table: "comments");

            migrationBuilder.DropColumn(
                name: "PostId",
                table: "comments");
        }
    }
}
