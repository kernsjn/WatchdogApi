using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace WatchdogApi.Migrations
{
    public partial class AddedPunchListItemTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Requestor",
                table: "Requestor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AssignPerson",
                table: "AssignPerson");

            migrationBuilder.RenameTable(
                name: "Requestor",
                newName: "Requestors");

            migrationBuilder.RenameTable(
                name: "AssignPerson",
                newName: "AssignPersons");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Requestors",
                table: "Requestors",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AssignPersons",
                table: "AssignPersons",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "PunchListItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FacilityId = table.Column<int>(nullable: false),
                    Issue = table.Column<string>(nullable: true),
                    IssueLocation = table.Column<string>(nullable: true),
                    BuildingId = table.Column<int>(nullable: false),
                    ScopeId = table.Column<int>(nullable: false),
                    AssignId = table.Column<int>(nullable: false),
                    AssignPersonsId = table.Column<int>(nullable: true),
                    RequestId = table.Column<int>(nullable: false),
                    RequestorsId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PunchListItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PunchListItems_AssignPersons_AssignPersonsId",
                        column: x => x.AssignPersonsId,
                        principalTable: "AssignPersons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                        name: "FK_PunchListItems_Requestors_RequestorsId",
                        column: x => x.RequestorsId,
                        principalTable: "Requestors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PunchListItems_Scopes_ScopeId",
                        column: x => x.ScopeId,
                        principalTable: "Scopes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PunchListItems_AssignPersonsId",
                table: "PunchListItems",
                column: "AssignPersonsId");

            migrationBuilder.CreateIndex(
                name: "IX_PunchListItems_BuildingId",
                table: "PunchListItems",
                column: "BuildingId");

            migrationBuilder.CreateIndex(
                name: "IX_PunchListItems_FacilityId",
                table: "PunchListItems",
                column: "FacilityId");

            migrationBuilder.CreateIndex(
                name: "IX_PunchListItems_RequestorsId",
                table: "PunchListItems",
                column: "RequestorsId");

            migrationBuilder.CreateIndex(
                name: "IX_PunchListItems_ScopeId",
                table: "PunchListItems",
                column: "ScopeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PunchListItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Requestors",
                table: "Requestors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AssignPersons",
                table: "AssignPersons");

            migrationBuilder.RenameTable(
                name: "Requestors",
                newName: "Requestor");

            migrationBuilder.RenameTable(
                name: "AssignPersons",
                newName: "AssignPerson");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Requestor",
                table: "Requestor",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AssignPerson",
                table: "AssignPerson",
                column: "Id");
        }
    }
}
