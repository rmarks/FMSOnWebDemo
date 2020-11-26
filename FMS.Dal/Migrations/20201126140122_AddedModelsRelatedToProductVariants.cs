using Microsoft.EntityFrameworkCore.Migrations;

namespace FMS.Dal.Migrations
{
    public partial class AddedModelsRelatedToProductVariants : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductVariantTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    HasStandardVariants = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductVariantTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductBaseProductVariantTypes",
                columns: table => new
                {
                    ProductBaseId = table.Column<int>(type: "int", nullable: false),
                    ProductVariantTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductBaseProductVariantTypes", x => new { x.ProductBaseId, x.ProductVariantTypeId });
                    table.ForeignKey(
                        name: "FK_ProductBaseProductVariantTypes_ProductVariantTypes_ProductVariantTypeId",
                        column: x => x.ProductVariantTypeId,
                        principalTable: "ProductVariantTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StandardProductVariants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ProductVariantTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StandardProductVariants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StandardProductVariants_ProductVariantTypes_ProductVariantTypeId",
                        column: x => x.ProductVariantTypeId,
                        principalTable: "ProductVariantTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductBaseProductVariants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ProductBaseId = table.Column<int>(type: "int", nullable: false),
                    ProductVariantTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductBaseProductVariants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductBaseProductVariants_ProductBaseProductVariantTypes_ProductBaseId_ProductVariantTypeId",
                        columns: x => new { x.ProductBaseId, x.ProductVariantTypeId },
                        principalTable: "ProductBaseProductVariantTypes",
                        principalColumns: new[] { "ProductBaseId", "ProductVariantTypeId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductProductVariants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ProductBaseProductVariantId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductProductVariants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductProductVariants_ProductBaseProductVariants_ProductBaseProductVariantId",
                        column: x => x.ProductBaseProductVariantId,
                        principalTable: "ProductBaseProductVariants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductProductVariants_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductBaseProductVariants_ProductBaseId_ProductVariantTypeId",
                table: "ProductBaseProductVariants",
                columns: new[] { "ProductBaseId", "ProductVariantTypeId" });

            migrationBuilder.CreateIndex(
                name: "IX_ProductBaseProductVariantTypes_ProductVariantTypeId",
                table: "ProductBaseProductVariantTypes",
                column: "ProductVariantTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductProductVariants_ProductBaseProductVariantId",
                table: "ProductProductVariants",
                column: "ProductBaseProductVariantId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductProductVariants_ProductId",
                table: "ProductProductVariants",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_StandardProductVariants_ProductVariantTypeId",
                table: "StandardProductVariants",
                column: "ProductVariantTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductProductVariants");

            migrationBuilder.DropTable(
                name: "StandardProductVariants");

            migrationBuilder.DropTable(
                name: "ProductBaseProductVariants");

            migrationBuilder.DropTable(
                name: "ProductBaseProductVariantTypes");

            migrationBuilder.DropTable(
                name: "ProductVariantTypes");
        }
    }
}
