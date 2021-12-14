using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectMgmtSystem.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Project",
                columns: new[] { "Id", "CreatedOn", "Detail", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 12, 6, 5, 16, 15, 846, DateTimeKind.Local).AddTicks(1047), "This is a test project", "TestProject1" },
                    { 2, new DateTime(2021, 12, 6, 5, 16, 15, 876, DateTimeKind.Local).AddTicks(4949), "This is a test project", "TestProject2" },
                    { 3, new DateTime(2021, 12, 6, 5, 16, 15, 876, DateTimeKind.Local).AddTicks(5012), "This is a test project", "TestProject3" },
                    { 4, new DateTime(2021, 12, 6, 5, 16, 15, 876, DateTimeKind.Local).AddTicks(5021), "This is a test project", "TestProject4" }
                });

            migrationBuilder.InsertData(
                table: "Task1",
                columns: new[] { "Id", "AssignedToUserId", "CreatedOn", "Detail", "ProjectId", "Status" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2021, 12, 6, 5, 16, 15, 877, DateTimeKind.Local).AddTicks(6459), "This is a test task", 1, 2 },
                    { 2, 2, new DateTime(2021, 12, 6, 5, 16, 15, 877, DateTimeKind.Local).AddTicks(7990), "This is a test task", 1, 3 },
                    { 3, 2, new DateTime(2021, 12, 6, 5, 16, 15, 877, DateTimeKind.Local).AddTicks(8009), "This is a test task", 2, 4 }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "Password" },
                values: new object[,]
                {
                    { 1, "john.doe@test.com", "John", "Doe", "jd1234" },
                    { 2, "john.skeet@test.com", "John", "Skeet", "js5678" },
                    { 3, "mark.seeman@test.com", "Mark", "Seeman", "ms1234" },
                    { 4, "bob.martin@test.com", "Bob", "Martin", "bm5678" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Project",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Project",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Project",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Project",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Task1",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Task1",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Task1",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
