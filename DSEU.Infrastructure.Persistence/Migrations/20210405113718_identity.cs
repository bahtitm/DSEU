using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace DSEU.Infrastructure.Persistence.Migrations
{
    public partial class identity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationalUnit_OrganizationalUnit_ParentId",
                table: "OrganizationalUnit");

            migrationBuilder.DropForeignKey(
                name: "FK_Region_Country_CountryId",
                table: "Region");

            migrationBuilder.DropForeignKey(
                name: "FK_TerritorialUnit_TerritorialUnit_ParentId",
                table: "TerritorialUnit");

            migrationBuilder.DropForeignKey(
                name: "FK_TerritorialUnit_TerritorialUnitType_TypeId",
                table: "TerritorialUnit");

            migrationBuilder.DropForeignKey(
                name: "FK_User_OrganizationalUnit_OrganizationalUnitId",
                table: "User");

            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropTable(
                name: "TerritorialUnitType");

            migrationBuilder.DropTable(
                name: "UserLocality");

            migrationBuilder.DropTable(
                name: "Village");

            migrationBuilder.DropIndex(
                name: "IX_TerritorialUnit_Name",
                table: "TerritorialUnit");

            migrationBuilder.DropIndex(
                name: "IX_TerritorialUnit_ParentId",
                table: "TerritorialUnit");

            migrationBuilder.DropIndex(
                name: "IX_TerritorialUnit_TypeId",
                table: "TerritorialUnit");

            migrationBuilder.DropIndex(
                name: "IX_Region_CountryId",
                table: "Region");

            migrationBuilder.DropIndex(
                name: "IX_OrganizationalUnit_ParentId",
                table: "OrganizationalUnit");

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "TerritorialUnit");

            migrationBuilder.RenameColumn(
                name: "OrganizationalUnitId",
                table: "User",
                newName: "DistrictId");

            migrationBuilder.RenameIndex(
                name: "IX_User_OrganizationalUnitId",
                table: "User",
                newName: "IX_User_DistrictId");

            migrationBuilder.RenameColumn(
                name: "CountryId",
                table: "Region",
                newName: "RegionCode");

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

            migrationBuilder.AddColumn<int>(
                name: "Level",
                table: "OrganizationalUnit",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrganizationalUnitNumber",
                table: "OrganizationalUnit",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TypeName",
                table: "OrganizationalUnit",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DistrictCode",
                table: "District",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TerritorialUnit_Name_ParentId_TypeName",
                table: "TerritorialUnit",
                columns: new[] { "Name", "ParentId", "TypeName" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_User_District_DistrictId",
                table: "User",
                column: "DistrictId",
                principalTable: "District",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_District_DistrictId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_TerritorialUnit_Name_ParentId_TypeName",
                table: "TerritorialUnit");

            migrationBuilder.DropColumn(
                name: "Level",
                table: "TerritorialUnit");

            migrationBuilder.DropColumn(
                name: "TypeName",
                table: "TerritorialUnit");

            migrationBuilder.DropColumn(
                name: "Level",
                table: "OrganizationalUnit");

            migrationBuilder.DropColumn(
                name: "OrganizationalUnitNumber",
                table: "OrganizationalUnit");

            migrationBuilder.DropColumn(
                name: "TypeName",
                table: "OrganizationalUnit");

            migrationBuilder.DropColumn(
                name: "DistrictCode",
                table: "District");

            migrationBuilder.RenameColumn(
                name: "DistrictId",
                table: "User",
                newName: "OrganizationalUnitId");

            migrationBuilder.RenameIndex(
                name: "IX_User_DistrictId",
                table: "User",
                newName: "IX_User_OrganizationalUnitId");

            migrationBuilder.RenameColumn(
                name: "RegionCode",
                table: "Region",
                newName: "CountryId");

            migrationBuilder.AddColumn<int>(
                name: "TypeId",
                table: "TerritorialUnit",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.Id);
                });

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
                name: "UserLocality",
                columns: table => new
                {
                    LocalityId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLocality", x => new { x.LocalityId, x.UserId });
                    table.ForeignKey(
                        name: "FK_UserLocality_Locality_LocalityId",
                        column: x => x.LocalityId,
                        principalTable: "Locality",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserLocality_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Village",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LocalityId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Village", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Village_Locality_LocalityId",
                        column: x => x.LocalityId,
                        principalTable: "Locality",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "IX_Region_CountryId",
                table: "Region",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationalUnit_ParentId",
                table: "OrganizationalUnit",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_TerritorialUnitType_Name",
                table: "TerritorialUnitType",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserLocality_UserId",
                table: "UserLocality",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Village_LocalityId",
                table: "Village",
                column: "LocalityId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationalUnit_OrganizationalUnit_ParentId",
                table: "OrganizationalUnit",
                column: "ParentId",
                principalTable: "OrganizationalUnit",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Region_Country_CountryId",
                table: "Region",
                column: "CountryId",
                principalTable: "Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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

            migrationBuilder.AddForeignKey(
                name: "FK_User_OrganizationalUnit_OrganizationalUnitId",
                table: "User",
                column: "OrganizationalUnitId",
                principalTable: "OrganizationalUnit",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
