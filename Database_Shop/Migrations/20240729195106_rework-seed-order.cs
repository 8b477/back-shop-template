using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database_Shop.Migrations
{
    /// <inheritdoc />
    public partial class reworkseedorder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "Status",
                value: "Sent");

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "Status",
                value: "Pending");

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3,
                column: "Status",
                value: "Pending");

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 4,
                column: "Status",
                value: "InProgress");

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 5,
                column: "Status",
                value: "InProgress");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                column: "Pwd",
                value: "$2a$11$U5643BXKBHqxOGAT/zP/Jekk/hig.rK8.FPO3A234agmkuuAg2Lyq");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                column: "Pwd",
                value: "$2a$11$h2dwVmdlTSwWQ/tS4A0cOeGtZV8iJageN9jJzEB6NqwgIXT.NlU9m");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3,
                column: "Pwd",
                value: "$2a$11$6jqfZgFxSH50fz9Ykzo0w.qqVse7haclbe18JS.FL8HKfn8Pqpf3K");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 4,
                column: "Pwd",
                value: "$2a$11$0LejspD6Ez40XGoiwuBVc.CDdHtnA0NQ7z6jTbEbpE5qp1knvqI5.");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 5,
                column: "Pwd",
                value: "$2a$11$BSzebWwDiZYmZFZrcTVQ0ONX7eok1UrehKO/NkBTaZcPOdgX.8A4G");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "Status",
                value: "Livré");

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "Status",
                value: "En attente");

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3,
                column: "Status",
                value: "En attente");

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 4,
                column: "Status",
                value: "Livré");

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 5,
                column: "Status",
                value: "Livré");

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
        }
    }
}
