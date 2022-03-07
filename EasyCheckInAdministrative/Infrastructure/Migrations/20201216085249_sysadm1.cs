using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class sysadm1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: new Guid("1a2381c9-b461-48f1-9a2e-95314ae62a73"),
                column: "Password",
                value: "$2a$11$1jbpmK3uDXBcQy42tVM8xuHCfFfQlb6lWY7gP0jDQKDdKGmff8ruW");

            migrationBuilder.UpdateData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: new Guid("144d14bd-9889-4d02-a363-55da5b8d1432"),
                columns: new[] { "Initials", "Role" },
                values: new object[] { "sysadm", "SystemAdministrator" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: new Guid("1a2381c9-b461-48f1-9a2e-95314ae62a73"),
                column: "Password",
                value: "$2a$11$qtxp39ovaLJJ4avzkkFaXuh8NRdDsbXFumow5pIORiKlbdGyqi/w6");

            migrationBuilder.UpdateData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: new Guid("144d14bd-9889-4d02-a363-55da5b8d1432"),
                columns: new[] { "Initials", "Role" },
                values: new object[] { "Ingen", "Instructor" });
        }
    }
}
