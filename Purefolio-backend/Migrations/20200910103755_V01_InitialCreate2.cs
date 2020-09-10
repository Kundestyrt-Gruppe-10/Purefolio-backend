using Microsoft.EntityFrameworkCore.Migrations;

namespace Purefolio_backend.Migrations
{
    public partial class V01_InitialCreate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "region_code",
                table: "region",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "nace_code",
                table: "nace",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "ix_nace_region_data_nace_id",
                table: "nace_region_data",
                column: "nace_id");

            migrationBuilder.CreateIndex(
                name: "ix_nace_region_data_region_id",
                table: "nace_region_data",
                column: "region_id");

            migrationBuilder.AddForeignKey(
                name: "fk_nace_region_data_nace_nace_id",
                table: "nace_region_data",
                column: "nace_id",
                principalTable: "nace",
                principalColumn: "nace_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_nace_region_data_region_region_id",
                table: "nace_region_data",
                column: "region_id",
                principalTable: "region",
                principalColumn: "region_id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_nace_region_data_nace_nace_id",
                table: "nace_region_data");

            migrationBuilder.DropForeignKey(
                name: "fk_nace_region_data_region_region_id",
                table: "nace_region_data");

            migrationBuilder.DropIndex(
                name: "ix_nace_region_data_nace_id",
                table: "nace_region_data");

            migrationBuilder.DropIndex(
                name: "ix_nace_region_data_region_id",
                table: "nace_region_data");

            migrationBuilder.AlterColumn<string>(
                name: "region_code",
                table: "region",
                type: "text",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "nace_code",
                table: "nace",
                type: "text",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
