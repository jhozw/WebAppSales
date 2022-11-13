using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppWebMvcSales.Migrations
{
    public partial class create_tables_FK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seller_Departament_Departamentid",
                table: "Seller");

            migrationBuilder.DropForeignKey(
                name: "FK_SellersRecord_Seller_SellerId",
                table: "SellersRecord");

            migrationBuilder.RenameColumn(
                name: "Departamentid",
                table: "Seller",
                newName: "DepartamentId");

            migrationBuilder.RenameIndex(
                name: "IX_Seller_Departamentid",
                table: "Seller",
                newName: "IX_Seller_DepartamentId");

            migrationBuilder.AlterColumn<int>(
                name: "SellerId",
                table: "SellersRecord",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DepartamentId",
                table: "Seller",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Seller_Departament_DepartamentId",
                table: "Seller",
                column: "DepartamentId",
                principalTable: "Departament",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SellersRecord_Seller_SellerId",
                table: "SellersRecord",
                column: "SellerId",
                principalTable: "Seller",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seller_Departament_DepartamentId",
                table: "Seller");

            migrationBuilder.DropForeignKey(
                name: "FK_SellersRecord_Seller_SellerId",
                table: "SellersRecord");

            migrationBuilder.RenameColumn(
                name: "DepartamentId",
                table: "Seller",
                newName: "Departamentid");

            migrationBuilder.RenameIndex(
                name: "IX_Seller_DepartamentId",
                table: "Seller",
                newName: "IX_Seller_Departamentid");

            migrationBuilder.AlterColumn<int>(
                name: "SellerId",
                table: "SellersRecord",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Departamentid",
                table: "Seller",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Seller_Departament_Departamentid",
                table: "Seller",
                column: "Departamentid",
                principalTable: "Departament",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_SellersRecord_Seller_SellerId",
                table: "SellersRecord",
                column: "SellerId",
                principalTable: "Seller",
                principalColumn: "Id");
        }
    }
}
