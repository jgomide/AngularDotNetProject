using Microsoft.EntityFrameworkCore.Migrations;

namespace AngularDotNetProject.Repository.Migrations
{
    public partial class AddEventsFieldImagemUrl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImagemUrl",
                table: "Events",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagemUrl",
                table: "Events");
        }
    }
}
