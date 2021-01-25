using Microsoft.EntityFrameworkCore.Migrations;

namespace FMS.Dal.Migrations
{
    public partial class AddedIndexesToDocumentModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Documents_LocationId",
                table: "Documents",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_ToFromLocationId",
                table: "Documents",
                column: "ToFromLocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_Locations_LocationId",
                table: "Documents",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_Locations_ToFromLocationId",
                table: "Documents",
                column: "ToFromLocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documents_Locations_LocationId",
                table: "Documents");

            migrationBuilder.DropForeignKey(
                name: "FK_Documents_Locations_ToFromLocationId",
                table: "Documents");

            migrationBuilder.DropIndex(
                name: "IX_Documents_LocationId",
                table: "Documents");

            migrationBuilder.DropIndex(
                name: "IX_Documents_ToFromLocationId",
                table: "Documents");
        }
    }
}
