using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectMgmtSystem.Migrations
{
    public partial class SeedData2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Project",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2021, 12, 6, 5, 42, 42, 631, DateTimeKind.Local).AddTicks(8678));

            migrationBuilder.UpdateData(
                table: "Project",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2021, 12, 6, 5, 42, 42, 656, DateTimeKind.Local).AddTicks(8142));

            migrationBuilder.UpdateData(
                table: "Project",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2021, 12, 6, 5, 42, 42, 656, DateTimeKind.Local).AddTicks(8208));

            migrationBuilder.UpdateData(
                table: "Project",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2021, 12, 6, 5, 42, 42, 656, DateTimeKind.Local).AddTicks(8213));

            migrationBuilder.UpdateData(
                table: "Task1",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2021, 12, 6, 5, 42, 42, 657, DateTimeKind.Local).AddTicks(9851));

            migrationBuilder.UpdateData(
                table: "Task1",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2021, 12, 6, 5, 42, 42, 659, DateTimeKind.Local).AddTicks(2863));

            migrationBuilder.UpdateData(
                table: "Task1",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2021, 12, 6, 5, 42, 42, 659, DateTimeKind.Local).AddTicks(2914));
        }
    }
}
