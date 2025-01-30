using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eHotelApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class mgr2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "identityNumber",
                table: "Reservations",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "identityNumber",
                table: "Reservations");
        }
    }
}
