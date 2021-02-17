using Microsoft.EntityFrameworkCore.Migrations;

namespace FMS.Dal.Migrations
{
    public partial class ChangedFieldToPaymentDaysInCustomerModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_PaymentTerms_PaymentTermId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_PaymentTermId",
                table: "Customers");

            migrationBuilder.RenameColumn(
                name: "PaymentTermId",
                table: "Customers",
                newName: "PaymentDays");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PaymentDays",
                table: "Customers",
                newName: "PaymentTermId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_PaymentTermId",
                table: "Customers",
                column: "PaymentTermId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_PaymentTerms_PaymentTermId",
                table: "Customers",
                column: "PaymentTermId",
                principalTable: "PaymentTerms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
