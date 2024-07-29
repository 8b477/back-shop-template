using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database_Shop.Migrations
{
    /// <inheritdoc />
    public partial class correctnameofaddresstable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresse_User_UserId",
                table: "Addresse");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Addresse",
                table: "Addresse");

            migrationBuilder.RenameTable(
                name: "Addresse",
                newName: "Address");

            migrationBuilder.RenameIndex(
                name: "IX_Addresse_UserId",
                table: "Address",
                newName: "IX_Address_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Address",
                table: "Address",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                column: "Pwd",
                value: "$2a$11$tWOILVd7BHWBA5R1y3D.NOEp9x6NU5sbfTm9hxCJr0X2HGYA7ekK6");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                column: "Pwd",
                value: "$2a$11$U4g.KSjNTTs9tbLKvnGP6.xtCfu.Fp.Y1dfB/kUKk6NdlqyCySo1e");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3,
                column: "Pwd",
                value: "$2a$11$FxcRbE8muAllaodUwTNndO2KUKgFUQMXmRbQkerTBwIrYTKyNpYxm");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 4,
                column: "Pwd",
                value: "$2a$11$bHZCUgMz3QZ/fsINESlGKeXUcOU3pKndL42cpDmh.zda4QsPHz97G");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 5,
                column: "Pwd",
                value: "$2a$11$rtjC2mMQ/bkje3nsIgTSV.jtVC2xXE1FWOog3LHm39UZPJVeQQRJ.");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_User_UserId",
                table: "Address",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_User_UserId",
                table: "Address");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Address",
                table: "Address");

            migrationBuilder.RenameTable(
                name: "Address",
                newName: "Addresse");

            migrationBuilder.RenameIndex(
                name: "IX_Address_UserId",
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
    }
}
