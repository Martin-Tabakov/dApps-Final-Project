using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Meeting_Room_Booking.Migrations
{
    public partial class updatedIDs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Meets_BoardRooms_BoardRoomId",
                table: "Meets");

            migrationBuilder.DropForeignKey(
                name: "FK_Meets_Employees_ReserverId",
                table: "Meets");

            migrationBuilder.AlterColumn<Guid>(
                name: "ReserverId",
                table: "Meets",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "BoardRoomId",
                table: "Meets",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Meets_BoardRooms_BoardRoomId",
                table: "Meets",
                column: "BoardRoomId",
                principalTable: "BoardRooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Meets_Employees_ReserverId",
                table: "Meets",
                column: "ReserverId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Meets_BoardRooms_BoardRoomId",
                table: "Meets");

            migrationBuilder.DropForeignKey(
                name: "FK_Meets_Employees_ReserverId",
                table: "Meets");

            migrationBuilder.AlterColumn<Guid>(
                name: "ReserverId",
                table: "Meets",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "BoardRoomId",
                table: "Meets",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Meets_BoardRooms_BoardRoomId",
                table: "Meets",
                column: "BoardRoomId",
                principalTable: "BoardRooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Meets_Employees_ReserverId",
                table: "Meets",
                column: "ReserverId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
