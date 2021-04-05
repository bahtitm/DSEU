using Microsoft.EntityFrameworkCore.Migrations;

namespace DSEU.Infrastructure.Persistence.Migrations
{
    public partial class added_organizationalUnit_migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationalUnit_OrganizationalUnit_ParentId",
                table: "OrganizationalUnit");

            migrationBuilder.DropIndex(
                name: "IX_OrganizationalUnit_ParentId",
                table: "OrganizationalUnit");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Level",
                table: "OrganizationalUnit");

            migrationBuilder.DropColumn(
                name: "OrganizationalUnitNumber",
                table: "OrganizationalUnit");

            migrationBuilder.DropColumn(
                name: "TypeName",
                table: "OrganizationalUnit");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationalUnit_ParentId",
                table: "OrganizationalUnit",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationalUnit_OrganizationalUnit_ParentId",
                table: "OrganizationalUnit",
                column: "ParentId",
                principalTable: "OrganizationalUnit",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
