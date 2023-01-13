using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Avram_Alin_Proiect.Migrations
{
    public partial class supplier : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AutoPartCategory_AutoPart_AutoPartID",
                table: "AutoPartCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_AutoPartCategory_Category_CategoryID",
                table: "AutoPartCategory");

            migrationBuilder.DropColumn(
                name: "Supplier",
                table: "AutoPart");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryID",
                table: "AutoPartCategory",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AutoPartID",
                table: "AutoPartCategory",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AutoPart",
                type: "nvarchar(120)",
                maxLength: 120,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "SuplierID",
                table: "AutoPart",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SupplierID",
                table: "AutoPart",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Supplier",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TaxID = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supplier", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AutoPart_SupplierID",
                table: "AutoPart",
                column: "SupplierID");

            migrationBuilder.AddForeignKey(
                name: "FK_AutoPart_Supplier_SupplierID",
                table: "AutoPart",
                column: "SupplierID",
                principalTable: "Supplier",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_AutoPartCategory_AutoPart_AutoPartID",
                table: "AutoPartCategory",
                column: "AutoPartID",
                principalTable: "AutoPart",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AutoPartCategory_Category_CategoryID",
                table: "AutoPartCategory",
                column: "CategoryID",
                principalTable: "Category",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AutoPart_Supplier_SupplierID",
                table: "AutoPart");

            migrationBuilder.DropForeignKey(
                name: "FK_AutoPartCategory_AutoPart_AutoPartID",
                table: "AutoPartCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_AutoPartCategory_Category_CategoryID",
                table: "AutoPartCategory");

            migrationBuilder.DropTable(
                name: "Supplier");

            migrationBuilder.DropIndex(
                name: "IX_AutoPart_SupplierID",
                table: "AutoPart");

            migrationBuilder.DropColumn(
                name: "SuplierID",
                table: "AutoPart");

            migrationBuilder.DropColumn(
                name: "SupplierID",
                table: "AutoPart");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryID",
                table: "AutoPartCategory",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AutoPartID",
                table: "AutoPartCategory",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AutoPart",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(120)",
                oldMaxLength: 120);

            migrationBuilder.AddColumn<string>(
                name: "Supplier",
                table: "AutoPart",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_AutoPartCategory_AutoPart_AutoPartID",
                table: "AutoPartCategory",
                column: "AutoPartID",
                principalTable: "AutoPart",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_AutoPartCategory_Category_CategoryID",
                table: "AutoPartCategory",
                column: "CategoryID",
                principalTable: "Category",
                principalColumn: "ID");
        }
    }
}
