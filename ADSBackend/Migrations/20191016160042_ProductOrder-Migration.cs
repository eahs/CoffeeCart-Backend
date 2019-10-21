using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ADSBackend.Migrations
{
    public partial class ProductOrderMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductsOrdered",
                table: "OrderModel");

            migrationBuilder.CreateTable(
                name: "ProductOrderModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProductId = table.Column<int>(nullable: true),
                    Size = table.Column<string>(nullable: true),
                    Instructions = table.Column<string>(nullable: true),
                    OrderModelId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductOrderModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductOrderModel_OrderModel_OrderModelId",
                        column: x => x.OrderModelId,
                        principalTable: "OrderModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductOrderModel_ProductModel_ProductId",
                        column: x => x.ProductId,
                        principalTable: "ProductModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductOrderModel_OrderModelId",
                table: "ProductOrderModel",
                column: "OrderModelId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductOrderModel_ProductId",
                table: "ProductOrderModel",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductOrderModel");

            migrationBuilder.AddColumn<string>(
                name: "ProductsOrdered",
                table: "OrderModel",
                nullable: false,
                defaultValue: "");
        }
    }
}
