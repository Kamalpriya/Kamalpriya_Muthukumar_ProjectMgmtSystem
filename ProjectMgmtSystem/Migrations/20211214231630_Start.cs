using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectMgmtSystem.Migrations
{
    public partial class Start : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Project",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2021, 12, 15, 4, 46, 27, 342, DateTimeKind.Local).AddTicks(8036));

            migrationBuilder.UpdateData(
                table: "Project",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2021, 12, 15, 4, 46, 27, 387, DateTimeKind.Local).AddTicks(9201));

            migrationBuilder.UpdateData(
                table: "Project",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2021, 12, 15, 4, 46, 27, 387, DateTimeKind.Local).AddTicks(9290));

            migrationBuilder.UpdateData(
                table: "Project",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2021, 12, 15, 4, 46, 27, 387, DateTimeKind.Local).AddTicks(9304));

            migrationBuilder.UpdateData(
                table: "Task1",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2021, 12, 15, 4, 46, 27, 388, DateTimeKind.Local).AddTicks(9671));

            migrationBuilder.UpdateData(
                table: "Task1",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2021, 12, 15, 4, 46, 27, 389, DateTimeKind.Local).AddTicks(1268));

            migrationBuilder.UpdateData(
                table: "Task1",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2021, 12, 15, 4, 46, 27, 389, DateTimeKind.Local).AddTicks(1286));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Project",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2021, 12, 6, 6, 45, 53, 957, DateTimeKind.Local).AddTicks(2736));

            migrationBuilder.UpdateData(
                table: "Project",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2021, 12, 6, 6, 45, 53, 985, DateTimeKind.Local).AddTicks(5298));

            migrationBuilder.UpdateData(
                table: "Project",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2021, 12, 6, 6, 45, 53, 985, DateTimeKind.Local).AddTicks(5365));

            migrationBuilder.UpdateData(
                table: "Project",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2021, 12, 6, 6, 45, 53, 985, DateTimeKind.Local).AddTicks(5373));

            migrationBuilder.UpdateData(
                table: "Task1",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2021, 12, 6, 6, 45, 53, 986, DateTimeKind.Local).AddTicks(3559));

            migrationBuilder.UpdateData(
                table: "Task1",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2021, 12, 6, 6, 45, 53, 986, DateTimeKind.Local).AddTicks(4653));

            migrationBuilder.UpdateData(
                table: "Task1",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2021, 12, 6, 6, 45, 53, 986, DateTimeKind.Local).AddTicks(4674));
        }
    }
}
