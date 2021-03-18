using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace DSEU.Infrastructure.Persistence.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppMigrationHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    InstalledVersion = table.Column<string>(type: "text", nullable: true),
                    MigrationName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppMigrationHistory", x => x.Id);
                });

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
                name: "Currency",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "text", nullable: true),
                    AlphaCode = table.Column<string>(type: "text", nullable: true),
                    ShortName = table.Column<string>(type: "text", nullable: true),
                    FractionName = table.Column<string>(type: "text", nullable: true),
                    IsDefault = table.Column<bool>(type: "boolean", nullable: false),
                    NumericCode = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currency", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JobTitle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobTitle", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrganizationalUnit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ParentId = table.Column<int>(type: "integer", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationalUnit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrganizationalUnit_OrganizationalUnit_ParentId",
                        column: x => x.ParentId,
                        principalTable: "OrganizationalUnit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                name: "Region",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CountryId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Region", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Region_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RealEstate",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Address = table.Column<string>(type: "text", nullable: true),
                    Purpose = table.Column<string>(type: "text", nullable: true),
                    CadastralCost = table.Column<decimal>(type: "numeric", nullable: true),
                    DealCost = table.Column<decimal>(type: "numeric", nullable: true),
                    CurrencyId = table.Column<int>(type: "integer", nullable: true),
                    Discriminator = table.Column<string>(type: "text", nullable: false),
                    InvertarNumber = table.Column<string>(type: "text", nullable: true),
                    LiveSquare = table.Column<double>(type: "double precision", nullable: true),
                    CommonSquare = table.Column<double>(type: "double precision", nullable: true),
                    FlatTotal = table.Column<int>(type: "integer", nullable: true),
                    AboveGroundFloorsCount = table.Column<int>(type: "integer", nullable: true),
                    UndergroundFloorsCount = table.Column<int>(type: "integer", nullable: true),
                    Flat = table.Column<int>(type: "integer", nullable: true),
                    ApartmentNumber = table.Column<int>(type: "integer", nullable: true),
                    RoomTotal = table.Column<int>(type: "integer", nullable: true),
                    CadastralNumber = table.Column<string>(type: "text", nullable: true),
                    VirtualCadastralNumber = table.Column<string>(type: "text", nullable: true),
                    Square = table.Column<double>(type: "double precision", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RealEstate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RealEstate_Currency_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LoginName = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: true),
                    IsSystem = table.Column<bool>(type: "boolean", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: true),
                    LastName = table.Column<string>(type: "text", nullable: true),
                    MiddleName = table.Column<string>(type: "text", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Phone = table.Column<string>(type: "text", nullable: true),
                    Note = table.Column<string>(type: "text", nullable: true),
                    DateOfAppointment = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    DateOfDismissal = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Email = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    OrganizationalUnitId = table.Column<int>(type: "integer", nullable: true),
                    JobTitleId = table.Column<int>(type: "integer", nullable: true),
                    Name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_JobTitle_JobTitleId",
                        column: x => x.JobTitleId,
                        principalTable: "JobTitle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_User_OrganizationalUnit_OrganizationalUnitId",
                        column: x => x.OrganizationalUnitId,
                        principalTable: "OrganizationalUnit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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

            migrationBuilder.CreateTable(
                name: "District",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RegionId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_District", x => x.Id);
                    table.ForeignKey(
                        name: "FK_District_Region_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Region",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Locality",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DistrictId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locality", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Locality_District_DistrictId",
                        column: x => x.DistrictId,
                        principalTable: "District",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLocality",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    LocalityId = table.Column<int>(type: "integer", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "RealEstateRight",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    ReviewResult = table.Column<int>(type: "integer", nullable: false),
                    StatementDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    RealEstateId = table.Column<int>(type: "integer", nullable: true),
                    ApplicantId = table.Column<int>(type: "integer", nullable: true),
                    Discriminator = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RealEstateRight", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RealEstateRight_RealEstate_RealEstateId",
                        column: x => x.RealEstateId,
                        principalTable: "RealEstate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Basis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DocumentType = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    RealEstateRightId = table.Column<int>(type: "integer", nullable: false),
                    Discriminator = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Condition = table.Column<string>(type: "text", nullable: true),
                    Cost = table.Column<double>(type: "double precision", nullable: true),
                    CurrencyId = table.Column<int>(type: "integer", nullable: true),
                    Date = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Number = table.Column<string>(type: "text", nullable: true),
                    IssuedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Basis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Basis_Currency_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Basis_RealEstateRight_RealEstateRightId",
                        column: x => x.RealEstateRightId,
                        principalTable: "RealEstateRight",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Statement",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Index = table.Column<int>(type: "integer", nullable: false),
                    Number = table.Column<string>(type: "text", nullable: true),
                    Purpose = table.Column<string>(type: "text", nullable: true),
                    DateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UserId = table.Column<int>(type: "integer", nullable: true),
                    AcceptedDocuments = table.Column<List<string>>(type: "jsonb", nullable: true),
                    IssuedDocuments = table.Column<List<string>>(type: "jsonb", nullable: true),
                    RealEstate = table.Column<string>(type: "text", nullable: true),
                    Decision = table.Column<int>(type: "integer", nullable: false),
                    RealEstateRightId = table.Column<int>(type: "integer", nullable: true),
                    LocalityId = table.Column<int>(type: "integer", nullable: false),
                    Note = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statement", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Statement_Locality_LocalityId",
                        column: x => x.LocalityId,
                        principalTable: "Locality",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Statement_RealEstateRight_RealEstateRightId",
                        column: x => x.RealEstateRightId,
                        principalTable: "RealEstateRight",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Statement_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Applicant",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "text", nullable: true),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    MiddleName = table.Column<string>(type: "text", nullable: true),
                    Birthday = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    PlaceOfBirth = table.Column<string>(type: "text", nullable: true),
                    IdentityDocumentType = table.Column<int>(type: "integer", nullable: true),
                    Number = table.Column<string>(type: "text", nullable: true),
                    IssueDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    IssuedBy = table.Column<string>(type: "text", nullable: true),
                    Citizenship = table.Column<string>(type: "text", nullable: true),
                    Registration = table.Column<string>(type: "text", nullable: true),
                    StatementId = table.Column<int>(type: "integer", nullable: false),
                    StatementId1 = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applicant", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Applicant_Statement_StatementId",
                        column: x => x.StatementId,
                        principalTable: "Statement",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Applicant_Statement_StatementId1",
                        column: x => x.StatementId1,
                        principalTable: "Statement",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Applicant_StatementId",
                table: "Applicant",
                column: "StatementId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Applicant_StatementId1",
                table: "Applicant",
                column: "StatementId1");

            migrationBuilder.CreateIndex(
                name: "IX_Basis_CurrencyId",
                table: "Basis",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Basis_RealEstateRightId",
                table: "Basis",
                column: "RealEstateRightId");

            migrationBuilder.CreateIndex(
                name: "IX_District_RegionId",
                table: "District",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_JobTitle_Name",
                table: "JobTitle",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Locality_DistrictId",
                table: "Locality",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationalUnit_ParentId",
                table: "OrganizationalUnit",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_RealEstate_CurrencyId",
                table: "RealEstate",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_RealEstateRight_ApplicantId",
                table: "RealEstateRight",
                column: "ApplicantId");

            migrationBuilder.CreateIndex(
                name: "IX_RealEstateRight_RealEstateId",
                table: "RealEstateRight",
                column: "RealEstateId");

            migrationBuilder.CreateIndex(
                name: "IX_Region_CountryId",
                table: "Region",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Statement_LocalityId",
                table: "Statement",
                column: "LocalityId");

            migrationBuilder.CreateIndex(
                name: "IX_Statement_RealEstateRightId",
                table: "Statement",
                column: "RealEstateRightId");

            migrationBuilder.CreateIndex(
                name: "IX_Statement_UserId",
                table: "Statement",
                column: "UserId");

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

            migrationBuilder.CreateIndex(
                name: "IX_User_JobTitleId",
                table: "User",
                column: "JobTitleId");

            migrationBuilder.CreateIndex(
                name: "IX_User_Name",
                table: "User",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_User_OrganizationalUnitId",
                table: "User",
                column: "OrganizationalUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_User_UserId",
                table: "User",
                column: "UserId",
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
                name: "FK_RealEstateRight_Applicant_ApplicantId",
                table: "RealEstateRight",
                column: "ApplicantId",
                principalTable: "Applicant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applicant_Statement_StatementId",
                table: "Applicant");

            migrationBuilder.DropForeignKey(
                name: "FK_Applicant_Statement_StatementId1",
                table: "Applicant");

            migrationBuilder.DropTable(
                name: "AppMigrationHistory");

            migrationBuilder.DropTable(
                name: "Basis");

            migrationBuilder.DropTable(
                name: "TerritorialUnit");

            migrationBuilder.DropTable(
                name: "UserLocality");

            migrationBuilder.DropTable(
                name: "Village");

            migrationBuilder.DropTable(
                name: "TerritorialUnitType");

            migrationBuilder.DropTable(
                name: "Statement");

            migrationBuilder.DropTable(
                name: "Locality");

            migrationBuilder.DropTable(
                name: "RealEstateRight");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "District");

            migrationBuilder.DropTable(
                name: "Applicant");

            migrationBuilder.DropTable(
                name: "RealEstate");

            migrationBuilder.DropTable(
                name: "JobTitle");

            migrationBuilder.DropTable(
                name: "OrganizationalUnit");

            migrationBuilder.DropTable(
                name: "Region");

            migrationBuilder.DropTable(
                name: "Currency");

            migrationBuilder.DropTable(
                name: "Country");
        }
    }
}
