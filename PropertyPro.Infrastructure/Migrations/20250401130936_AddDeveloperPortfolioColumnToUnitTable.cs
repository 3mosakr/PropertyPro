using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PropertyPro.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddDeveloperPortfolioColumnToUnitTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DeveloperPortfolio",
                table: "Units",
                type: "NVARCHAR(150)",
                maxLength: 150,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeveloperPortfolio",
                table: "Units");
        }
    }
}
