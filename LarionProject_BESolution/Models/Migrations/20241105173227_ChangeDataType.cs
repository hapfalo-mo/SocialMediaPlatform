using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Models.Migrations
{
    /// <inheritdoc />
    public partial class ChangeDataType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Convert 'Status' column to integer
            migrationBuilder.Sql("ALTER TABLE favorites ALTER COLUMN \"Status\" TYPE integer USING \"Status\"::integer");

            // Convert 'CreateBy' column to integer
            migrationBuilder.Sql("ALTER TABLE favorites ALTER COLUMN \"CreateBy\" TYPE integer USING \"CreateBy\"::integer");

            // Convert 'CreateAt' column to timestamp with time zone
            migrationBuilder.Sql("ALTER TABLE favorites ALTER COLUMN \"CreateAt\" TYPE timestamp with time zone USING \"CreateAt\"::timestamp with time zone");
        }
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Revert 'Status' column back to text
            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "favorites",
                type: "text",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            // Revert 'CreateBy' column back to text
            migrationBuilder.AlterColumn<string>(
                name: "CreateBy",
                table: "favorites",
                type: "text",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            // Revert 'CreateAt' column back to text
            migrationBuilder.AlterColumn<string>(
                name: "CreateAt",
                table: "favorites",
                type: "text",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);
        }
    }
}
