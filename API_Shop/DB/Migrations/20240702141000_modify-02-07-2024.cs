using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_Shop.DB.Migrations
{
    /// <inheritdoc />
    public partial class modify02072024 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "User");

            migrationBuilder.AddColumn<int>(
                name: "PhoneNumber",
                table: "Address",
                type: "INTEGER",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Address");

            migrationBuilder.AddColumn<int>(
                name: "PhoneNumber",
                table: "User",
                type: "INTEGER",
                nullable: true);
        }
    }
}
