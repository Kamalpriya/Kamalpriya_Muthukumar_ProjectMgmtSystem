using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectMgmtSystem.Migrations
{
    public partial class SeedData3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Project",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2021, 12, 6, 5, 59, 59, 770, DateTimeKind.Local).AddTicks(1628));

            migrationBuilder.UpdateData(
                table: "Project",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2021, 12, 6, 5, 59, 59, 772, DateTimeKind.Local).AddTicks(8880));

            migrationBuilder.UpdateData(
                table: "Project",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2021, 12, 6, 5, 59, 59, 772, DateTimeKind.Local).AddTicks(8924));

            migrationBuilder.UpdateData(
                table: "Project",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2021, 12, 6, 5, 59, 59, 772, DateTimeKind.Local).AddTicks(8930));

            migrationBuilder.UpdateData(
                table: "Task1",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2021, 12, 6, 5, 59, 59, 773, DateTimeKind.Local).AddTicks(6135));

            migrationBuilder.UpdateData(
                table: "Task1",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2021, 12, 6, 5, 59, 59, 775, DateTimeKind.Local).AddTicks(638));

            migrationBuilder.UpdateData(
                table: "Task1",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2021, 12, 6, 5, 59, 59, 775, DateTimeKind.Local).AddTicks(682));
        }
    }
}
