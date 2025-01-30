using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eHotelApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class mgr3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Users_appUserId",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_appUserId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "GuestsId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "TempGuestsId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "appUserId",
                table: "Reservations");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "GuestsId",
                table: "Reservations",
                type: "uuid",
                nullable: true);

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
    }
}
