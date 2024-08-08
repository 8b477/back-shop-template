using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database_Shop.Migrations.SqlLite
{
    /// <inheritdoc />
    public partial class up08082024 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$dQKz8GZmD3QDWRAjyMXr6u1ed5GKPOwZYuNCKzeGcWRHzPPXBmxvS");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$Pu7EDwijYrWwSZK2HAoD0ew4kQ/RVFXEOWxX3pWdfIiHis0u6AVwy");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$6ESg.JOT64bO0msL5jAFMOSKaHAQT1qiNLcOUdFnfZKm/sBiXQV/S");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 4,
                column: "Password",
                value: "$2a$11$WNxRJJWKpwIK.fF7UtvqduJ1dVoTA0dkwTuyrbPbz6.4XWLSO5Sza");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 5,
                column: "Password",
                value: "$2a$11$PPECv0iWguY0yvUPdfS0bex9k12hlmcnVsMCJhx6L3TSHrqg5nHpm");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
