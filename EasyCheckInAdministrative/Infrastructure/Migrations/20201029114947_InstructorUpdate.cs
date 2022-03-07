using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class InstructorUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Instructors",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "Instructors",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: new Guid("1a2381c9-b461-48f1-9a2e-95314ae62a73"),
                column: "Password",
                value: "$2a$11$OW/9IbNBxlLckMJh2KWBtuz7yj0OltvVKHHF9HbyLFseb1t8UbILS");

            migrationBuilder.UpdateData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: new Guid("0160e095-05d9-42bf-b5e9-89151c19ace7"),
                columns: new[] { "Password", "Role" },
                values: new object[] { "password", "Instructor" });

            migrationBuilder.UpdateData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: new Guid("144d14bd-9889-4d02-a363-55da5b8d79b6"),
                columns: new[] { "Password", "Role" },
                values: new object[] { "password", "Instructor" });

            migrationBuilder.UpdateData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: new Guid("2236ffa8-13c6-43b3-81ba-bef111319138"),
                columns: new[] { "Password", "Role" },
                values: new object[] { "password", "Instructor" });

            migrationBuilder.UpdateData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: new Guid("9b472c83-dbc1-44a3-a8c0-9a291665e528"),
                columns: new[] { "Password", "Role" },
                values: new object[] { "password", "Instructor" });

            migrationBuilder.UpdateData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: new Guid("a2c5dcdb-c5de-4d33-af22-a9867398d2c8"),
                columns: new[] { "Password", "Role" },
                values: new object[] { "password", "Instructor" });

            migrationBuilder.UpdateData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: new Guid("cf10b277-2252-40bd-aeda-332f5b8a3a5e"),
                columns: new[] { "Password", "Role" },
                values: new object[] { "password", "Instructor" });

            migrationBuilder.UpdateData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: new Guid("d5785c4f-2c01-451d-940c-1cd0d75488cc"),
                columns: new[] { "Password", "Role" },
                values: new object[] { "password", "Instructor" });

            migrationBuilder.UpdateData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: new Guid("d6a6be1a-683d-4116-b3b5-d5dbcb6c3578"),
                columns: new[] { "Password", "Role" },
                values: new object[] { "password", "Instructor" });

            migrationBuilder.UpdateData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: new Guid("e2509b15-811a-4e5d-9893-500a3b95e703"),
                columns: new[] { "Password", "Role" },
                values: new object[] { "password", "Instructor" });

            migrationBuilder.UpdateData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: new Guid("f006ad1d-efd7-44c8-b265-190944fc8293"),
                columns: new[] { "Password", "Role" },
                values: new object[] { "password", "Administrator" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "Instructors");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "Instructors");

            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: new Guid("1a2381c9-b461-48f1-9a2e-95314ae62a73"),
                column: "Password",
                value: "$2a$11$knkrzivO7Co/0vbPPmcT3.jmqx4hQLGQYnohDimvrekQkpvNi2wCm");
        }
    }
}
