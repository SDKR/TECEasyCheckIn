using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class AddedDefaultDailySettingsSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "DailySettings",
                nullable: false,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset");

            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: new Guid("1a2381c9-b461-48f1-9a2e-95314ae62a73"),
                column: "Password",
                value: "$2a$11$VcF9zTtJajq4Mmi.pp3mqejEtWWoKX5ptkRNvIIzOVOba3sbc.bvO");

            migrationBuilder.InsertData(
                table: "DailySettings",
                columns: new[] { "Id", "Date", "EarliestCheckOutTimeStamp", "LastestCheckInTimeStamp" },
                values: new object[,]
                {
                    { new Guid("0425fbed-f097-4267-8f66-97070c305098"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTimeOffset(new DateTime(1, 1, 1, 15, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 7, 30, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)) },
                    { new Guid("be02754d-d2a4-4f70-bd0f-358b826ee35c"), new DateTime(1, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTimeOffset(new DateTime(1, 1, 2, 15, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 2, 7, 30, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)) },
                    { new Guid("f3beefe7-ea96-429c-b2ce-b5df60b6a489"), new DateTime(1, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTimeOffset(new DateTime(1, 1, 3, 15, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 3, 7, 30, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)) },
                    { new Guid("bc195ee1-8966-41f3-b54d-b84cd624c5c6"), new DateTime(1, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTimeOffset(new DateTime(1, 1, 4, 15, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 4, 7, 30, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)) },
                    { new Guid("ba878476-7300-460b-b6d3-0bcc21e2fc3e"), new DateTime(1, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTimeOffset(new DateTime(1, 1, 5, 14, 30, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 5, 7, 30, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DailySettings",
                keyColumn: "Id",
                keyValue: new Guid("0425fbed-f097-4267-8f66-97070c305098"));

            migrationBuilder.DeleteData(
                table: "DailySettings",
                keyColumn: "Id",
                keyValue: new Guid("ba878476-7300-460b-b6d3-0bcc21e2fc3e"));

            migrationBuilder.DeleteData(
                table: "DailySettings",
                keyColumn: "Id",
                keyValue: new Guid("bc195ee1-8966-41f3-b54d-b84cd624c5c6"));

            migrationBuilder.DeleteData(
                table: "DailySettings",
                keyColumn: "Id",
                keyValue: new Guid("be02754d-d2a4-4f70-bd0f-358b826ee35c"));

            migrationBuilder.DeleteData(
                table: "DailySettings",
                keyColumn: "Id",
                keyValue: new Guid("f3beefe7-ea96-429c-b2ce-b5df60b6a489"));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "Date",
                table: "DailySettings",
                type: "datetimeoffset",
                nullable: false,
                oldClrType: typeof(DateTime));

            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: new Guid("1a2381c9-b461-48f1-9a2e-95314ae62a73"),
                column: "Password",
                value: "$2a$11$zufAQu3z6XJfxfA/9PKinuO5T6nDT75Grz4jSccbbziqzhrUZZ8w.");
        }
    }
}
