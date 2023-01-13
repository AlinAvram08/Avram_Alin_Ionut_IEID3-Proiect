using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Avram_Alin_Proiect.Migrations
{
    public partial class Car : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CarID",
                table: "AutoPart",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Car",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Car", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AutoPart_CarID",
                table: "AutoPart",
                column: "CarID");

            migrationBuilder.AddForeignKey(
                name: "FK_AutoPart_Car_CarID",
                table: "AutoPart",
                column: "CarID",
                principalTable: "Car",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AutoPart_Car_CarID",
                table: "AutoPart");

            migrationBuilder.DropTable(
                name: "Car");

            migrationBuilder.DropIndex(
                name: "IX_AutoPart_CarID",
                table: "AutoPart");

            migrationBuilder.DropColumn(
                name: "CarID",
                table: "AutoPart");
        }
    }
}
