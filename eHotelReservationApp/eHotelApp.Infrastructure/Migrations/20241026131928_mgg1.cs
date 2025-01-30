using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eHotelApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class mgg1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "RoomTypess",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "RoomTypess");
        }
    }
}
