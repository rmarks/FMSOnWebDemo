using Microsoft.EntityFrameworkCore.Migrations;

namespace FMS.Dal.Migrations
{
    public partial class ChangedDeliveryNoteModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeliveryNotes_Locations_LocationId",
                table: "DeliveryNotes");

            migrationBuilder.DropIndex(
                name: "IX_DeliveryNotes_LocationId",
                table: "DeliveryNotes");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "DeliveryNotes");

            migrationBuilder.AddColumn<string>(
                name: "FMS_doknr",
                table: "DeliveryNotes",
                type: "nvarchar(8)",
                maxLength: 8,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FMS_doktyyp",
                table: "DeliveryNotes",
                type: "nvarchar(2)",
                maxLength: 2,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FMS_skood",
                table: "DeliveryNotes",
                type: "nvarchar(6)",
                maxLength: 6,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FromLocationId",
                table: "DeliveryNotes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ToLocationId",
                table: "DeliveryNotes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FMS_doknr",
                table: "DeliveryNoteLines",
                type: "nvarchar(8)",
                maxLength: 8,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FMS_doktyyp",
                table: "DeliveryNoteLines",
                type: "nvarchar(2)",
                maxLength: 2,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryNotes_FromLocationId",
                table: "DeliveryNotes",
                column: "FromLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryNotes_ToLocationId",
                table: "DeliveryNotes",
                column: "ToLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryNoteLines_DeliveryNoteId",
                table: "DeliveryNoteLines",
                column: "DeliveryNoteId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryNoteLines_ProductId",
                table: "DeliveryNoteLines",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryNoteLines_DeliveryNotes_DeliveryNoteId",
                table: "DeliveryNoteLines",
                column: "DeliveryNoteId",
                principalTable: "DeliveryNotes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryNoteLines_Products_ProductId",
                table: "DeliveryNoteLines",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryNotes_Locations_FromLocationId",
                table: "DeliveryNotes",
                column: "FromLocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryNotes_Locations_ToLocationId",
                table: "DeliveryNotes",
                column: "ToLocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeliveryNoteLines_DeliveryNotes_DeliveryNoteId",
                table: "DeliveryNoteLines");

            migrationBuilder.DropForeignKey(
                name: "FK_DeliveryNoteLines_Products_ProductId",
                table: "DeliveryNoteLines");

            migrationBuilder.DropForeignKey(
                name: "FK_DeliveryNotes_Locations_FromLocationId",
                table: "DeliveryNotes");

            migrationBuilder.DropForeignKey(
                name: "FK_DeliveryNotes_Locations_ToLocationId",
                table: "DeliveryNotes");

            migrationBuilder.DropIndex(
                name: "IX_DeliveryNotes_FromLocationId",
                table: "DeliveryNotes");

            migrationBuilder.DropIndex(
                name: "IX_DeliveryNotes_ToLocationId",
                table: "DeliveryNotes");

            migrationBuilder.DropIndex(
                name: "IX_DeliveryNoteLines_DeliveryNoteId",
                table: "DeliveryNoteLines");

            migrationBuilder.DropIndex(
                name: "IX_DeliveryNoteLines_ProductId",
                table: "DeliveryNoteLines");

            migrationBuilder.DropColumn(
                name: "FMS_doknr",
                table: "DeliveryNotes");

            migrationBuilder.DropColumn(
                name: "FMS_doktyyp",
                table: "DeliveryNotes");

            migrationBuilder.DropColumn(
                name: "FMS_skood",
                table: "DeliveryNotes");

            migrationBuilder.DropColumn(
                name: "FromLocationId",
                table: "DeliveryNotes");

            migrationBuilder.DropColumn(
                name: "ToLocationId",
                table: "DeliveryNotes");

            migrationBuilder.DropColumn(
                name: "FMS_doknr",
                table: "DeliveryNoteLines");

            migrationBuilder.DropColumn(
                name: "FMS_doktyyp",
                table: "DeliveryNoteLines");

            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "DeliveryNotes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryNotes_LocationId",
                table: "DeliveryNotes",
                column: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryNotes_Locations_LocationId",
                table: "DeliveryNotes",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
