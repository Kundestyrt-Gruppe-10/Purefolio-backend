using Microsoft.EntityFrameworkCore.Migrations;

namespace Purefolio_backend.Migrations
{
    public partial class V13_Add_More_Datasets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "hours_paid_and_not",
                table: "NaceRegionData",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "hours_work_week",
                table: "NaceRegionData",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "job_vacancy_rate",
                table: "NaceRegionData",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "total_hazardous_waste",
                table: "NaceRegionData",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "total_non_hazardous_waste",
                table: "NaceRegionData",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "total_waste",
                table: "NaceRegionData",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "training_participation",
                table: "NaceRegionData",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "hours_paid_and_not",
                table: "NaceRegionData");

            migrationBuilder.DropColumn(
                name: "hours_work_week",
                table: "NaceRegionData");

            migrationBuilder.DropColumn(
                name: "job_vacancy_rate",
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
                name: "training_participation",
                table: "NaceRegionData");
        }
    }
}
