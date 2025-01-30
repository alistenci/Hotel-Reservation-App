using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eHotelApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class mgg2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "RoomTypess");

            migrationBuilder.AddColumn<byte[]>(
                name: "ImageData",
                table: "RoomTypess",
                type: "bytea",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageData",
                table: "RoomTypess");

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "RoomTypess",
                type: "text",
                nullable: true);
        }
    }
}
