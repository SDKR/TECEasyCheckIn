using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class AddedSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DailySettings",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Date = table.Column<DateTimeOffset>(nullable: false),
                    LastestCheckInTimeStamp = table.Column<DateTimeOffset>(nullable: false),
                    EarliestCheckOutTimeStamp = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailySettings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GeneralSettings",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    TimeToKeepData = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneralSettings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StudentCheckIns",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    StudentName = table.Column<string>(nullable: true),
                    Date = table.Column<DateTimeOffset>(nullable: false),
                    CheckInTimeStamp = table.Column<DateTimeOffset>(nullable: false),
                    CheckOutTimeStamp = table.Column<DateTimeOffset>(nullable: true),
                    IsCheckedIn = table.Column<bool>(nullable: false),
                    Attendance = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentCheckIns", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "StudentCheckIns",
                columns: new[] { "Id", "Attendance", "CheckInTimeStamp", "CheckOutTimeStamp", "Date", "IsCheckedIn", "StudentName" },
                values: new object[,]
                {
                    { new Guid("c0f4025a-a33c-4537-ab05-63e4323a2a0d"), 1, new DateTimeOffset(new DateTime(2020, 8, 5, 7, 25, 54, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 8, 5, 15, 2, 32, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), true, "Mikkel Hammer" },
                    { new Guid("45cd8530-ec55-44ff-a28e-ada3dd8a2398"), 2, new DateTimeOffset(new DateTime(2020, 8, 5, 7, 32, 54, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 8, 5, 15, 0, 51, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), true, "Anders Ilesen" },
                    { new Guid("b2db7a65-a6b5-4c79-be60-b87eaae453e6"), 1, new DateTimeOffset(new DateTime(2020, 8, 5, 7, 27, 15, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 8, 5, 15, 1, 24, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), true, "Sarah Hjort" },
                    { new Guid("9c9aa717-46ff-4a69-af1c-dbb062bc4765"), 1, new DateTimeOffset(new DateTime(2020, 8, 5, 7, 21, 32, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 8, 5, 15, 4, 43, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), true, "Andreas Bo" },
                    { new Guid("5176b586-f03a-49df-af27-8f3ebb650328"), 1, new DateTimeOffset(new DateTime(2020, 8, 5, 7, 12, 43, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 8, 5, 15, 1, 14, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), true, "Jens Larsen" },
                    { new Guid("ac69a97d-d0af-41a9-8c5c-874c7fcf7a5e"), 1, new DateTimeOffset(new DateTime(2020, 8, 6, 7, 21, 34, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 8, 6, 15, 0, 35, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), true, "Mikkel Hammer" },
                    { new Guid("c52c87c8-2b19-496f-b0fe-cc1d815b666f"), 1, new DateTimeOffset(new DateTime(2020, 8, 6, 7, 21, 46, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 8, 6, 15, 3, 51, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), true, "Anders Ilesen" },
                    { new Guid("a8387616-dd1c-4406-8c77-6d82ec3d1716"), 1, new DateTimeOffset(new DateTime(2020, 8, 6, 7, 23, 58, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 8, 6, 15, 0, 24, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), true, "Sarah Hjort" },
                    { new Guid("0fab1c5d-8e6c-4b64-b457-9751ea483688"), 1, new DateTimeOffset(new DateTime(2020, 8, 6, 7, 14, 16, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 8, 6, 15, 0, 43, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), true, "Andreas Bo" },
                    { new Guid("af0f579c-14e7-45bb-98d2-d65246902acb"), 2, new DateTimeOffset(new DateTime(2020, 8, 6, 7, 32, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), null, new DateTimeOffset(new DateTime(2020, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), true, "Jens Larsen" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DailySettings");

            migrationBuilder.DropTable(
                name: "GeneralSettings");

            migrationBuilder.DropTable(
                name: "StudentCheckIns");
        }
    }
}
