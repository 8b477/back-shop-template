using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database_Shop.Migrations
{
    /// <inheritdoc />
    public partial class truc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Id_User = table.Column<int>(type: "INTEGER", nullable: false),
                    Status = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    CreateAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    SendAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Article",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Stock = table.Column<int>(type: "INTEGER", nullable: false),
                    Promo = table.Column<bool>(type: "INTEGER", nullable: false),
                    Price = table.Column<int>(type: "INTEGER", nullable: false),
                    OrderId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Article", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Article_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Drink = table.Column<bool>(type: "INTEGER", nullable: false),
                    Canned = table.Column<bool>(type: "INTEGER", nullable: false),
                    Baby = table.Column<bool>(type: "INTEGER", nullable: false),
                    Health = table.Column<bool>(type: "INTEGER", nullable: false),
                    Dairy = table.Column<bool>(type: "INTEGER", nullable: false),
                    Bakery = table.Column<bool>(type: "INTEGER", nullable: false),
                    Fruit = table.Column<bool>(type: "INTEGER", nullable: false),
                    Vegetable = table.Column<bool>(type: "INTEGER", nullable: false),
                    Meat = table.Column<bool>(type: "INTEGER", nullable: false),
                    Snack = table.Column<bool>(type: "INTEGER", nullable: false),
                    Frozen = table.Column<bool>(type: "INTEGER", nullable: false),
                    ArticleId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Category_Article_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Article",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Article_OrderId",
                table: "Article",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Category_ArticleId",
                table: "Category",
                column: "ArticleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Article");

            migrationBuilder.DropTable(
                name: "Order");
        }
    }
}
