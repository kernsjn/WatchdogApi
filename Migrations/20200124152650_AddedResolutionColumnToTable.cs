using Microsoft.EntityFrameworkCore.Migrations;

namespace WatchdogApi.Migrations
{
    public partial class AddedResolutionColumnToTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Resolution",
                table: "PunchListItems",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Resolution",
                table: "PunchListItems");
        }
    }
}
