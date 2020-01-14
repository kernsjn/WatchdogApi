using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace WatchdogApi.Migrations
{
    public partial class AddedScopeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "Scopes",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { 1, "Site" },
                    { 2, "Fixed System: Roof" },
                    { 3, "Fixed System: Building Interior" },
                    { 4, "Fixed System: Building Exterior" },
                    { 5, "Operating System: HVAC" },
                    { 6, "Operating System: Electrical" },
                    { 7, "Operating System: Plumbing" },
                    { 8, "Operating System: Fire & Life Safety" },
                    { 9, "Operating System: Kitchen" },
                    { 10, "Operating System: Vertical Transport" },
                    { 11, "Other" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Scopes");
        }
    }
}
