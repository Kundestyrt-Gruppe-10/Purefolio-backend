using Microsoft.EntityFrameworkCore.Migrations;

namespace Purefolio_backend.Migrations
{
    public partial class V14_Add_Datasets_Environmental_Protection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "environmental_protection_pollution",
                table: "NaceRegionData",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "environmental_protection_tech",
                table: "NaceRegionData",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "environmental_protection_pollution",
                table: "NaceRegionData");

            migrationBuilder.DropColumn(
                name: "environmental_protection_tech",
                table: "NaceRegionData");
        }
    }
}
