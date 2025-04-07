using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PropertyPro.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class editUserPhotoColumnType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Photo",
                table: "AspNetUsers",
                type: "NVARCHAR(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "Photo",
                table: "AspNetUsers",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR(200)",
                oldMaxLength: 200,
                oldNullable: true);
        }
    }
}
