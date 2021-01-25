using Microsoft.EntityFrameworkCore.Migrations;

namespace FMS.Dal.Migrations
{
    public partial class RefactoredDocumentModel2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SourceDocumentId",
                table: "Documents",
                newName: "ToFromLocationId");

            migrationBuilder.RenameColumn(
                name: "DestLocationId",
                table: "Documents",
                newName: "ToFromDocumentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ToFromLocationId",
                table: "Documents",
                newName: "SourceDocumentId");

            migrationBuilder.RenameColumn(
                name: "ToFromDocumentId",
                table: "Documents",
                newName: "DestLocationId");
        }
    }
}
