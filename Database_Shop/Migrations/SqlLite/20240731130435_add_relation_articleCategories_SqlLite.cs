using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Database_Shop.Migrations.SqlLite
{
    /// <inheritdoc />
    public partial class add_relation_articleCategories_SqlLite : Migration
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
                value: "$2a$11$SiDnPs83LVzP2Q5pI13cwewCyOWJmJu19t60NI3lySFvaLXQbISSi");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$AvifplpoceA.XSxyl2Mzp.9pFQVRz5sXm7XZGQT4fOlrMLcM/2GWG");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$pf797/44FY5N00X.wh8Cc.b2c1.TS19SwJ587VF0.HXLjlFv6THiq");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 4,
                column: "Password",
                value: "$2a$11$c9cGjaiTgDx5iu3v1gQ1y.f2fgdOeFVHg4N4.kTsBMIrMPEsMAGLu");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 5,
                column: "Password",
                value: "$2a$11$O1utu.IW27QNdRkgu4H.D.ZP0szwyDJFEmw8MSpSLyPfRL2RiZx.S");
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
                value: "$2a$11$zUTr7KxjScu7I0NhJhkeQ./jXN0iwMZxFh25RwECzSuZ8V5YWXdya");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$RZ1sro3AxQCUV8Vab0U1GO7mpaG/Zar7TyHiNqKqpRA64l9sb3vre");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$NdQskB2Oq6S6Y81raiIwaOQifYaGPoKDsyXQuCcSY49CYXgik//H2");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 4,
                column: "Password",
                value: "$2a$11$OGtV0XH4hOtxeR6awMcaIuQV4/yHmPFLL5O78mA3Ne2JbuR37e2y.");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 5,
                column: "Password",
                value: "$2a$11$EEZew34crZuPiM5qFilBg.Azbac1MTk5w555taHQs.f7dDqsIQh9a");
        }
    }
}
