using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Purefolio_backend.Migrations
{
    public partial class ermodel170920 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Nace",
                columns: table => new
                {
                    nace_id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nace_code = table.Column<string>(nullable: false),
                    nace_name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_nace", x => x.nace_id);
                });

            migrationBuilder.CreateTable(
                name: "Region",
                columns: table => new
                {
                    region_id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    region_code = table.Column<string>(nullable: false),
                    region_name = table.Column<string>(nullable: true),
                    area = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_region", x => x.region_id);
                });

            migrationBuilder.CreateTable(
                name: "RegionData",
                columns: table => new
                {
                    region_data_id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    region_id = table.Column<int>(nullable: false),
                    year = table.Column<int>(nullable: false),
                    population = table.Column<int>(nullable: false),
                    gdp = table.Column<int>(nullable: false),
                    corruption_rate = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_region_data", x => x.region_data_id);
                });

            migrationBuilder.CreateTable(
                name: "NaceRegionData",
                columns: table => new
                {
                    nace_region_data_id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nace_id = table.Column<int>(nullable: false),
                    region_id = table.Column<int>(nullable: false),
                    year = table.Column<int>(nullable: false),
                    emission_per_yer = table.Column<double>(nullable: false),
                    gender_pay_gap = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_nace_region_data", x => x.nace_region_data_id);
                    table.ForeignKey(
                        name: "fk_nace_region_data_nace_nace_id",
                        column: x => x.nace_id,
                        principalTable: "Nace",
                        principalColumn: "nace_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_nace_region_data_region_region_id",
                        column: x => x.region_id,
                        principalTable: "Region",
                        principalColumn: "region_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_nace_region_data_nace_id",
                table: "NaceRegionData",
                column: "nace_id");

            migrationBuilder.CreateIndex(
                name: "ix_nace_region_data_region_id",
                table: "NaceRegionData",
                column: "region_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NaceRegionData");

            migrationBuilder.DropTable(
                name: "RegionData");

            migrationBuilder.DropTable(
                name: "Nace");

            migrationBuilder.DropTable(
                name: "Region");
        }
    }
}
