using Microsoft.EntityFrameworkCore.Migrations;

namespace DSEU.Infrastructure.Persistence.Migrations
{
    public partial class TerrUnitNameParentIdAndTypeNameIsUniq : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TerritorialUnit_Name_ParentId",
                table: "TerritorialUnit");

            migrationBuilder.CreateIndex(
                name: "IX_TerritorialUnit_Name_ParentId_TypeName",
                table: "TerritorialUnit",
                columns: new[] { "Name", "ParentId", "TypeName" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TerritorialUnit_Name_ParentId_TypeName",
                table: "TerritorialUnit");

            migrationBuilder.CreateIndex(
                name: "IX_TerritorialUnit_Name_ParentId",
                table: "TerritorialUnit",
                columns: new[] { "Name", "ParentId" },
                unique: true);
        }
    }
}
