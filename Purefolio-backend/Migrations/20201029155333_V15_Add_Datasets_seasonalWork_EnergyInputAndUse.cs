using Microsoft.EntityFrameworkCore.Migrations;

namespace Purefolio_backend.Migrations
{
    public partial class V15_Add_Datasets_seasonalWork_EnergyInputAndUse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "seasonal_work",
                table: "NaceRegionData",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "supply_energy_products",
                table: "NaceRegionData",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "supply_energy_residuals",
                table: "NaceRegionData",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "use_energy_products",
                table: "NaceRegionData",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "use_energy_residuals",
                table: "NaceRegionData",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "use_natural_energy_inputs",
                table: "NaceRegionData",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                name: "use_energy_products",
                table: "NaceRegionData");

            migrationBuilder.DropColumn(
                name: "use_energy_residuals",
                table: "NaceRegionData");

            migrationBuilder.DropColumn(
                name: "use_natural_energy_inputs",
                table: "NaceRegionData");
        }
    }
}
