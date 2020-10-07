using Microsoft.EntityFrameworkCore.Migrations;

namespace Purefolio_backend.Migrations
{
    public partial class V05_Add_Datasets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "environment_taxes",
                table: "NaceRegionData",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "fatal_accidents_at_work",
                table: "NaceRegionData",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "environment_taxes",
                table: "NaceRegionData");

            migrationBuilder.DropColumn(
                name: "fatal_accidents_at_work",
                table: "NaceRegionData");
        }
    }
}
