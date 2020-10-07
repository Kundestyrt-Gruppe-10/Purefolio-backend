using Microsoft.EntityFrameworkCore.Migrations;

namespace Purefolio_backend.Migrations
{
    public partial class V07_Fix_Naming_Educational_Data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<double>(
                name: "employees_primary_education",
                table: "NaceRegionData",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "employees_secondary_education",
                table: "NaceRegionData",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "employees_tertiary_education",
                table: "NaceRegionData",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "employees_primary_education",
                table: "NaceRegionData");

            migrationBuilder.DropColumn(
                name: "employees_secondary_education",
                table: "NaceRegionData");

            migrationBuilder.DropColumn(
                name: "employees_tertiary_education",
                table: "NaceRegionData");

            migrationBuilder.AddColumn<double>(
                name: "employees_ed_lvl0_2",
                table: "NaceRegionData",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "employees_ed_lvl3_4",
                table: "NaceRegionData",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "employees_ed_lvl5_8",
                table: "NaceRegionData",
                type: "double precision",
                nullable: true);
        }
    }
}
