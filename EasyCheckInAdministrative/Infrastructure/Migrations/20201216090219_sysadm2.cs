using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class sysadm2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: new Guid("1a2381c9-b461-48f1-9a2e-95314ae62a73"),
                column: "Password",
                value: "$2a$11$LYnadj.DqH8/Z63rr4jGNucWnDoo0veiD.JQIZRlmqbhe2im/0v9S");

            migrationBuilder.UpdateData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: new Guid("2236ffa8-13c6-43b3-81ba-bef111319138"),
                column: "Initials",
                value: "Insx2");

            migrationBuilder.UpdateData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: new Guid("d6a6be1a-683d-4116-b3b5-d5dbcb6c3578"),
                column: "Initials",
                value: "Insx1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                keyValue: new Guid("2236ffa8-13c6-43b3-81ba-bef111319138"),
                column: "Initials",
                value: "Ins2");

            migrationBuilder.UpdateData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: new Guid("d6a6be1a-683d-4116-b3b5-d5dbcb6c3578"),
                column: "Initials",
                value: "Ins1");
        }
    }
}
