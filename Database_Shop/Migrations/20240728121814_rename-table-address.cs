using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database_Shop.Migrations
{
    /// <inheritdoc />
    public partial class renametableaddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_User_UserId",
                table: "Addresses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Addresses",
                table: "Addresses");

            migrationBuilder.RenameTable(
                name: "Addresses",
                newName: "Addresse");

            migrationBuilder.RenameIndex(
                name: "IX_Addresses_UserId",
                table: "Addresse",
                newName: "IX_Addresse_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Addresse",
                table: "Addresse",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                column: "Pwd",
                value: "$2a$11$JH3NvMdgD3yud4ygjab/5.R8Ejaf6q2msKAGLCodqmxCAR4UB9Mnu");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                column: "Pwd",
                value: "$2a$11$1qdMP5pesSwBxAUlsq/uh.LgbK/TakB7KZrk8auIu7lPNplF7hwv6");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3,
                column: "Pwd",
                value: "$2a$11$wnGuUMwp0quJIB87tV76duG5TLUNKZc6waGxYxOdVPSdaErVuCBEq");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 4,
                column: "Pwd",
                value: "$2a$11$3NAL5bC.viRwzvFY0bK/EOrzv7KIR7/xNMqki1QtJydF5HTVapNPa");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 5,
                column: "Pwd",
                value: "$2a$11$.7XQfmZNHL/JeD8ltPeQu.C891RcLK/Kt..INYPc.FjGZnfktcZOe");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresse_User_UserId",
                table: "Addresse",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresse_User_UserId",
                table: "Addresse");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Addresse",
                table: "Addresse");

            migrationBuilder.RenameTable(
                name: "Addresse",
                newName: "Addresses");

            migrationBuilder.RenameIndex(
                name: "IX_Addresse_UserId",
                table: "Addresses",
                newName: "IX_Addresses_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Addresses",
                table: "Addresses",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                column: "Pwd",
                value: "$2a$11$u9wl1YMAUDkTVbA2VWJBKuqd2WJNkqA47joqDiWN7U6SuYD0YM6VC");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                column: "Pwd",
                value: "$2a$11$gs..ixsgiSBcuervhOVMie.o5R0cLE7m4zlpDhVdGOG7QM56WStPG");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3,
                column: "Pwd",
                value: "$2a$11$y05wuXNUZKIpBUfQCyKPJe9cE3DfRxikwiTTDrtu0.LCxYjgjihJ2");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 4,
                column: "Pwd",
                value: "$2a$11$OYHTAemuoBofjEhrBJAYkOGW/CjY/4gZn3Jfg8ZbyWwBvETz/D9ye");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 5,
                column: "Pwd",
                value: "$2a$11$PUttJEdSLyNhqej6s0.wbut8riK4Ovs/s7tzTSn54o.4fukLlCdl2");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_User_UserId",
                table: "Addresses",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
