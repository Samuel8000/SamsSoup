using Microsoft.EntityFrameworkCore.Migrations;

namespace SamsSoup.Migrations
{
    public partial class AddedSoupReviews : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SoupReviews",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Review = table.Column<string>(nullable: true),
                    SoupId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoupReviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SoupReviews_Soups_SoupId",
                        column: x => x.SoupId,
                        principalTable: "Soups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SoupReviews_SoupId",
                table: "SoupReviews",
                column: "SoupId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SoupReviews");
        }
    }
}
