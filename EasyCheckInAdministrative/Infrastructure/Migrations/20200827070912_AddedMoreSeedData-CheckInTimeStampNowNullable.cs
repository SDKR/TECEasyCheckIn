using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class AddedMoreSeedDataCheckInTimeStampNowNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CheckInTimeStamp",
                table: "StudentCheckIns",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset");

            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: new Guid("1a2381c9-b461-48f1-9a2e-95314ae62a73"),
                column: "Password",
                value: "$2a$11$zufAQu3z6XJfxfA/9PKinuO5T6nDT75Grz4jSccbbziqzhrUZZ8w.");

            migrationBuilder.InsertData(
                table: "StudentCheckIns",
                columns: new[] { "Id", "Attendance", "CheckInTimeStamp", "CheckOutTimeStamp", "Date", "IsCheckedIn", "StudentName" },
                values: new object[,]
                {
                    { new Guid("851155a1-3771-4e23-8259-e49c13eedf1a"), 1, new DateTimeOffset(new DateTime(2020, 8, 5, 7, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 8, 5, 15, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), new DateTime(2020, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Tessa Case" },
                    { new Guid("48b1df6d-a264-4cf2-8c6c-1bfea3f29160"), 1, new DateTimeOffset(new DateTime(2020, 8, 5, 7, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 8, 5, 15, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), new DateTime(2020, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Anastasia David" },
                    { new Guid("cef1b906-a41a-471c-9db7-62d86980656f"), 0, null, null, new DateTime(2020, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Arooj Faulkner" },
                    { new Guid("bc79e272-5489-4b9c-8963-324f3538d36c"), 1, new DateTimeOffset(new DateTime(2020, 8, 6, 7, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 8, 6, 15, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), new DateTime(2020, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Carwyn Conner" },
                    { new Guid("c1c264bd-fb76-4fe1-8607-6ae51e051bf9"), 1, new DateTimeOffset(new DateTime(2020, 8, 6, 7, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 8, 6, 15, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), new DateTime(2020, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Zackary Nicholson" },
                    { new Guid("e55a0a39-b16a-456e-8fa6-ff02482e5279"), 1, new DateTimeOffset(new DateTime(2020, 8, 6, 7, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 8, 6, 15, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), new DateTime(2020, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Tessa Case" },
                    { new Guid("c3e3825f-a9ee-43c8-8487-8ea28308b17d"), 1, new DateTimeOffset(new DateTime(2020, 8, 6, 7, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 8, 6, 15, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), new DateTime(2020, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Anastasia David" },
                    { new Guid("fc49de37-de7b-4ff7-aa79-d9f26947f364"), 0, null, null, new DateTime(2020, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Arooj Faulkner" },
                    { new Guid("354e9a9d-ec78-47ab-b799-b4d545d6ed60"), 1, new DateTimeOffset(new DateTime(2020, 8, 7, 7, 21, 34, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 8, 7, 15, 0, 35, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), new DateTime(2020, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Mikkel Hammer" },
                    { new Guid("d44e5bd3-76d0-4ca6-8b05-99f548468a95"), 1, new DateTimeOffset(new DateTime(2020, 8, 7, 7, 21, 46, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 8, 7, 15, 3, 51, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), new DateTime(2020, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Anders Ilesen" },
                    { new Guid("7f1633ab-ed9b-4c39-a0f1-f7b301c2ac80"), 1, new DateTimeOffset(new DateTime(2020, 8, 7, 7, 23, 58, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 8, 7, 15, 0, 24, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), new DateTime(2020, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Sarah Hjort" },
                    { new Guid("91da0564-8035-4049-a4aa-93280df216e7"), 1, new DateTimeOffset(new DateTime(2020, 8, 7, 7, 14, 16, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 8, 7, 15, 0, 43, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), new DateTime(2020, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Andreas Bo" },
                    { new Guid("41d0318f-14b8-4c85-9949-baf741f3ef0b"), 2, new DateTimeOffset(new DateTime(2020, 8, 6, 7, 32, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), null, new DateTime(2020, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Jens Larsen" },
                    { new Guid("9f24cea4-0798-4cfb-aa3b-daed6ed3ba92"), 1, new DateTimeOffset(new DateTime(2020, 8, 7, 7, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 8, 7, 15, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), new DateTime(2020, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Carwyn Conner" },
                    { new Guid("0c5f6fcd-474e-4227-bda8-bb48d2dc541c"), 1, new DateTimeOffset(new DateTime(2020, 8, 7, 7, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 8, 7, 15, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), new DateTime(2020, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Zackary Nicholson" },
                    { new Guid("133025f2-ad62-4d41-8da4-a17705fcb948"), 1, new DateTimeOffset(new DateTime(2020, 8, 7, 7, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 8, 7, 15, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), new DateTime(2020, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Tessa Case" },
                    { new Guid("c8c05a5e-f33c-499c-a808-7b36519cc68b"), 1, new DateTimeOffset(new DateTime(2020, 8, 7, 7, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 8, 7, 15, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), new DateTime(2020, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Anastasia David" },
                    { new Guid("61be9a77-df7e-4ab6-8991-04fb9170ffe4"), 1, new DateTimeOffset(new DateTime(2020, 8, 5, 7, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 8, 5, 15, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), new DateTime(2020, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Zackary Nicholson" },
                    { new Guid("0606babc-8121-495e-9c0c-a48f29855ca7"), 0, null, null, new DateTime(2020, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Arooj Faulkner" },
                    { new Guid("103219b1-37cc-4958-9e7a-aca262c06008"), 1, new DateTimeOffset(new DateTime(2020, 8, 5, 7, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 8, 5, 15, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), new DateTime(2020, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Carwyn Conner" },
                    { new Guid("9776b86d-7004-4fae-a06e-1acd411046b6"), 1, new DateTimeOffset(new DateTime(2020, 8, 4, 7, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 8, 4, 15, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), new DateTime(2020, 8, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Anastasia David" },
                    { new Guid("8cf206a8-d36d-4dd5-a146-010d98c7977e"), 2, new DateTimeOffset(new DateTime(2020, 8, 3, 7, 32, 54, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 8, 3, 15, 0, 51, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), new DateTime(2020, 8, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Anders Ilesen" },
                    { new Guid("5fc8a2a0-2b9a-4573-b7c9-d9e56eb5912f"), 1, new DateTimeOffset(new DateTime(2020, 8, 3, 7, 27, 15, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 8, 3, 15, 1, 24, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), new DateTime(2020, 8, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Sarah Hjort" },
                    { new Guid("7c577d19-2a2d-4ebe-ba23-d7b0bae98549"), 1, new DateTimeOffset(new DateTime(2020, 8, 3, 7, 21, 32, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 8, 3, 15, 4, 43, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), new DateTime(2020, 8, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Andreas Bo" },
                    { new Guid("73a8b40c-c8dc-4dfb-9a9e-f089f6d7fb31"), 1, new DateTimeOffset(new DateTime(2020, 8, 3, 7, 12, 43, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 8, 3, 15, 1, 14, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), new DateTime(2020, 8, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Jens Larsen" },
                    { new Guid("00d9ef65-54e2-4aee-975c-5f7b87f492a2"), 1, new DateTimeOffset(new DateTime(2020, 8, 3, 7, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 8, 3, 15, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), new DateTime(2020, 8, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Carwyn Conner" },
                    { new Guid("f46f452f-efa3-4760-a76b-c0f426a71500"), 1, new DateTimeOffset(new DateTime(2020, 8, 3, 7, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 8, 3, 15, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), new DateTime(2020, 8, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Zackary Nicholson" },
                    { new Guid("7ad34d78-de3c-48ee-8688-1b4eb384fdbe"), 1, new DateTimeOffset(new DateTime(2020, 8, 3, 7, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 8, 3, 15, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), new DateTime(2020, 8, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Tessa Case" },
                    { new Guid("9ad2371f-c094-465b-ab96-087238813014"), 1, new DateTimeOffset(new DateTime(2020, 8, 3, 7, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 8, 3, 15, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), new DateTime(2020, 8, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Anastasia David" },
                    { new Guid("04c2068c-020c-4eab-ba1f-89470aa3a197"), 0, null, null, new DateTime(2020, 8, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Arooj Faulkner" },
                    { new Guid("8fe2929b-d53f-43d1-97ee-7202322bf18e"), 1, new DateTimeOffset(new DateTime(2020, 8, 4, 7, 25, 54, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 8, 4, 15, 2, 32, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), new DateTime(2020, 8, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Mikkel Hammer" },
                    { new Guid("289dd8a1-bc76-4481-8e25-fc877aace43a"), 2, new DateTimeOffset(new DateTime(2020, 8, 4, 7, 32, 54, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 8, 4, 15, 0, 51, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), new DateTime(2020, 8, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Anders Ilesen" },
                    { new Guid("358bf0f1-59ce-45b3-994b-ebd071b7e42f"), 1, new DateTimeOffset(new DateTime(2020, 8, 4, 7, 27, 15, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 8, 4, 15, 1, 24, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), new DateTime(2020, 8, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Sarah Hjort" },
                    { new Guid("3c12db1f-dd96-4bbf-8635-ebe77b77c388"), 1, new DateTimeOffset(new DateTime(2020, 8, 4, 7, 21, 32, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 8, 4, 15, 4, 43, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), new DateTime(2020, 8, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Andreas Bo" },
                    { new Guid("013e0fc8-dc6d-40cd-bbca-4d402ff9e7df"), 1, new DateTimeOffset(new DateTime(2020, 8, 4, 7, 12, 43, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 8, 4, 15, 1, 14, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), new DateTime(2020, 8, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Jens Larsen" },
                    { new Guid("c363016b-88c5-431b-a574-8b25f1ddf413"), 1, new DateTimeOffset(new DateTime(2020, 8, 4, 7, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 8, 4, 15, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), new DateTime(2020, 8, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Carwyn Conner" },
                    { new Guid("5523bb7b-4777-4126-aa94-637709fdefff"), 1, new DateTimeOffset(new DateTime(2020, 8, 4, 7, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 8, 4, 15, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), new DateTime(2020, 8, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Zackary Nicholson" },
                    { new Guid("0b89074b-90b1-4f6a-83d6-79fdf4044691"), 1, new DateTimeOffset(new DateTime(2020, 8, 4, 7, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 8, 4, 15, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), new DateTime(2020, 8, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Tessa Case" },
                    { new Guid("a799fd60-3402-47a4-b342-42c2b3c96924"), 0, null, null, new DateTime(2020, 8, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Arooj Faulkner" },
                    { new Guid("e6c99985-b59e-407d-ad6c-746deb0d2b32"), 1, new DateTimeOffset(new DateTime(2020, 8, 3, 7, 25, 54, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 8, 3, 15, 2, 32, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), new DateTime(2020, 8, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Mikkel Hammer" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "StudentCheckIns",
                keyColumn: "Id",
                keyValue: new Guid("00d9ef65-54e2-4aee-975c-5f7b87f492a2"));

            migrationBuilder.DeleteData(
                table: "StudentCheckIns",
                keyColumn: "Id",
                keyValue: new Guid("013e0fc8-dc6d-40cd-bbca-4d402ff9e7df"));

            migrationBuilder.DeleteData(
                table: "StudentCheckIns",
                keyColumn: "Id",
                keyValue: new Guid("04c2068c-020c-4eab-ba1f-89470aa3a197"));

            migrationBuilder.DeleteData(
                table: "StudentCheckIns",
                keyColumn: "Id",
                keyValue: new Guid("0606babc-8121-495e-9c0c-a48f29855ca7"));

            migrationBuilder.DeleteData(
                table: "StudentCheckIns",
                keyColumn: "Id",
                keyValue: new Guid("0b89074b-90b1-4f6a-83d6-79fdf4044691"));

            migrationBuilder.DeleteData(
                table: "StudentCheckIns",
                keyColumn: "Id",
                keyValue: new Guid("0c5f6fcd-474e-4227-bda8-bb48d2dc541c"));

            migrationBuilder.DeleteData(
                table: "StudentCheckIns",
                keyColumn: "Id",
                keyValue: new Guid("103219b1-37cc-4958-9e7a-aca262c06008"));

            migrationBuilder.DeleteData(
                table: "StudentCheckIns",
                keyColumn: "Id",
                keyValue: new Guid("133025f2-ad62-4d41-8da4-a17705fcb948"));

            migrationBuilder.DeleteData(
                table: "StudentCheckIns",
                keyColumn: "Id",
                keyValue: new Guid("289dd8a1-bc76-4481-8e25-fc877aace43a"));

            migrationBuilder.DeleteData(
                table: "StudentCheckIns",
                keyColumn: "Id",
                keyValue: new Guid("354e9a9d-ec78-47ab-b799-b4d545d6ed60"));

            migrationBuilder.DeleteData(
                table: "StudentCheckIns",
                keyColumn: "Id",
                keyValue: new Guid("358bf0f1-59ce-45b3-994b-ebd071b7e42f"));

            migrationBuilder.DeleteData(
                table: "StudentCheckIns",
                keyColumn: "Id",
                keyValue: new Guid("3c12db1f-dd96-4bbf-8635-ebe77b77c388"));

            migrationBuilder.DeleteData(
                table: "StudentCheckIns",
                keyColumn: "Id",
                keyValue: new Guid("41d0318f-14b8-4c85-9949-baf741f3ef0b"));

            migrationBuilder.DeleteData(
                table: "StudentCheckIns",
                keyColumn: "Id",
                keyValue: new Guid("48b1df6d-a264-4cf2-8c6c-1bfea3f29160"));

            migrationBuilder.DeleteData(
                table: "StudentCheckIns",
                keyColumn: "Id",
                keyValue: new Guid("5523bb7b-4777-4126-aa94-637709fdefff"));

            migrationBuilder.DeleteData(
                table: "StudentCheckIns",
                keyColumn: "Id",
                keyValue: new Guid("5fc8a2a0-2b9a-4573-b7c9-d9e56eb5912f"));

            migrationBuilder.DeleteData(
                table: "StudentCheckIns",
                keyColumn: "Id",
                keyValue: new Guid("61be9a77-df7e-4ab6-8991-04fb9170ffe4"));

            migrationBuilder.DeleteData(
                table: "StudentCheckIns",
                keyColumn: "Id",
                keyValue: new Guid("73a8b40c-c8dc-4dfb-9a9e-f089f6d7fb31"));

            migrationBuilder.DeleteData(
                table: "StudentCheckIns",
                keyColumn: "Id",
                keyValue: new Guid("7ad34d78-de3c-48ee-8688-1b4eb384fdbe"));

            migrationBuilder.DeleteData(
                table: "StudentCheckIns",
                keyColumn: "Id",
                keyValue: new Guid("7c577d19-2a2d-4ebe-ba23-d7b0bae98549"));

            migrationBuilder.DeleteData(
                table: "StudentCheckIns",
                keyColumn: "Id",
                keyValue: new Guid("7f1633ab-ed9b-4c39-a0f1-f7b301c2ac80"));

            migrationBuilder.DeleteData(
                table: "StudentCheckIns",
                keyColumn: "Id",
                keyValue: new Guid("851155a1-3771-4e23-8259-e49c13eedf1a"));

            migrationBuilder.DeleteData(
                table: "StudentCheckIns",
                keyColumn: "Id",
                keyValue: new Guid("8cf206a8-d36d-4dd5-a146-010d98c7977e"));

            migrationBuilder.DeleteData(
                table: "StudentCheckIns",
                keyColumn: "Id",
                keyValue: new Guid("8fe2929b-d53f-43d1-97ee-7202322bf18e"));

            migrationBuilder.DeleteData(
                table: "StudentCheckIns",
                keyColumn: "Id",
                keyValue: new Guid("91da0564-8035-4049-a4aa-93280df216e7"));

            migrationBuilder.DeleteData(
                table: "StudentCheckIns",
                keyColumn: "Id",
                keyValue: new Guid("9776b86d-7004-4fae-a06e-1acd411046b6"));

            migrationBuilder.DeleteData(
                table: "StudentCheckIns",
                keyColumn: "Id",
                keyValue: new Guid("9ad2371f-c094-465b-ab96-087238813014"));

            migrationBuilder.DeleteData(
                table: "StudentCheckIns",
                keyColumn: "Id",
                keyValue: new Guid("9f24cea4-0798-4cfb-aa3b-daed6ed3ba92"));

            migrationBuilder.DeleteData(
                table: "StudentCheckIns",
                keyColumn: "Id",
                keyValue: new Guid("a799fd60-3402-47a4-b342-42c2b3c96924"));

            migrationBuilder.DeleteData(
                table: "StudentCheckIns",
                keyColumn: "Id",
                keyValue: new Guid("bc79e272-5489-4b9c-8963-324f3538d36c"));

            migrationBuilder.DeleteData(
                table: "StudentCheckIns",
                keyColumn: "Id",
                keyValue: new Guid("c1c264bd-fb76-4fe1-8607-6ae51e051bf9"));

            migrationBuilder.DeleteData(
                table: "StudentCheckIns",
                keyColumn: "Id",
                keyValue: new Guid("c363016b-88c5-431b-a574-8b25f1ddf413"));

            migrationBuilder.DeleteData(
                table: "StudentCheckIns",
                keyColumn: "Id",
                keyValue: new Guid("c3e3825f-a9ee-43c8-8487-8ea28308b17d"));

            migrationBuilder.DeleteData(
                table: "StudentCheckIns",
                keyColumn: "Id",
                keyValue: new Guid("c8c05a5e-f33c-499c-a808-7b36519cc68b"));

            migrationBuilder.DeleteData(
                table: "StudentCheckIns",
                keyColumn: "Id",
                keyValue: new Guid("cef1b906-a41a-471c-9db7-62d86980656f"));

            migrationBuilder.DeleteData(
                table: "StudentCheckIns",
                keyColumn: "Id",
                keyValue: new Guid("d44e5bd3-76d0-4ca6-8b05-99f548468a95"));

            migrationBuilder.DeleteData(
                table: "StudentCheckIns",
                keyColumn: "Id",
                keyValue: new Guid("e55a0a39-b16a-456e-8fa6-ff02482e5279"));

            migrationBuilder.DeleteData(
                table: "StudentCheckIns",
                keyColumn: "Id",
                keyValue: new Guid("e6c99985-b59e-407d-ad6c-746deb0d2b32"));

            migrationBuilder.DeleteData(
                table: "StudentCheckIns",
                keyColumn: "Id",
                keyValue: new Guid("f46f452f-efa3-4760-a76b-c0f426a71500"));

            migrationBuilder.DeleteData(
                table: "StudentCheckIns",
                keyColumn: "Id",
                keyValue: new Guid("fc49de37-de7b-4ff7-aa79-d9f26947f364"));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CheckInTimeStamp",
                table: "StudentCheckIns",
                type: "datetimeoffset",
                nullable: false,
                oldClrType: typeof(DateTimeOffset),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: new Guid("1a2381c9-b461-48f1-9a2e-95314ae62a73"),
                column: "Password",
                value: "$2a$11$iB9BuVW9sVMEDpFVLgk2guGt6/z5Yr5B1Nfl/3fgJtKIvPCvn487W");
        }
    }
}
