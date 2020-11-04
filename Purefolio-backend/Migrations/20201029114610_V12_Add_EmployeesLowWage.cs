using Microsoft.EntityFrameworkCore.Migrations;

namespace Purefolio_backend.Migrations
{
    public partial class V12_Add_EmployeesLowWage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "employees_low_wage",
                table: "NaceRegionData",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "employees_low_wage",
                table: "NaceRegionData");
        }
    }
}
