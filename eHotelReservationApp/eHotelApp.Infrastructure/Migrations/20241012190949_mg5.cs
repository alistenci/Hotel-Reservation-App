using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eHotelApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class mg5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Guests_Reservations_ReservationsId",
                table: "Guests");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomInstances_Reservations_ReservationsId",
                table: "RoomInstances");

            migrationBuilder.DropIndex(
                name: "IX_RoomInstances_ReservationsId",
                table: "RoomInstances");

            migrationBuilder.DropIndex(
                name: "IX_Guests_ReservationsId",
                table: "Guests");

            migrationBuilder.DropColumn(
                name: "ReservationsId",
                table: "RoomInstances");

            migrationBuilder.DropColumn(
                name: "CheckInDate",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "CheckOutDate",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "ReservationsId",
                table: "Guests");

            migrationBuilder.AddColumn<Guid>(
                name: "GuestsId",
                table: "Reservations",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ReservedRoomsId",
                table: "Reservations",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RoomId",
                table: "Reservations",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_GuestsId",
                table: "Reservations",
                column: "GuestsId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_ReservedRoomsId",
                table: "Reservations",
                column: "ReservedRoomsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Rooms_ReservedRoomsId",
                table: "Reservations",
                column: "ReservedRoomsId",
                principalTable: "Rooms",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Users_GuestsId",
                table: "Reservations",
                column: "GuestsId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Rooms_ReservedRoomsId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Users_GuestsId",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_GuestsId",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_ReservedRoomsId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "GuestsId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "ReservedRoomsId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "RoomId",
                table: "Reservations");

            migrationBuilder.AddColumn<Guid>(
                name: "ReservationsId",
                table: "RoomInstances",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CheckInDate",
                table: "Reservations",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CheckOutDate",
                table: "Reservations",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "ReservationsId",
                table: "Guests",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RoomInstances_ReservationsId",
                table: "RoomInstances",
                column: "ReservationsId");

            migrationBuilder.CreateIndex(
                name: "IX_Guests_ReservationsId",
                table: "Guests",
                column: "ReservationsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Guests_Reservations_ReservationsId",
                table: "Guests",
                column: "ReservationsId",
                principalTable: "Reservations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RoomInstances_Reservations_ReservationsId",
                table: "RoomInstances",
                column: "ReservationsId",
                principalTable: "Reservations",
                principalColumn: "Id");
        }
    }
}
