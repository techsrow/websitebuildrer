using Microsoft.EntityFrameworkCore.Migrations;

namespace WebsiteBuilder.Migrations
{
    public partial class themecustom : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customizations",
                columns: table => new
                {
                    CustomizationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ThemeColor = table.Column<string>(nullable: true),
                    headingColor = table.Column<string>(nullable: true),
                    SubheadingColor = table.Column<string>(nullable: true),
                    TextColor = table.Column<string>(nullable: true),
                    PrimaryBgColor = table.Column<string>(nullable: true),
                    SecondryBgColor = table.Column<string>(nullable: true),
                    WebsiteId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customizations", x => x.CustomizationId);
                    table.ForeignKey(
                        name: "FK_Customizations_Websites_WebsiteId",
                        column: x => x.WebsiteId,
                        principalTable: "Websites",
                        principalColumn: "WebsiteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customizations_WebsiteId",
                table: "Customizations",
                column: "WebsiteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customizations");
        }
    }
}
