using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FMS.Dal.Migrations
{
    public partial class WarehouseModelReplacedWithLocationModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventory_Warehouses_WarehouseId",
                table: "Inventory");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesOrderLines_Warehouses_WarehouseId",
                table: "SalesOrderLines");

            migrationBuilder.DropTable(
                name: "Warehouses");

            migrationBuilder.RenameColumn(
                name: "WarehouseId",
                table: "SalesOrderLines",
                newName: "LocationId");

            migrationBuilder.RenameIndex(
                name: "IX_SalesOrderLines_WarehouseId",
                table: "SalesOrderLines",
                newName: "IX_SalesOrderLines_LocationId");

            migrationBuilder.RenameColumn(
                name: "WarehouseId",
                table: "Inventory",
                newName: "LocationId");

            migrationBuilder.RenameIndex(
                name: "IX_Inventory_WarehouseId",
                table: "Inventory",
                newName: "IX_Inventory_LocationId");

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LocationTypeId = table.Column<int>(type: "int", nullable: false),
                    FMS_lkood = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    FMS_skood = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LocationTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationTypes", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Inventory_Locations_LocationId",
                table: "Inventory",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesOrderLines_Locations_LocationId",
                table: "SalesOrderLines",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventory_Locations_LocationId",
                table: "Inventory");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesOrderLines_Locations_LocationId",
                table: "SalesOrderLines");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "LocationTypes");

            migrationBuilder.RenameColumn(
                name: "LocationId",
                table: "SalesOrderLines",
                newName: "WarehouseId");

            migrationBuilder.RenameIndex(
                name: "IX_SalesOrderLines_LocationId",
                table: "SalesOrderLines",
                newName: "IX_SalesOrderLines_WarehouseId");

            migrationBuilder.RenameColumn(
                name: "LocationId",
                table: "Inventory",
                newName: "WarehouseId");

            migrationBuilder.RenameIndex(
                name: "IX_Inventory_LocationId",
                table: "Inventory",
                newName: "IX_Inventory_WarehouseId");

            migrationBuilder.CreateTable(
                name: "Warehouses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FMS_lkood = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warehouses", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Inventory_Warehouses_WarehouseId",
                table: "Inventory",
                column: "WarehouseId",
                principalTable: "Warehouses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesOrderLines_Warehouses_WarehouseId",
                table: "SalesOrderLines",
                column: "WarehouseId",
                principalTable: "Warehouses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
