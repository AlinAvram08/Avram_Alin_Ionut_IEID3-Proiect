using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Avram_Alin_Proiect.Migrations
{
    public partial class AutoPartCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AutoPart_Car_CarID",
                table: "AutoPart");

            migrationBuilder.AlterColumn<int>(
                name: "CarID",
                table: "AutoPart",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "AutoPartCategory",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AutoPartID = table.Column<int>(type: "int", nullable: true),
                    CategoryID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutoPartCategory", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AutoPartCategory_AutoPart_AutoPartID",
                        column: x => x.AutoPartID,
                        principalTable: "AutoPart",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_AutoPartCategory_Category_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Category",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AutoPartCategory_AutoPartID",
                table: "AutoPartCategory",
                column: "AutoPartID");

            migrationBuilder.CreateIndex(
                name: "IX_AutoPartCategory_CategoryID",
                table: "AutoPartCategory",
                column: "CategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_AutoPart_Car_CarID",
                table: "AutoPart",
                column: "CarID",
                principalTable: "Car",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AutoPart_Car_CarID",
                table: "AutoPart");

            migrationBuilder.DropTable(
                name: "AutoPartCategory");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.AlterColumn<int>(
                name: "CarID",
                table: "AutoPart",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AutoPart_Car_CarID",
                table: "AutoPart",
                column: "CarID",
                principalTable: "Car",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
