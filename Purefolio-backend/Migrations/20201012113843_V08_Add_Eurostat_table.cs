using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Purefolio_backend.Migrations
{
    public partial class V08_Add_Eurostat_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EuroStatTable",
                columns: table => new
                {
                    table_id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    table_code = table.Column<string>(nullable: true),
                    attribute_name = table.Column<string>(nullable: true),
                    unit = table.Column<string>(nullable: true),
                    data_type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_euro_stat_table", x => x.table_id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EuroStatTable");
        }
    }
}
