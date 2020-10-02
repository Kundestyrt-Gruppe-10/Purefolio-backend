using Microsoft.EntityFrameworkCore.Migrations;

namespace Purefolio_backend.Migrations
{
    public partial class V03_Make_fields_required : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "emission_per_yer",
                table: "NaceRegionData");

            migrationBuilder.AddColumn<double>(
                name: "emission_per_year",
                table: "NaceRegionData",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "emission_per_year",
                table: "NaceRegionData");

            migrationBuilder.AddColumn<double>(
                name: "emission_per_yer",
                table: "NaceRegionData",
                type: "double precision",
                nullable: true);
        }
    }
}
