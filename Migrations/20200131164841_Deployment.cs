using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace WatchdogApi.Migrations
{
    public partial class Deployment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AssignPersons",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AssignRole = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssignPersons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Facilities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FacilityName = table.Column<string>(nullable: false),
                    DateFacilityAdded = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facilities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Requestors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RequestRole = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requestors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Scopes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scopes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Buildings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BuildingName = table.Column<string>(nullable: true),
                    DateBuildingAdded = table.Column<DateTime>(nullable: false),
                    FacilityId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buildings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Buildings_Facilities_FacilityId",
                        column: x => x.FacilityId,
                        principalTable: "Facilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PunchListItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Issue = table.Column<string>(nullable: true),
                    IssueLocation = table.Column<string>(nullable: true),
                    Resolution = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    FacilityId = table.Column<int>(nullable: false),
                    BuildingId = table.Column<int>(nullable: false),
                    ScopeId = table.Column<int>(nullable: false),
                    AssignPersonId = table.Column<int>(nullable: false),
                    RequestorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PunchListItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PunchListItems_AssignPersons_AssignPersonId",
                        column: x => x.AssignPersonId,
                        principalTable: "AssignPersons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PunchListItems_Buildings_BuildingId",
                        column: x => x.BuildingId,
                        principalTable: "Buildings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PunchListItems_Facilities_FacilityId",
                        column: x => x.FacilityId,
                        principalTable: "Facilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PunchListItems_Requestors_RequestorId",
                        column: x => x.RequestorId,
                        principalTable: "Requestors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PunchListItems_Scopes_ScopeId",
                        column: x => x.ScopeId,
                        principalTable: "Scopes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AssignPersons",
                columns: new[] { "Id", "AssignRole" },
                values: new object[,]
                {
                    { 1, "Owner" },
                    { 2, "Architect" },
                    { 3, "General Contractor" },
                    { 4, "Subcontractor" }
                });

            migrationBuilder.InsertData(
                table: "Requestors",
                columns: new[] { "Id", "RequestRole" },
                values: new object[,]
                {
                    { 1, "Owner" },
                    { 2, "Architect" },
                    { 3, "General Contractor" },
                    { 4, "Subcontractor" }
                });

            migrationBuilder.InsertData(
                table: "Scopes",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { 9, "Operating System: Kitchen" },
                    { 8, "Operating System: Fire & Life Safety" },
                    { 7, "Operating System: Plumbing" },
                    { 6, "Operating System: Electrical" },
                    { 2, "Fixed System: Roof" },
                    { 4, "Fixed System: Building Exterior" },
                    { 3, "Fixed System: Building Interior" },
                    { 10, "Operating System: Vertical Transport" },
                    { 1, "Site" },
                    { 5, "Operating System: HVAC" },
                    { 11, "Other" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Buildings_FacilityId",
                table: "Buildings",
                column: "FacilityId");

            migrationBuilder.CreateIndex(
                name: "IX_PunchListItems_AssignPersonId",
                table: "PunchListItems",
                column: "AssignPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_PunchListItems_BuildingId",
                table: "PunchListItems",
                column: "BuildingId");

            migrationBuilder.CreateIndex(
                name: "IX_PunchListItems_FacilityId",
                table: "PunchListItems",
                column: "FacilityId");

            migrationBuilder.CreateIndex(
                name: "IX_PunchListItems_RequestorId",
                table: "PunchListItems",
                column: "RequestorId");

            migrationBuilder.CreateIndex(
                name: "IX_PunchListItems_ScopeId",
                table: "PunchListItems",
                column: "ScopeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PunchListItems");

            migrationBuilder.DropTable(
                name: "AssignPersons");

            migrationBuilder.DropTable(
                name: "Buildings");

            migrationBuilder.DropTable(
                name: "Requestors");

            migrationBuilder.DropTable(
                name: "Scopes");

            migrationBuilder.DropTable(
                name: "Facilities");
        }
    }
}
