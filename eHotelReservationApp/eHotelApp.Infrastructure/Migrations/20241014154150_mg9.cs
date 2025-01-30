using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eHotelApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class mg9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Users_GuestsId",
                table: "Reservations");

            migrationBuilder.AlterColumn<Guid>(
                name: "GuestsId",
                table: "Reservations",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<Guid>(
                name: "TempGuidId",
                table: "Reservations",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Users_GuestsId",
                table: "Reservations",
                column: "GuestsId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Users_GuestsId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "TempGuidId",
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

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Users_GuestsId",
                table: "Reservations",
                column: "GuestsId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
