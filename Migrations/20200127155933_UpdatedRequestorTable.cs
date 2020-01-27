using Microsoft.EntityFrameworkCore.Migrations;

namespace WatchdogApi.Migrations
{
    public partial class UpdatedRequestorTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PunchListItems_Requestors_RequestorId",
                table: "PunchListItems");

            migrationBuilder.DropColumn(
                name: "RequestId",
                table: "PunchListItems");

            migrationBuilder.AlterColumn<int>(
                name: "RequestorId",
                table: "PunchListItems",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PunchListItems_Requestors_RequestorId",
                table: "PunchListItems",
                column: "RequestorId",
                principalTable: "Requestors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PunchListItems_Requestors_RequestorId",
                table: "PunchListItems");

            migrationBuilder.AlterColumn<int>(
                name: "RequestorId",
                table: "PunchListItems",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "RequestId",
                table: "PunchListItems",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_PunchListItems_Requestors_RequestorId",
                table: "PunchListItems",
                column: "RequestorId",
                principalTable: "Requestors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
