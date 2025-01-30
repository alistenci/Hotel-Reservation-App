using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eHotelApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class mgg4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "maxChildren",
                table: "Rooms",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "maxChildren",
                table: "Rooms");
        }
    }
}
