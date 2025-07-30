using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SampleAspMvcEF.Migrations
{
    /// <inheritdoc />
    public partial class Tambah_Vid_TableCar_Unique : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "VId",
                table: "Car",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "UQ__Car__A2B0D9F1C3E4F5B6",
                table: "Car",
                column: "VId",
                unique: true,
                filter: "[VId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "UQ__Car__A2B0D9F1C3E4F5B6",
                table: "Car");

            migrationBuilder.DropColumn(
                name: "VId",
                table: "Car");
        }
    }
}
