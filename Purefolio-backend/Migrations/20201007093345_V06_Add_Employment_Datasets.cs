using Microsoft.EntityFrameworkCore.Migrations;

namespace Purefolio_backend.Migrations
{
    public partial class V06_Add_Employment_Datasets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "employees_ed_lvl0_2",
                table: "NaceRegionData",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "employees_ed_lvl3_4",
                table: "NaceRegionData",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "employees_ed_lvl5_8",
                table: "NaceRegionData",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "temporaryemployment",
                table: "NaceRegionData",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "employees_ed_lvl0_2",
                table: "NaceRegionData");

            migrationBuilder.DropColumn(
                name: "employees_ed_lvl3_4",
                table: "NaceRegionData");

            migrationBuilder.DropColumn(
                name: "employees_ed_lvl5_8",
                table: "NaceRegionData");

            migrationBuilder.DropColumn(
                name: "temporaryemployment",
                table: "NaceRegionData");
        }
    }
}
