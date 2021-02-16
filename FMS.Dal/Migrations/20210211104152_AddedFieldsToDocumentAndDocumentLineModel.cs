using Microsoft.EntityFrameworkCore.Migrations;

namespace FMS.Dal.Migrations
{
    public partial class AddedFieldsToDocumentAndDocumentLineModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DeliveryTermName",
                table: "Documents",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FixedDiscountPercent",
                table: "Documents",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PaymentDays",
                table: "Documents",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "VATPercent",
                table: "Documents",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LineDiscountPercent",
                table: "DocumentLines",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "UnitPrice",
                table: "DocumentLines",
                type: "decimal(9,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeliveryTermName",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "FixedDiscountPercent",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "PaymentDays",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "VATPercent",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "LineDiscountPercent",
                table: "DocumentLines");

            migrationBuilder.DropColumn(
                name: "UnitPrice",
                table: "DocumentLines");
        }
    }
}
