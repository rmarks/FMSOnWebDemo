using Microsoft.EntityFrameworkCore.Migrations;

namespace FMS.Dal.Migrations
{
    public partial class ChangedSalesOrderLineModel2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalesOrderLines_Warehouses_WarehouseId",
                table: "SalesOrderLines");

            migrationBuilder.AlterColumn<int>(
                name: "WarehouseId",
                table: "SalesOrderLines",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_SalesOrderLines_Warehouses_WarehouseId",
                table: "SalesOrderLines",
                column: "WarehouseId",
                principalTable: "Warehouses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalesOrderLines_Warehouses_WarehouseId",
                table: "SalesOrderLines");

            migrationBuilder.AlterColumn<int>(
                name: "WarehouseId",
                table: "SalesOrderLines",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesOrderLines_Warehouses_WarehouseId",
                table: "SalesOrderLines",
                column: "WarehouseId",
                principalTable: "Warehouses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
