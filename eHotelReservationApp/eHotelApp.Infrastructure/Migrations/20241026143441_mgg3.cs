using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eHotelApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class mgg3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageData",
                table: "RoomTypess");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "RoomTypess",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "RoomTypess");

            migrationBuilder.AddColumn<byte[]>(
                name: "ImageData",
                table: "RoomTypess",
                type: "bytea",
                nullable: true);
        }
    }
}
