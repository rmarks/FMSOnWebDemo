using Microsoft.EntityFrameworkCore.Migrations;

namespace FMS.Dal.Migrations
{
    public partial class MinorChangeInDBContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_deliveryNoteLines",
                table: "deliveryNoteLines");

            migrationBuilder.RenameTable(
                name: "deliveryNoteLines",
                newName: "DeliveryNoteLines");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DeliveryNoteLines",
                table: "DeliveryNoteLines",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_DeliveryNoteLines",
                table: "DeliveryNoteLines");

            migrationBuilder.RenameTable(
                name: "DeliveryNoteLines",
                newName: "deliveryNoteLines");

            migrationBuilder.AddPrimaryKey(
                name: "PK_deliveryNoteLines",
                table: "deliveryNoteLines",
                column: "Id");
        }
    }
}
