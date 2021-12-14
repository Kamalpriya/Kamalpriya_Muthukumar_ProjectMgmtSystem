using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectMgmtSystem.Migrations
{
    public partial class SeedData1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserLogin",
                columns: table => new
                {
                    Username = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogin", x => x.Username);
                });

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

            migrationBuilder.InsertData(
                table: "UserLogin",
                columns: new[] { "Username", "Password" },
                values: new object[,]
                {
                    { "JohnDoe", "jd1234" },
                    { "JohnSkeet", "js5678" },
                    { "MarkSeeman", "ms1234" },
                    { "BobMartin", "bm5678" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserLogin");

            migrationBuilder.UpdateData(
                table: "Project",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2021, 12, 6, 5, 16, 15, 846, DateTimeKind.Local).AddTicks(1047));

            migrationBuilder.UpdateData(
                table: "Project",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2021, 12, 6, 5, 16, 15, 876, DateTimeKind.Local).AddTicks(4949));

            migrationBuilder.UpdateData(
                table: "Project",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2021, 12, 6, 5, 16, 15, 876, DateTimeKind.Local).AddTicks(5012));

            migrationBuilder.UpdateData(
                table: "Project",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2021, 12, 6, 5, 16, 15, 876, DateTimeKind.Local).AddTicks(5021));

            migrationBuilder.UpdateData(
                table: "Task1",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2021, 12, 6, 5, 16, 15, 877, DateTimeKind.Local).AddTicks(6459));

            migrationBuilder.UpdateData(
                table: "Task1",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2021, 12, 6, 5, 16, 15, 877, DateTimeKind.Local).AddTicks(7990));

            migrationBuilder.UpdateData(
                table: "Task1",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2021, 12, 6, 5, 16, 15, 877, DateTimeKind.Local).AddTicks(8009));
        }
    }
}
