using Microsoft.EntityFrameworkCore.Migrations;

namespace AngularDotNetProject.API.Data.Migrations
{
    public partial class AddEventFieldsTypeName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Theme",
                table: "Events");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Events",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Events",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Events");

            migrationBuilder.AddColumn<string>(
                name: "Theme",
                table: "Events",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
