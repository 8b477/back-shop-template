using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Database_Shop.Migrations.SqlServer
{
    /// <inheritdoc />
    public partial class initialCreate_SqlServer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Article",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "NVARCHAR(50)", maxLength: 50, nullable: false, comment: "Nom de l'article"),
                    Stock = table.Column<int>(type: "INT", nullable: false, comment: "Nombre d'articles en stock"),
                    Promo = table.Column<bool>(type: "BIT", nullable: false, comment: "Article en promotion"),
                    Price = table.Column<decimal>(type: "DECIMAL(18,2)", nullable: false, comment: "Prix de l'article")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Article", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "NVARCHAR(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Pseudo = table.Column<string>(type: "NVARCHAR(50)", maxLength: 50, nullable: false, comment: "Pseudo de l'utilisateur"),
                    Mail = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Email de l'utilisateur"),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Password de l'utilisateur"),
                    Role = table.Column<string>(type: "NVARCHAR(50)", nullable: false, comment: "Rôle de l'utilisateur")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ArticleCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArticleId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhoneNumber = table.Column<string>(type: "NVARCHAR(20)", maxLength: 20, nullable: true, comment: "Numéro de téléphone"),
                    PostalCode = table.Column<string>(type: "NVARCHAR(20)", maxLength: 20, nullable: false, comment: "Code postal"),
                    StreetNumber = table.Column<string>(type: "NVARCHAR(20)", maxLength: 20, nullable: false, comment: "Numéro de rue"),
                    StreetName = table.Column<string>(type: "NVARCHAR(50)", maxLength: 50, nullable: false, comment: "Nom de rue"),
                    Country = table.Column<string>(type: "NVARCHAR(50)", maxLength: 50, nullable: false, comment: "Pays"),
                    City = table.Column<string>(type: "NVARCHAR(50)", maxLength: 50, nullable: false, comment: "Ville"),
                    UserId = table.Column<int>(type: "int", nullable: false)
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
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "NVARCHAR(50)", maxLength: 50, nullable: false, comment: "Status de la commande"),
                    CreatedAt = table.Column<DateTime>(type: "DATETIME2", nullable: false, comment: "Date de création"),
                    SentAt = table.Column<DateTime>(type: "DATETIME2", nullable: true, comment: "Date d'envoie")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderArticle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ArticleId = table.Column<int>(type: "int", nullable: false)
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
                        name: "FK_OrderArticle_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Article",
                columns: new[] { "Id", "Name", "Price", "Promo", "Stock" },
                values: new object[,]
                {
                    { 1, "Tomate", 0.25m, false, 100 },
                    { 2, "Banane", 1.3m, true, 50 },
                    { 3, "Vodka", 14.95m, false, 20 },
                    { 4, "Chips Lays Nature", 2.95m, false, 10 },
                    { 5, "Chips Lays Paprika", 4.99m, false, 200 },
                    { 6, "Fritte", 4.99m, false, 200 },
                    { 7, "Thon", 3.95m, false, 15 }
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
                columns: new[] { "Id", "Mail", "Pseudo", "Password", "Role" },
                values: new object[,]
                {
                    { 1, "admin@mail.be", "admin", "$2a$11$TLEYWStq1Um2QoP4K4uRfuvJNBkjw3WqdKb.Slm/ZEFXvMFLOJ1g2", "Admin" },
                    { 2, "user@mail.be", "user", "$2a$11$zcj645abT3lUNwAcn5SUQekdKeL1c/SHuvZqNMldvMW9CpbpqNRBm", "User" },
                    { 3, "user2@mail.be", "user2", "$2a$11$Xai40lcmbAfKM3kiLzZFde7Y4y25uX1kWQF3g1hpQN.jIEZLv0Q6G", "User" },
                    { 4, "user3@mail.be", "user3", "$2a$11$R4aHEtvDG7EELrU.b2XO/uQLIG4UkslQ8Dd2eE4tOFkluiZKJQJgy", "User" },
                    { 5, "user4@mail.be", "user4", "$2a$11$oNeu5cH.h5xOuOAGzBsD1enDNb75O4dXUxBw5d5ODa0jRwGrQ31Xe", "User" }
                });

            migrationBuilder.InsertData(
                table: "Address",
                columns: new[] { "Id", "City", "Country", "PhoneNumber", "PostalCode", "StreetName", "StreetNumber", "UserId" },
                values: new object[,]
                {
                    { 1, "Charleroi", "Belgique", "", "6000", "rue de la Force", "10", 1 },
                    { 2, "Lille", "France", "0687654321", "69001", "rue des fous", "5", 2 },
                    { 3, "Nismes", "Belgique", "", "5670", "rue longue", "5", 3 }
                });

            migrationBuilder.InsertData(
                table: "Order",
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
                name: "IX_Order_UserId",
                table: "Order",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderArticle_ArticleId",
                table: "OrderArticle",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderArticle_OrderId",
                table: "OrderArticle",
                column: "OrderId");
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
                name: "Order");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
