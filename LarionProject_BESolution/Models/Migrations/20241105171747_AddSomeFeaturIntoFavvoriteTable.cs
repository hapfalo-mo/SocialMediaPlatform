using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Models.Migrations
{
    /// <inheritdoc />
    public partial class AddSomeFeaturIntoFavvoriteTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreateAt",
                table: "favorites",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreateBy",
                table: "favorites",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImgUrl",
                table: "favorites",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "favorites",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateAt",
                table: "favorites");

            migrationBuilder.DropColumn(
                name: "CreateBy",
                table: "favorites");

            migrationBuilder.DropColumn(
                name: "ImgUrl",
                table: "favorites");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "favorites");
        }
    }
}
