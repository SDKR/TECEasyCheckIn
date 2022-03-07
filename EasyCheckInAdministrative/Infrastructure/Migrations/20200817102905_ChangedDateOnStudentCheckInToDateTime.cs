using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class ChangedDateOnStudentCheckInToDateTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "StudentCheckIns",
                nullable: false,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset");

            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: new Guid("1a2381c9-b461-48f1-9a2e-95314ae62a73"),
                column: "Password",
                value: "$2a$11$iB9BuVW9sVMEDpFVLgk2guGt6/z5Yr5B1Nfl/3fgJtKIvPCvn487W");

            migrationBuilder.UpdateData(
                table: "StudentCheckIns",
                keyColumn: "Id",
                keyValue: new Guid("0fab1c5d-8e6c-4b64-b457-9751ea483688"),
                column: "Date",
                value: new DateTime(2020, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "StudentCheckIns",
                keyColumn: "Id",
                keyValue: new Guid("45cd8530-ec55-44ff-a28e-ada3dd8a2398"),
                column: "Date",
                value: new DateTime(2020, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "StudentCheckIns",
                keyColumn: "Id",
                keyValue: new Guid("5176b586-f03a-49df-af27-8f3ebb650328"),
                column: "Date",
                value: new DateTime(2020, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "StudentCheckIns",
                keyColumn: "Id",
                keyValue: new Guid("9c9aa717-46ff-4a69-af1c-dbb062bc4765"),
                column: "Date",
                value: new DateTime(2020, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "StudentCheckIns",
                keyColumn: "Id",
                keyValue: new Guid("a8387616-dd1c-4406-8c77-6d82ec3d1716"),
                column: "Date",
                value: new DateTime(2020, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "StudentCheckIns",
                keyColumn: "Id",
                keyValue: new Guid("ac69a97d-d0af-41a9-8c5c-874c7fcf7a5e"),
                column: "Date",
                value: new DateTime(2020, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "StudentCheckIns",
                keyColumn: "Id",
                keyValue: new Guid("af0f579c-14e7-45bb-98d2-d65246902acb"),
                column: "Date",
                value: new DateTime(2020, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "StudentCheckIns",
                keyColumn: "Id",
                keyValue: new Guid("b2db7a65-a6b5-4c79-be60-b87eaae453e6"),
                column: "Date",
                value: new DateTime(2020, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "StudentCheckIns",
                keyColumn: "Id",
                keyValue: new Guid("c0f4025a-a33c-4537-ab05-63e4323a2a0d"),
                column: "Date",
                value: new DateTime(2020, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "StudentCheckIns",
                keyColumn: "Id",
                keyValue: new Guid("c52c87c8-2b19-496f-b0fe-cc1d815b666f"),
                column: "Date",
                value: new DateTime(2020, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "Date",
                table: "StudentCheckIns",
                type: "datetimeoffset",
                nullable: false,
                oldClrType: typeof(DateTime));

            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: new Guid("1a2381c9-b461-48f1-9a2e-95314ae62a73"),
                column: "Password",
                value: "$2a$11$eqtqOKJBovfQAox5x87ZQeuEX74ZI5tLNmrTE9/PnCMFUkoUAvOsy");

            migrationBuilder.UpdateData(
                table: "StudentCheckIns",
                keyColumn: "Id",
                keyValue: new Guid("0fab1c5d-8e6c-4b64-b457-9751ea483688"),
                column: "Date",
                value: new DateTimeOffset(new DateTime(2020, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "StudentCheckIns",
                keyColumn: "Id",
                keyValue: new Guid("45cd8530-ec55-44ff-a28e-ada3dd8a2398"),
                column: "Date",
                value: new DateTimeOffset(new DateTime(2020, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "StudentCheckIns",
                keyColumn: "Id",
                keyValue: new Guid("5176b586-f03a-49df-af27-8f3ebb650328"),
                column: "Date",
                value: new DateTimeOffset(new DateTime(2020, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "StudentCheckIns",
                keyColumn: "Id",
                keyValue: new Guid("9c9aa717-46ff-4a69-af1c-dbb062bc4765"),
                column: "Date",
                value: new DateTimeOffset(new DateTime(2020, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "StudentCheckIns",
                keyColumn: "Id",
                keyValue: new Guid("a8387616-dd1c-4406-8c77-6d82ec3d1716"),
                column: "Date",
                value: new DateTimeOffset(new DateTime(2020, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "StudentCheckIns",
                keyColumn: "Id",
                keyValue: new Guid("ac69a97d-d0af-41a9-8c5c-874c7fcf7a5e"),
                column: "Date",
                value: new DateTimeOffset(new DateTime(2020, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "StudentCheckIns",
                keyColumn: "Id",
                keyValue: new Guid("af0f579c-14e7-45bb-98d2-d65246902acb"),
                column: "Date",
                value: new DateTimeOffset(new DateTime(2020, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "StudentCheckIns",
                keyColumn: "Id",
                keyValue: new Guid("b2db7a65-a6b5-4c79-be60-b87eaae453e6"),
                column: "Date",
                value: new DateTimeOffset(new DateTime(2020, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "StudentCheckIns",
                keyColumn: "Id",
                keyValue: new Guid("c0f4025a-a33c-4537-ab05-63e4323a2a0d"),
                column: "Date",
                value: new DateTimeOffset(new DateTime(2020, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "StudentCheckIns",
                keyColumn: "Id",
                keyValue: new Guid("c52c87c8-2b19-496f-b0fe-cc1d815b666f"),
                column: "Date",
                value: new DateTimeOffset(new DateTime(2020, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)));
        }
    }
}
