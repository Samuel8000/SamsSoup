using Microsoft.EntityFrameworkCore.Migrations;

namespace SamsSoup.Migrations
{
    public partial class AddedShoppingCartItems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Soups",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "ShoppingCartItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SoupId = table.Column<int>(nullable: true),
                    Amount = table.Column<int>(nullable: false),
                    ShoppingCartId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCartItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShoppingCartItems_Soups_SoupId",
                        column: x => x.SoupId,
                        principalTable: "Soups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "Soups",
                keyColumn: "Id",
                keyValue: 1,
                column: "Price",
                value: 10m);

            migrationBuilder.UpdateData(
                table: "Soups",
                keyColumn: "Id",
                keyValue: 2,
                column: "Price",
                value: 15m);

            migrationBuilder.UpdateData(
                table: "Soups",
                keyColumn: "Id",
                keyValue: 3,
                column: "Price",
                value: 12m);

            migrationBuilder.UpdateData(
                table: "Soups",
                keyColumn: "Id",
                keyValue: 4,
                column: "Price",
                value: 12m);

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartItems_SoupId",
                table: "ShoppingCartItems",
                column: "SoupId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShoppingCartItems");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Soups");
        }
    }
}
