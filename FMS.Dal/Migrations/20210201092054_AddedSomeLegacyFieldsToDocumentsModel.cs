using Microsoft.EntityFrameworkCore.Migrations;

namespace FMS.Dal.Migrations
{
    public partial class AddedSomeLegacyFieldsToDocumentsModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FMS_lkoods",
                table: "Documents",
                type: "nvarchar(2)",
                maxLength: 2,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FMS_lkoodv",
                table: "Documents",
                type: "nvarchar(2)",
                maxLength: 2,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FMS_lkoods",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "FMS_lkoodv",
                table: "Documents");
        }
    }
}
