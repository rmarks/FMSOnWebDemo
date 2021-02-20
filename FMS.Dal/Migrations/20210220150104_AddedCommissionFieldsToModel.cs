using Microsoft.EntityFrameworkCore.Migrations;

namespace FMS.Dal.Migrations
{
    public partial class AddedCommissionFieldsToModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "Locations",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "HasCommissionLocation",
                table: "Customers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Locations_CustomerId",
                table: "Locations",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Customers_CustomerId",
                table: "Locations",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Customers_CustomerId",
                table: "Locations");

            migrationBuilder.DropIndex(
                name: "IX_Locations_CustomerId",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "HasCommissionLocation",
                table: "Customers");
        }
    }
}
