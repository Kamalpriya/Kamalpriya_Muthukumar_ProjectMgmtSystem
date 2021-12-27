using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PMS.DataAccessLayer.Migrations
{
    public partial class InitData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Detail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Task1",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    AssignedToUserId = table.Column<int>(type: "int", nullable: false),
                    Detail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Task1", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

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

            migrationBuilder.InsertData(
                table: "Project",
                columns: new[] { "Id", "CreatedOn", "Detail", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 12, 27, 6, 17, 21, 796, DateTimeKind.Local).AddTicks(2430), "This is a test project", "TestProject1" },
                    { 2, new DateTime(2021, 12, 27, 6, 17, 21, 825, DateTimeKind.Local).AddTicks(168), "This is a test project", "TestProject2" },
                    { 3, new DateTime(2021, 12, 27, 6, 17, 21, 825, DateTimeKind.Local).AddTicks(256), "This is a test project", "TestProject3" },
                    { 4, new DateTime(2021, 12, 27, 6, 17, 21, 825, DateTimeKind.Local).AddTicks(269), "This is a test project", "TestProject4" }
                });

            migrationBuilder.InsertData(
                table: "Task1",
                columns: new[] { "Id", "AssignedToUserId", "CreatedOn", "Detail", "ProjectId", "Status" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2021, 12, 27, 6, 17, 21, 826, DateTimeKind.Local).AddTicks(553), "This is a test task", 1, 2 },
                    { 2, 2, new DateTime(2021, 12, 27, 6, 17, 21, 826, DateTimeKind.Local).AddTicks(2018), "This is a test task", 1, 3 },
                    { 3, 2, new DateTime(2021, 12, 27, 6, 17, 21, 826, DateTimeKind.Local).AddTicks(2042), "This is a test task", 2, 4 }
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
                name: "Project");

            migrationBuilder.DropTable(
                name: "Task1");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "UserLogin");
        }
    }
}
