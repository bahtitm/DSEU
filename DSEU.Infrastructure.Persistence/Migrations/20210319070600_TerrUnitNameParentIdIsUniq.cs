using Microsoft.EntityFrameworkCore.Migrations;

namespace DSEU.Infrastructure.Persistence.Migrations
{
    public partial class TerrUnitNameParentIdIsUniq : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TerritorialUnit_Name",
                table: "TerritorialUnit");

            migrationBuilder.CreateIndex(
                name: "IX_TerritorialUnit_Name_ParentId",
                table: "TerritorialUnit",
                columns: new[] { "Name", "ParentId" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TerritorialUnit_Name_ParentId",
                table: "TerritorialUnit");

            migrationBuilder.CreateIndex(
                name: "IX_TerritorialUnit_Name",
                table: "TerritorialUnit",
                column: "Name",
                unique: true);
        }
    }
}
