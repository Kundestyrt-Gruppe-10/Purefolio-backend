using Microsoft.EntityFrameworkCore.Migrations;

namespace Purefolio_backend.Migrations
{
    public partial class V10_Add_Fields_To_EuroStatTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "dataset_name",
                table: "EuroStatTable",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "description",
                table: "EuroStatTable",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "esg_factor",
                table: "EuroStatTable",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "filters",
                table: "EuroStatTable",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "dataset_name",
                table: "EuroStatTable");

            migrationBuilder.DropColumn(
                name: "description",
                table: "EuroStatTable");

            migrationBuilder.DropColumn(
                name: "esg_factor",
                table: "EuroStatTable");

            migrationBuilder.DropColumn(
                name: "filters",
                table: "EuroStatTable");
        }
    }
}
