using Microsoft.EntityFrameworkCore.Migrations;

namespace FMS.Dal.Migrations
{
    public partial class AddedSomeLegacyFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FMS_skood",
                table: "Documents");

            migrationBuilder.AddColumn<int>(
                name: "BillingAddressId",
                table: "Documents",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "Documents",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FMS_dokid",
                table: "Documents",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ShippingAddressId",
                table: "Documents",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FMS_liikumid",
                table: "DocumentLines",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Documents_BillingAddressId",
                table: "Documents",
                column: "BillingAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_CustomerId",
                table: "Documents",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_ShippingAddressId",
                table: "Documents",
                column: "ShippingAddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_CustomerAddresses_BillingAddressId",
                table: "Documents",
                column: "BillingAddressId",
                principalTable: "CustomerAddresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_CustomerAddresses_ShippingAddressId",
                table: "Documents",
                column: "ShippingAddressId",
                principalTable: "CustomerAddresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_Customers_CustomerId",
                table: "Documents",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documents_CustomerAddresses_BillingAddressId",
                table: "Documents");

            migrationBuilder.DropForeignKey(
                name: "FK_Documents_CustomerAddresses_ShippingAddressId",
                table: "Documents");

            migrationBuilder.DropForeignKey(
                name: "FK_Documents_Customers_CustomerId",
                table: "Documents");

            migrationBuilder.DropIndex(
                name: "IX_Documents_BillingAddressId",
                table: "Documents");

            migrationBuilder.DropIndex(
                name: "IX_Documents_CustomerId",
                table: "Documents");

            migrationBuilder.DropIndex(
                name: "IX_Documents_ShippingAddressId",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "BillingAddressId",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "FMS_dokid",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "ShippingAddressId",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "FMS_liikumid",
                table: "DocumentLines");

            migrationBuilder.AddColumn<string>(
                name: "FMS_skood",
                table: "Documents",
                type: "nvarchar(6)",
                maxLength: 6,
                nullable: true);
        }
    }
}
