using Microsoft.EntityFrameworkCore.Migrations;

namespace WatchdogApi.Migrations
{
    public partial class UpdatedFKNamed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PunchListItems_AssignPersons_AssignPersonId",
                table: "PunchListItems");

            migrationBuilder.DropColumn(
                name: "AssignId",
                table: "PunchListItems");

            migrationBuilder.AlterColumn<int>(
                name: "AssignPersonId",
                table: "PunchListItems",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PunchListItems_AssignPersons_AssignPersonId",
                table: "PunchListItems",
                column: "AssignPersonId",
                principalTable: "AssignPersons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PunchListItems_AssignPersons_AssignPersonId",
                table: "PunchListItems");

            migrationBuilder.AlterColumn<int>(
                name: "AssignPersonId",
                table: "PunchListItems",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "AssignId",
                table: "PunchListItems",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_PunchListItems_AssignPersons_AssignPersonId",
                table: "PunchListItems",
                column: "AssignPersonId",
                principalTable: "AssignPersons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
