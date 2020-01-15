using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace WatchdogApi.Migrations
{
    public partial class AddedRequestorTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "AssignPerson");

            migrationBuilder.AddColumn<string>(
                name: "AssignRole",
                table: "AssignPerson",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Requestor",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RequestRole = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requestor", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AssignPerson",
                keyColumn: "Id",
                keyValue: 1,
                column: "AssignRole",
                value: "Owner");

            migrationBuilder.UpdateData(
                table: "AssignPerson",
                keyColumn: "Id",
                keyValue: 2,
                column: "AssignRole",
                value: "Architect");

            migrationBuilder.UpdateData(
                table: "AssignPerson",
                keyColumn: "Id",
                keyValue: 3,
                column: "AssignRole",
                value: "General Contractor");

            migrationBuilder.UpdateData(
                table: "AssignPerson",
                keyColumn: "Id",
                keyValue: 4,
                column: "AssignRole",
                value: "Subcontractor");

            migrationBuilder.InsertData(
                table: "Requestor",
                columns: new[] { "Id", "RequestRole" },
                values: new object[,]
                {
                    { 1, "Owner" },
                    { 2, "Architect" },
                    { 3, "General Contractor" },
                    { 4, "Subcontractor" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Requestor");

            migrationBuilder.DropColumn(
                name: "AssignRole",
                table: "AssignPerson");

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "AssignPerson",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AssignPerson",
                keyColumn: "Id",
                keyValue: 1,
                column: "Role",
                value: "Owner");

            migrationBuilder.UpdateData(
                table: "AssignPerson",
                keyColumn: "Id",
                keyValue: 2,
                column: "Role",
                value: "Architect");

            migrationBuilder.UpdateData(
                table: "AssignPerson",
                keyColumn: "Id",
                keyValue: 3,
                column: "Role",
                value: "General Contractor");

            migrationBuilder.UpdateData(
                table: "AssignPerson",
                keyColumn: "Id",
                keyValue: 4,
                column: "Role",
                value: "Subcontractor");
        }
    }
}
