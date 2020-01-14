using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace WatchdogApi.Migrations
{
    public partial class AddedAssignPersonTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AssignPerson",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Role = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssignPerson", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AssignPerson",
                columns: new[] { "Id", "Role" },
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
                name: "AssignPerson");
        }
    }
}
