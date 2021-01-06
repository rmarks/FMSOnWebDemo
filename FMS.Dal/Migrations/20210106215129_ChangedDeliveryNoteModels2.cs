using Microsoft.EntityFrameworkCore.Migrations;

namespace FMS.Dal.Migrations
{
    public partial class ChangedDeliveryNoteModels2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeliveryTypeId",
                table: "DeliveryNotes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DeliveryTypeId",
                table: "DeliveryNotes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
