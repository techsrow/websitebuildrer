using Microsoft.EntityFrameworkCore.Migrations;

namespace WebsiteBuilder.Migrations
{
    public partial class seodataupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MetaTitle",
                table: "Seos");

            migrationBuilder.RenameColumn(
                name: "CanonicalUrl",
                table: "Seos",
                newName: "canonicalUrl");

            migrationBuilder.AddColumn<string>(
                name: "CustomScript",
                table: "Seos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MetaTagsForFacebook",
                table: "Seos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MetaTagsForInstagram",
                table: "Seos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OgDescription",
                table: "Seos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OgImageUrl",
                table: "Seos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OgTitle",
                table: "Seos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OgUrl",
                table: "Seos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SeoTitle",
                table: "Seos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SiteMap",
                table: "Seos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SiteName",
                table: "Seos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TwitterImageUrl",
                table: "Seos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "authorname",
                table: "Seos",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomScript",
                table: "Seos");

            migrationBuilder.DropColumn(
                name: "MetaTagsForFacebook",
                table: "Seos");

            migrationBuilder.DropColumn(
                name: "MetaTagsForInstagram",
                table: "Seos");

            migrationBuilder.DropColumn(
                name: "OgDescription",
                table: "Seos");

            migrationBuilder.DropColumn(
                name: "OgImageUrl",
                table: "Seos");

            migrationBuilder.DropColumn(
                name: "OgTitle",
                table: "Seos");

            migrationBuilder.DropColumn(
                name: "OgUrl",
                table: "Seos");

            migrationBuilder.DropColumn(
                name: "SeoTitle",
                table: "Seos");

            migrationBuilder.DropColumn(
                name: "SiteMap",
                table: "Seos");

            migrationBuilder.DropColumn(
                name: "SiteName",
                table: "Seos");

            migrationBuilder.DropColumn(
                name: "TwitterImageUrl",
                table: "Seos");

            migrationBuilder.DropColumn(
                name: "authorname",
                table: "Seos");

            migrationBuilder.RenameColumn(
                name: "canonicalUrl",
                table: "Seos",
                newName: "CanonicalUrl");

            migrationBuilder.AddColumn<string>(
                name: "MetaTitle",
                table: "Seos",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
