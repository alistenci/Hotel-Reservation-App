using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eHotelApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class mg13 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Users_GuestsId",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_GuestsId",
                table: "Reservations");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Reservations_GuestsId",
                table: "Reservations",
                column: "GuestsId");

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
