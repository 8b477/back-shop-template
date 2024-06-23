using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_Shop.DB.Migrations
{
    /// <inheritdoc />
    public partial class upTableUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MdpConfirm",
                table: "User",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MdpConfirm",
                table: "User");
        }
    }
}
