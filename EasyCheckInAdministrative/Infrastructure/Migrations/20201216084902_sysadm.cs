using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class sysadm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: new Guid("1a2381c9-b461-48f1-9a2e-95314ae62a73"),
                column: "Password",
                value: "$2a$11$qtxp39ovaLJJ4avzkkFaXuh8NRdDsbXFumow5pIORiKlbdGyqi/w6");

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("d3098d42-f0ba-47a1-a3b3-b33ca5b5b0a1"), "SystemAdministrator" });

            migrationBuilder.InsertData(
                table: "Instructors",
                columns: new[] { "Id", "DepartmentId", "Initials", "Password", "Role" },
                values: new object[] { new Guid("144d14bd-9889-4d02-a363-55da5b8d1432"), new Guid("d3098d42-f0ba-47a1-a3b3-b33ca5b5b0a1"), "Ingen", "password", "Instructor" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: new Guid("144d14bd-9889-4d02-a363-55da5b8d1432"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("d3098d42-f0ba-47a1-a3b3-b33ca5b5b0a1"));

            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: new Guid("1a2381c9-b461-48f1-9a2e-95314ae62a73"),
                column: "Password",
                value: "$2a$11$OW/9IbNBxlLckMJh2KWBtuz7yj0OltvVKHHF9HbyLFseb1t8UbILS");
        }
    }
}
