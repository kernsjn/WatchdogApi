using Microsoft.EntityFrameworkCore.Migrations;

namespace WatchdogApi.Migrations
{
    public partial class RevisedPunchListItemTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PunchListItems_AssignPersons_AssignPersonsId",
                table: "PunchListItems");

            migrationBuilder.DropForeignKey(
                name: "FK_PunchListItems_Requestors_RequestorsId",
                table: "PunchListItems");

            migrationBuilder.DropIndex(
                name: "IX_PunchListItems_AssignPersonsId",
                table: "PunchListItems");

            migrationBuilder.DropIndex(
                name: "IX_PunchListItems_RequestorsId",
                table: "PunchListItems");

            migrationBuilder.DropColumn(
                name: "AssignPersonsId",
                table: "PunchListItems");

            migrationBuilder.DropColumn(
                name: "RequestorsId",
                table: "PunchListItems");

            migrationBuilder.AddColumn<int>(
                name: "AssignPersonId",
                table: "PunchListItems",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RequestorId",
                table: "PunchListItems",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "PunchListItems",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PunchListItems_AssignPersonId",
                table: "PunchListItems",
                column: "AssignPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_PunchListItems_RequestorId",
                table: "PunchListItems",
                column: "RequestorId");

            migrationBuilder.AddForeignKey(
                name: "FK_PunchListItems_AssignPersons_AssignPersonId",
                table: "PunchListItems",
                column: "AssignPersonId",
                principalTable: "AssignPersons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PunchListItems_Requestors_RequestorId",
                table: "PunchListItems",
                column: "RequestorId",
                principalTable: "Requestors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PunchListItems_AssignPersons_AssignPersonId",
                table: "PunchListItems");

            migrationBuilder.DropForeignKey(
                name: "FK_PunchListItems_Requestors_RequestorId",
                table: "PunchListItems");

            migrationBuilder.DropIndex(
                name: "IX_PunchListItems_AssignPersonId",
                table: "PunchListItems");

            migrationBuilder.DropIndex(
                name: "IX_PunchListItems_RequestorId",
                table: "PunchListItems");

            migrationBuilder.DropColumn(
                name: "AssignPersonId",
                table: "PunchListItems");

            migrationBuilder.DropColumn(
                name: "RequestorId",
                table: "PunchListItems");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "PunchListItems");

            migrationBuilder.AddColumn<int>(
                name: "AssignPersonsId",
                table: "PunchListItems",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RequestorsId",
                table: "PunchListItems",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PunchListItems_AssignPersonsId",
                table: "PunchListItems",
                column: "AssignPersonsId");

            migrationBuilder.CreateIndex(
                name: "IX_PunchListItems_RequestorsId",
                table: "PunchListItems",
                column: "RequestorsId");

            migrationBuilder.AddForeignKey(
                name: "FK_PunchListItems_AssignPersons_AssignPersonsId",
                table: "PunchListItems",
                column: "AssignPersonsId",
                principalTable: "AssignPersons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PunchListItems_Requestors_RequestorsId",
                table: "PunchListItems",
                column: "RequestorsId",
                principalTable: "Requestors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
