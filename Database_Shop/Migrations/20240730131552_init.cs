using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Database_Shop.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Article",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Stock = table.Column<int>(type: "INTEGER", nullable: false, defaultValue: 0),
                    Promo = table.Column<bool>(type: "INTEGER", nullable: false, defaultValue: false),
                    Price = table.Column<double>(type: "REAL", nullable: false, defaultValue: 0.0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Article", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Pseudo = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Mail = table.Column<string>(type: "TEXT", nullable: false),
                    Pwd = table.Column<string>(type: "TEXT", nullable: false),
                    Role = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ArticleCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ArticleId = table.Column<int>(type: "INTEGER", nullable: false),
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArticleCategories_Article_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Article",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArticleCategories_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true, comment: "Numéro de téléphone"),
                    PostalCode = table.Column<int>(type: "TEXT", nullable: false, defaultValue: 0, comment: "Code postal"),
                    StreetNumber = table.Column<int>(type: "TEXT", nullable: false, defaultValue: 0, comment: "Numéro de rue"),
                    StreetName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false, comment: "Nom de rue"),
                    Country = table.Column<string>(type: "TEXT", maxLength: 35, nullable: false, comment: "Pays"),
                    City = table.Column<string>(type: "TEXT", maxLength: 85, nullable: false, comment: "Ville"),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Address_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    Status = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    SentAt = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderArticle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OrderId = table.Column<int>(type: "INTEGER", nullable: false),
                    ArticleId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderArticle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderArticle_Article_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Article",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderArticle_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Article",
                columns: new[] { "Id", "Name", "Price", "Stock" },
                values: new object[] { 1, "Tomate", 0.25, 100 });

            migrationBuilder.InsertData(
                table: "Article",
                columns: new[] { "Id", "Name", "Price", "Promo", "Stock" },
                values: new object[] { 2, "Banane", 1.3, true, 50 });

            migrationBuilder.InsertData(
                table: "Article",
                columns: new[] { "Id", "Name", "Price", "Stock" },
                values: new object[,]
                {
                    { 3, "Vodka", 14.949999999999999, 20 },
                    { 4, "Chips Lays Nature", 2.9500000000000002, 10 },
                    { 5, "Chips Lays Paprika", 4.9900000000000002, 200 },
                    { 6, "Fritte", 4.9900000000000002, 200 },
                    { 7, "Thon", 3.9500000000000002, 15 }
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Boisson" },
                    { 2, "Alcool" },
                    { 3, "Snack" },
                    { 4, "Frais" },
                    { 5, "Surgeler" },
                    { 6, "Légume" },
                    { 7, "Fruit" },
                    { 8, "Sec" },
                    { 9, "Conserve" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Mail", "Pseudo", "Pwd", "Role" },
                values: new object[,]
                {
                    { 1, "admin@mail.be", "admin", "$2a$11$Yk36wUkpJGH3r5kernjDSeGRJE5HIJpH8dAgZ/y2w8yIgq58asrEa", "Admin" },
                    { 2, "user@mail.be", "user", "$2a$11$GpKMCWY/1yvNaFP91R8d.umObU1UUil5BE64WzOvclHApajZut.46", "User" },
                    { 3, "user2@mail.be", "user2", "$2a$11$Nw1GymfCKaMamJSIpulc/.1hczIuu8DE9wxDOIz2xdeS9H4ts5v5a", "User" },
                    { 4, "user3@mail.be", "user3", "$2a$11$14efNir7ds7j4BhrnEgnc.sbM65GB916FBTwdug1vAL2BFrAqrAKa", "User" },
                    { 5, "user4@mail.be", "user4", "$2a$11$4JheBtLeiBFyHQkUX4IV5esbg6/ApAlHvaJ.w9N0jNI8S4KsZoRZm", "User" }
                });

            migrationBuilder.InsertData(
                table: "Address",
                columns: new[] { "Id", "City", "Country", "PhoneNumber", "PostalCode", "StreetName", "StreetNumber", "UserId" },
                values: new object[,]
                {
                    { 1, "Charleroi", "Belgique", "", 6000, "rue de la Force", 10, 1 },
                    { 2, "Lille", "France", "0687654321", 69001, "rue des fous", 5, 2 },
                    { 3, "Nismes", "Belgique", "", 5670, "rue longue", 5, 3 }
                });

            migrationBuilder.InsertData(
                table: "ArticleCategories",
                columns: new[] { "Id", "ArticleId", "CategoryId" },
                values: new object[,]
                {
                    { 1, 1, 4 },
                    { 2, 1, 6 },
                    { 3, 1, 7 },
                    { 4, 2, 4 },
                    { 5, 2, 7 },
                    { 6, 3, 1 },
                    { 7, 3, 2 },
                    { 8, 4, 3 },
                    { 9, 4, 8 },
                    { 10, 5, 3 },
                    { 11, 5, 8 },
                    { 12, 6, 5 },
                    { 13, 7, 9 }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CreatedAt", "SentAt", "Status", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sent", 2 },
                    { 2, new DateTime(2023, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Pending", 2 },
                    { 3, new DateTime(2023, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Pending", 3 },
                    { 4, new DateTime(2023, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "InProgress", 4 },
                    { 5, new DateTime(2023, 8, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 8, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "InProgress", 4 }
                });

            migrationBuilder.InsertData(
                table: "OrderArticle",
                columns: new[] { "Id", "ArticleId", "OrderId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 1, 2 },
                    { 3, 2, 2 },
                    { 4, 1, 3 },
                    { 5, 2, 3 },
                    { 6, 3, 3 },
                    { 7, 1, 4 },
                    { 8, 2, 4 },
                    { 9, 3, 4 },
                    { 10, 4, 4 },
                    { 11, 1, 5 },
                    { 12, 2, 5 },
                    { 13, 3, 5 },
                    { 14, 4, 5 },
                    { 15, 5, 5 },
                    { 16, 6, 5 },
                    { 17, 7, 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_UserId",
                table: "Address",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ArticleCategories_ArticleId",
                table: "ArticleCategories",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_ArticleCategories_CategoryId",
                table: "ArticleCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderArticle_ArticleId",
                table: "OrderArticle",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderArticle_OrderId",
                table: "OrderArticle",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "ArticleCategories");

            migrationBuilder.DropTable(
                name: "OrderArticle");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Article");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
