using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PropertyPro.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class PropertyDataBase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Units",
                type: "NVARCHAR(4000)",
                maxLength: 4000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR(5000)",
                oldMaxLength: 5000);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Units",
                type: "NVARCHAR(5000)",
                maxLength: 5000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR(4000)",
                oldMaxLength: 4000);
        }
    }
}
