using Microsoft.EntityFrameworkCore.Migrations;

namespace Purefolio_backend.Migrations
{
    public partial class V04_Add_workAccidentsIncidentRate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "work_accidents_incident_rate",
                table: "NaceRegionData",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "work_accidents_incident_rate",
                table: "NaceRegionData");
        }
    }
}
