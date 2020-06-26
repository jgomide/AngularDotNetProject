using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AngularDotNetProject.Repository.Migrations
{
    public partial class AddNewDomains : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagemUrl",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "Release",
                table: "Events");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Events",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageURL",
                table: "Events",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Events",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Headlines",
                columns: table => new
                {
                    HeadlineId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    HighLight = table.Column<string>(nullable: true),
                    ImageURL = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Headlines", x => x.HeadlineId);
                });

            migrationBuilder.CreateTable(
                name: "Releases",
                columns: table => new
                {
                    ReleaseId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    DateMin = table.Column<DateTime>(nullable: true),
                    DateMax = table.Column<DateTime>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    EventId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Releases", x => x.ReleaseId);
                    table.ForeignKey(
                        name: "FK_Releases_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HeadlineEvents",
                columns: table => new
                {
                    HeadlineId = table.Column<int>(nullable: false),
                    EventId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeadlineEvents", x => new { x.EventId, x.HeadlineId });
                    table.ForeignKey(
                        name: "FK_HeadlineEvents_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HeadlineEvents_Headlines_HeadlineId",
                        column: x => x.HeadlineId,
                        principalTable: "Headlines",
                        principalColumn: "HeadlineId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SocialNetworks",
                columns: table => new
                {
                    SocialNetworkId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    URL = table.Column<string>(nullable: true),
                    EventId = table.Column<int>(nullable: true),
                    HeadlineId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialNetworks", x => x.SocialNetworkId);
                    table.ForeignKey(
                        name: "FK_SocialNetworks_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SocialNetworks_Headlines_HeadlineId",
                        column: x => x.HeadlineId,
                        principalTable: "Headlines",
                        principalColumn: "HeadlineId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HeadlineEvents_HeadlineId",
                table: "HeadlineEvents",
                column: "HeadlineId");

            migrationBuilder.CreateIndex(
                name: "IX_Releases_EventId",
                table: "Releases",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_SocialNetworks_EventId",
                table: "SocialNetworks",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_SocialNetworks_HeadlineId",
                table: "SocialNetworks",
                column: "HeadlineId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HeadlineEvents");

            migrationBuilder.DropTable(
                name: "Releases");

            migrationBuilder.DropTable(
                name: "SocialNetworks");

            migrationBuilder.DropTable(
                name: "Headlines");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "ImageURL",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Events");

            migrationBuilder.AddColumn<string>(
                name: "ImagemUrl",
                table: "Events",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Release",
                table: "Events",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
