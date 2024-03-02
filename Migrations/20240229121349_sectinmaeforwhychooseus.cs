using Microsoft.EntityFrameworkCore.Migrations;

namespace WebsiteBuilder.Migrations
{
    public partial class sectinmaeforwhychooseus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SectionName",
                table: "WhyChooseUs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SectionTagLine",
                table: "WhyChooseUs",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SectionName",
                table: "WhyChooseUs");

            migrationBuilder.DropColumn(
                name: "SectionTagLine",
                table: "WhyChooseUs");
        }
    }
}
