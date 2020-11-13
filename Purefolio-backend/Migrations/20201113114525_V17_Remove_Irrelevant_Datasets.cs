using Microsoft.EntityFrameworkCore.Migrations;

namespace Purefolio_backend.Migrations
{
    public partial class V17_Remove_Irrelevant_Datasets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "environmental_protection_pollution",
                table: "NaceRegionData");

            migrationBuilder.DropColumn(
                name: "environmental_protection_tech",
                table: "NaceRegionData");

            migrationBuilder.DropColumn(
                name: "seasonal_work",
                table: "NaceRegionData");

            migrationBuilder.DropColumn(
                name: "supply_energy_products",
                table: "NaceRegionData");

            migrationBuilder.DropColumn(
                name: "supply_energy_residuals",
                table: "NaceRegionData");

            migrationBuilder.DropColumn(
                name: "total_hazardous_waste",
                table: "NaceRegionData");

            migrationBuilder.DropColumn(
                name: "total_non_hazardous_waste",
                table: "NaceRegionData");

            migrationBuilder.DropColumn(
                name: "total_waste",
                table: "NaceRegionData");

            migrationBuilder.DropColumn(
                name: "use_energy_products",
                table: "NaceRegionData");

            migrationBuilder.DropColumn(
                name: "use_energy_residuals",
                table: "NaceRegionData");

            migrationBuilder.DropColumn(
                name: "use_natural_energy_inputs",
                table: "NaceRegionData");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "environmental_protection_pollution",
                table: "NaceRegionData",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "environmental_protection_tech",
                table: "NaceRegionData",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "seasonal_work",
                table: "NaceRegionData",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "supply_energy_products",
                table: "NaceRegionData",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "supply_energy_residuals",
                table: "NaceRegionData",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "total_hazardous_waste",
                table: "NaceRegionData",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "total_non_hazardous_waste",
                table: "NaceRegionData",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "total_waste",
                table: "NaceRegionData",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "use_energy_products",
                table: "NaceRegionData",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "use_energy_residuals",
                table: "NaceRegionData",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "use_natural_energy_inputs",
                table: "NaceRegionData",
                type: "double precision",
                nullable: true);
        }
    }
}
