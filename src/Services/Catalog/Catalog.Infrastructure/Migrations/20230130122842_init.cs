#nullable disable
namespace Catalog.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Catalog");

            migrationBuilder.CreateTable(
                name: "CatalogType",
                schema: "Catalog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Type = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Supplier",
                schema: "Catalog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    AddressStreet = table.Column<string>(name: "Address_Street", type: "text", nullable: false),
                    AddressCity = table.Column<string>(name: "Address_City", type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supplier", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Catalog",
                schema: "Catalog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Price = table.Column<int>(type: "integer", nullable: false),
                    CatalogTypeId = table.Column<Guid>(type: "uuid", nullable: false),
                    AvailableStock = table.Column<int>(type: "integer", nullable: false),
                    MinStockThreshold = table.Column<int>(type: "integer", nullable: false),
                    MaxStockThreshold = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Catalog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Catalog_CatalogType_CatalogTypeId",
                        column: x => x.CatalogTypeId,
                        principalSchema: "Catalog",
                        principalTable: "CatalogType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SupplierItem",
                schema: "Catalog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SupplierId = table.Column<Guid>(type: "uuid", nullable: false),
                    RequestNumber = table.Column<int>(type: "integer", nullable: false),
                    CatalogTypeId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplierItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SupplierItem_CatalogType_CatalogTypeId",
                        column: x => x.CatalogTypeId,
                        principalSchema: "Catalog",
                        principalTable: "CatalogType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SupplierItem_Supplier_SupplierId",
                        column: x => x.SupplierId,
                        principalSchema: "Catalog",
                        principalTable: "Supplier",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Catalog_CatalogTypeId",
                schema: "Catalog",
                table: "Catalog",
                column: "CatalogTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SupplierItem_CatalogTypeId",
                schema: "Catalog",
                table: "SupplierItem",
                column: "CatalogTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SupplierItem_SupplierId",
                schema: "Catalog",
                table: "SupplierItem",
                column: "SupplierId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Catalog",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "SupplierItem",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "CatalogType",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "Supplier",
                schema: "Catalog");
        }
    }
}
