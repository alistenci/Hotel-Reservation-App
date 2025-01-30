using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eHotelApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class mg7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "Reservations",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PaymentStatus",
                table: "Reservations",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "eMail",
                table: "Reservations",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "floorNumber",
                table: "Reservations",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "fullName",
                table: "Reservations",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "phoneNumber",
                table: "Reservations",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "roomNumber",
                table: "Reservations",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Notes",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "PaymentStatus",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "eMail",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "floorNumber",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "fullName",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "phoneNumber",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "roomNumber",
                table: "Reservations");
        }
    }
}
