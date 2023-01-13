using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Avram_Alin_Proiect.Migrations
{
    public partial class VIN : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "VeIdNumber",
                table: "Car",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VeIdNumber",
                table: "Car");
        }
    }
}
