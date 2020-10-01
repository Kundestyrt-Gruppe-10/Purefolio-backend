using Microsoft.EntityFrameworkCore.Migrations;

namespace Purefolio_backend.Migrations
{
    public partial class V02_Make_fields_nullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "population",
                table: "RegionData",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "gdp",
                table: "RegionData",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "corruption_rate",
                table: "RegionData",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<double>(
                name: "gender_pay_gap",
                table: "NaceRegionData",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AlterColumn<double>(
                name: "emission_per_yer",
                table: "NaceRegionData",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "double precision");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "population",
                table: "RegionData",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "gdp",
                table: "RegionData",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "corruption_rate",
                table: "RegionData",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "gender_pay_gap",
                table: "NaceRegionData",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(double),
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "emission_per_yer",
                table: "NaceRegionData",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(double),
                oldNullable: true);
        }
    }
}
