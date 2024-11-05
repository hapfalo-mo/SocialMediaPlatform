using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Models.Migrations
{
    /// <inheritdoc />
    public partial class ChangeDataTypeOfPostStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Convert existing NULL values to the default integer value 0
            migrationBuilder.Sql("UPDATE post SET status = '0' WHERE status IS NULL;");

            // Convert the status column to integer with explicit type casting
            migrationBuilder.Sql("ALTER TABLE post ALTER COLUMN status TYPE integer USING status::integer;");

            // Set the column to NOT NULL and add a default value
            migrationBuilder.AlterColumn<int>(
                name: "status",
                table: "post",
                type: "integer",
                maxLength: 50,
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50,
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Change the column back to a string with appropriate type
            migrationBuilder.AlterColumn<string>(
                name: "status",
                table: "post",
                type: "character varying(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer",
                oldMaxLength: 50);
        }
    }
}
