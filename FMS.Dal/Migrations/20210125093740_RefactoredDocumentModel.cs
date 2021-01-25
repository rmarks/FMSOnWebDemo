using Microsoft.EntityFrameworkCore.Migrations;

namespace FMS.Dal.Migrations
{
    public partial class RefactoredDocumentModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ToFromDocumentId",
                table: "Documents",
                newName: "SourceDocumentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SourceDocumentId",
                table: "Documents",
                newName: "ToFromDocumentId");
        }
    }
}
