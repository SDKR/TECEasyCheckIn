using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class AddingStudentDataWithCheckIns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "StudentId",
                table: "StudentCheckIns",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Department = table.Column<int>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    StatusComment = table.Column<string>(nullable: true),
                    CardName = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTimeOffset>(nullable: true),
                    DeletedById = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_Admins_DeletedById",
                        column: x => x.DeletedById,
                        principalTable: "Admins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: new Guid("1a2381c9-b461-48f1-9a2e-95314ae62a73"),
                column: "Password",
                value: "$2a$11$aU6Lf8/cchq6pUi2Fmb6XuGQvB1qbcYNJwbSwg9sbxFXoZK3eCI8m");

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "CardName", "DeletedById", "DeletedOn", "Department", "FirstName", "IsDeleted", "LastName", "Status", "StatusComment" },
                values: new object[,]
                {
                    { new Guid("ae0cb609-04c9-494b-b4cc-a0108be8d3dc"), null, null, null, null, "Mikkel", false, "Hammer", 0, null },
                    { new Guid("33e425d4-7ab4-4d0e-9c8f-c69d7a56baa6"), null, null, null, null, "Anders", false, "Ilesen", 1, null },
                    { new Guid("e95f208d-2f31-4796-a2a0-64f2fe5c7c97"), null, null, null, null, "Lars", true, "Larsen", 0, null }
                });

            migrationBuilder.InsertData(
                table: "StudentCheckIns",
                columns: new[] { "Id", "Attendance", "CheckInTimeStamp", "CheckOutTimeStamp", "Date", "IsCheckedIn", "StudentId", "StudentName" },
                values: new object[,]
                {
                    { new Guid("0669b168-aada-4e2e-a814-b92f992a3041"), 1, new DateTimeOffset(new DateTime(2020, 8, 3, 7, 23, 51, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 8, 3, 15, 5, 35, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), new DateTime(2020, 8, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new Guid("ae0cb609-04c9-494b-b4cc-a0108be8d3dc"), "Mikkel Hammer" },
                    { new Guid("da1a4904-19f7-47bb-85a0-8893f26237cf"), 1, new DateTimeOffset(new DateTime(2020, 8, 4, 7, 26, 32, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 8, 4, 15, 1, 47, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), new DateTime(2020, 8, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new Guid("ae0cb609-04c9-494b-b4cc-a0108be8d3dc"), "Mikkel Hammer" },
                    { new Guid("53719f18-952a-4795-9069-546b535b2472"), 1, new DateTimeOffset(new DateTime(2020, 8, 5, 7, 21, 23, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 8, 5, 15, 3, 21, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), new DateTime(2020, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new Guid("ae0cb609-04c9-494b-b4cc-a0108be8d3dc"), "Mikkel Hammer" },
                    { new Guid("ee0d79f8-b3db-4af8-aa0b-3cdc55cca039"), 1, new DateTimeOffset(new DateTime(2020, 8, 3, 7, 23, 51, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 8, 3, 15, 5, 35, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), new DateTime(2020, 8, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new Guid("33e425d4-7ab4-4d0e-9c8f-c69d7a56baa6"), "Anders Ilesen" },
                    { new Guid("0cfc589f-6340-41c4-a826-24283d656227"), 1, new DateTimeOffset(new DateTime(2020, 8, 4, 7, 26, 32, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 8, 4, 15, 1, 47, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), new DateTime(2020, 8, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new Guid("33e425d4-7ab4-4d0e-9c8f-c69d7a56baa6"), "Anders Ilesen" },
                    { new Guid("5f99d0e6-f71b-4ec3-8973-7ebd113b03a4"), 1, new DateTimeOffset(new DateTime(2020, 8, 5, 7, 21, 23, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 8, 5, 15, 3, 21, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), new DateTime(2020, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new Guid("33e425d4-7ab4-4d0e-9c8f-c69d7a56baa6"), "Anders Ilesen" },
                    { new Guid("22530fbd-569a-492c-be29-99b55858d421"), 1, new DateTimeOffset(new DateTime(2020, 8, 3, 7, 23, 51, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 8, 3, 15, 5, 35, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), new DateTime(2020, 8, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new Guid("e95f208d-2f31-4796-a2a0-64f2fe5c7c97"), "Lars Larsen" },
                    { new Guid("f03141fd-ef0e-46d6-8adb-d25182b56f6a"), 1, new DateTimeOffset(new DateTime(2020, 8, 4, 7, 26, 32, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 8, 4, 15, 1, 47, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), new DateTime(2020, 8, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new Guid("e95f208d-2f31-4796-a2a0-64f2fe5c7c97"), "Lars Larsen" },
                    { new Guid("1a128961-d3cc-490a-b0e3-c45171afeb27"), 1, new DateTimeOffset(new DateTime(2020, 8, 5, 7, 21, 23, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 8, 5, 15, 3, 21, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), new DateTime(2020, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new Guid("e95f208d-2f31-4796-a2a0-64f2fe5c7c97"), "Lars Larsen" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentCheckIns_StudentId",
                table: "StudentCheckIns",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_DeletedById",
                table: "Students",
                column: "DeletedById");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentCheckIns_Students_StudentId",
                table: "StudentCheckIns",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentCheckIns_Students_StudentId",
                table: "StudentCheckIns");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropIndex(
                name: "IX_StudentCheckIns_StudentId",
                table: "StudentCheckIns");

            migrationBuilder.DeleteData(
                table: "StudentCheckIns",
                keyColumn: "Id",
                keyValue: new Guid("0669b168-aada-4e2e-a814-b92f992a3041"));

            migrationBuilder.DeleteData(
                table: "StudentCheckIns",
                keyColumn: "Id",
                keyValue: new Guid("0cfc589f-6340-41c4-a826-24283d656227"));

            migrationBuilder.DeleteData(
                table: "StudentCheckIns",
                keyColumn: "Id",
                keyValue: new Guid("1a128961-d3cc-490a-b0e3-c45171afeb27"));

            migrationBuilder.DeleteData(
                table: "StudentCheckIns",
                keyColumn: "Id",
                keyValue: new Guid("22530fbd-569a-492c-be29-99b55858d421"));

            migrationBuilder.DeleteData(
                table: "StudentCheckIns",
                keyColumn: "Id",
                keyValue: new Guid("53719f18-952a-4795-9069-546b535b2472"));

            migrationBuilder.DeleteData(
                table: "StudentCheckIns",
                keyColumn: "Id",
                keyValue: new Guid("5f99d0e6-f71b-4ec3-8973-7ebd113b03a4"));

            migrationBuilder.DeleteData(
                table: "StudentCheckIns",
                keyColumn: "Id",
                keyValue: new Guid("da1a4904-19f7-47bb-85a0-8893f26237cf"));

            migrationBuilder.DeleteData(
                table: "StudentCheckIns",
                keyColumn: "Id",
                keyValue: new Guid("ee0d79f8-b3db-4af8-aa0b-3cdc55cca039"));

            migrationBuilder.DeleteData(
                table: "StudentCheckIns",
                keyColumn: "Id",
                keyValue: new Guid("f03141fd-ef0e-46d6-8adb-d25182b56f6a"));

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "StudentCheckIns");

            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: new Guid("1a2381c9-b461-48f1-9a2e-95314ae62a73"),
                column: "Password",
                value: "$2a$11$VcF9zTtJajq4Mmi.pp3mqejEtWWoKX5ptkRNvIIzOVOba3sbc.bvO");
        }
    }
}
