using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Database_Shop.Migrations.SqlServer
{
    /// <inheritdoc />
    public partial class add_relation_articleCategories_SqlServer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$1Trv54jR79EO6KPyRbP3iejphq1U4wDDueiQFPRwFhFii6E4SKcJa");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$ozFkzMQ7jTvthGqLd7Xqw.1QkCnOUkUme3rcXwnGz6p0/ZO1XuJ0i");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$l0MTPpkJSfgVNl7PITzpC.cFQ4t5uWTIrt6EP.qK.KVCTn3dZdEwK");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 4,
                column: "Password",
                value: "$2a$11$yO6AVfGtrornBx28G6tAbOS41S4hGn4SzQYeTMN1fcYRVeDV21kLe");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 5,
                column: "Password",
                value: "$2a$11$DS6zH.uGsCavWhk4t4pz5O5M7e.c0K2JDoxKg2GFKzhO4tVtViRtC");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ArticleCategories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ArticleCategories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ArticleCategories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ArticleCategories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ArticleCategories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ArticleCategories",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ArticleCategories",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ArticleCategories",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "ArticleCategories",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "ArticleCategories",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "ArticleCategories",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "ArticleCategories",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "ArticleCategories",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$TLEYWStq1Um2QoP4K4uRfuvJNBkjw3WqdKb.Slm/ZEFXvMFLOJ1g2");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$zcj645abT3lUNwAcn5SUQekdKeL1c/SHuvZqNMldvMW9CpbpqNRBm");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$Xai40lcmbAfKM3kiLzZFde7Y4y25uX1kWQF3g1hpQN.jIEZLv0Q6G");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 4,
                column: "Password",
                value: "$2a$11$R4aHEtvDG7EELrU.b2XO/uQLIG4UkslQ8Dd2eE4tOFkluiZKJQJgy");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 5,
                column: "Password",
                value: "$2a$11$oNeu5cH.h5xOuOAGzBsD1enDNb75O4dXUxBw5d5ODa0jRwGrQ31Xe");
        }
    }
}
