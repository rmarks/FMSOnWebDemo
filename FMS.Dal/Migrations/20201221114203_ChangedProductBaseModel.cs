using Microsoft.EntityFrameworkCore.Migrations;

namespace FMS.Dal.Migrations
{
    public partial class ChangedProductBaseModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductBases_BusinessLines_BusinessLineId",
                table: "ProductBases");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductBases_ProductDestinationTypes_ProductDestinationTypeId",
                table: "ProductBases");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductBases_ProductMaterials_ProductMaterialId",
                table: "ProductBases");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductBases_ProductSourceTypes_ProductSourceTypeId",
                table: "ProductBases");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductBases_ProductStatuses_ProductStatusId",
                table: "ProductBases");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductBases_ProductTypes_ProductTypeId",
                table: "ProductBases");

            migrationBuilder.AlterColumn<int>(
                name: "ProductTypeId",
                table: "ProductBases",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ProductStatusId",
                table: "ProductBases",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ProductSourceTypeId",
                table: "ProductBases",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ProductMaterialId",
                table: "ProductBases",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ProductDestinationTypeId",
                table: "ProductBases",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "BusinessLineId",
                table: "ProductBases",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductBases_BusinessLines_BusinessLineId",
                table: "ProductBases",
                column: "BusinessLineId",
                principalTable: "BusinessLines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductBases_ProductDestinationTypes_ProductDestinationTypeId",
                table: "ProductBases",
                column: "ProductDestinationTypeId",
                principalTable: "ProductDestinationTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductBases_ProductMaterials_ProductMaterialId",
                table: "ProductBases",
                column: "ProductMaterialId",
                principalTable: "ProductMaterials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductBases_ProductSourceTypes_ProductSourceTypeId",
                table: "ProductBases",
                column: "ProductSourceTypeId",
                principalTable: "ProductSourceTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductBases_ProductStatuses_ProductStatusId",
                table: "ProductBases",
                column: "ProductStatusId",
                principalTable: "ProductStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductBases_ProductTypes_ProductTypeId",
                table: "ProductBases",
                column: "ProductTypeId",
                principalTable: "ProductTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductBases_BusinessLines_BusinessLineId",
                table: "ProductBases");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductBases_ProductDestinationTypes_ProductDestinationTypeId",
                table: "ProductBases");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductBases_ProductMaterials_ProductMaterialId",
                table: "ProductBases");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductBases_ProductSourceTypes_ProductSourceTypeId",
                table: "ProductBases");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductBases_ProductStatuses_ProductStatusId",
                table: "ProductBases");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductBases_ProductTypes_ProductTypeId",
                table: "ProductBases");

            migrationBuilder.AlterColumn<int>(
                name: "ProductTypeId",
                table: "ProductBases",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProductStatusId",
                table: "ProductBases",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProductSourceTypeId",
                table: "ProductBases",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProductMaterialId",
                table: "ProductBases",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProductDestinationTypeId",
                table: "ProductBases",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BusinessLineId",
                table: "ProductBases",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductBases_BusinessLines_BusinessLineId",
                table: "ProductBases",
                column: "BusinessLineId",
                principalTable: "BusinessLines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductBases_ProductDestinationTypes_ProductDestinationTypeId",
                table: "ProductBases",
                column: "ProductDestinationTypeId",
                principalTable: "ProductDestinationTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductBases_ProductMaterials_ProductMaterialId",
                table: "ProductBases",
                column: "ProductMaterialId",
                principalTable: "ProductMaterials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductBases_ProductSourceTypes_ProductSourceTypeId",
                table: "ProductBases",
                column: "ProductSourceTypeId",
                principalTable: "ProductSourceTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductBases_ProductStatuses_ProductStatusId",
                table: "ProductBases",
                column: "ProductStatusId",
                principalTable: "ProductStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductBases_ProductTypes_ProductTypeId",
                table: "ProductBases",
                column: "ProductTypeId",
                principalTable: "ProductTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
