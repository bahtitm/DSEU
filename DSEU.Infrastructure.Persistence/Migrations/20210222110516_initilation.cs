using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace DSEU.Infrastructure.Persistence.Migrations
{
    public partial class initilation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "TerritorialUnit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TypeId = table.Column<int>(type: "integer", nullable: false),
                    ParentId = table.Column<int>(type: "integer", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TerritorialUnit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TerritorialUnit_TerritorialUnit_ParentId",
                        column: x => x.ParentId,
                        principalTable: "TerritorialUnit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TerritorialUnit_TerritorialUnitType_TypeId",
                        column: x => x.TypeId,
                        principalTable: "TerritorialUnitType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TerritorialUnit");

            migrationBuilder.DropTable(
                name: "TerritorialUnitType");
        }
    }
}
