using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace DSEU.Infrastructure.Persistence.Migrations
{
    public partial class TerrUnitNameIsUniq : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TerritorialUnit_TerritorialUnit_ParentId",
                table: "TerritorialUnit");

            migrationBuilder.DropForeignKey(
                name: "FK_TerritorialUnit_TerritorialUnitType_TypeId",
                table: "TerritorialUnit");

            migrationBuilder.DropTable(
                name: "TerritorialUnitType");

            migrationBuilder.DropIndex(
                name: "IX_TerritorialUnit_Name",
                table: "TerritorialUnit");

            migrationBuilder.DropIndex(
                name: "IX_TerritorialUnit_ParentId",
                table: "TerritorialUnit");

            migrationBuilder.DropIndex(
                name: "IX_TerritorialUnit_TypeId",
                table: "TerritorialUnit");

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "TerritorialUnit");

            migrationBuilder.AddColumn<int>(
                name: "Level",
                table: "TerritorialUnit",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TypeName",
                table: "TerritorialUnit",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TerritorialUnit_Name",
                table: "TerritorialUnit",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TerritorialUnit_Name",
                table: "TerritorialUnit");

            migrationBuilder.DropColumn(
                name: "Level",
                table: "TerritorialUnit");

            migrationBuilder.DropColumn(
                name: "TypeName",
                table: "TerritorialUnit");

            migrationBuilder.AddColumn<int>(
                name: "TypeId",
                table: "TerritorialUnit",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TerritorialUnitType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IsReadOnly = table.Column<bool>(type: "boolean", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TerritorialUnitType", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TerritorialUnit_Name",
                table: "TerritorialUnit",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_TerritorialUnit_ParentId",
                table: "TerritorialUnit",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_TerritorialUnit_TypeId",
                table: "TerritorialUnit",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TerritorialUnitType_Name",
                table: "TerritorialUnitType",
                column: "Name",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TerritorialUnit_TerritorialUnit_ParentId",
                table: "TerritorialUnit",
                column: "ParentId",
                principalTable: "TerritorialUnit",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TerritorialUnit_TerritorialUnitType_TypeId",
                table: "TerritorialUnit",
                column: "TypeId",
                principalTable: "TerritorialUnitType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
