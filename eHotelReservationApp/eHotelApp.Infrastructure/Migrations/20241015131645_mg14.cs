using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eHotelApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class mg14 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "GuestsId",
                table: "Reservations",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<Guid>(
                name: "TempGuestsId",
                table: "Reservations",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "appUserId",
                table: "Reservations",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_appUserId",
                table: "Reservations",
                column: "appUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Users_appUserId",
                table: "Reservations",
                column: "appUserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Users_appUserId",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_appUserId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "TempGuestsId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "appUserId",
                table: "Reservations");

            migrationBuilder.AlterColumn<Guid>(
                name: "GuestsId",
                table: "Reservations",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);
        }
    }
}
