using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class AddedDepAndInsWithSeedD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentCheckIns_Students_StudentId",
                table: "StudentCheckIns");

            migrationBuilder.DropColumn(
                name: "Department",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Instructor",
                table: "Students");

            migrationBuilder.AddColumn<Guid>(
                name: "DepartmentId",
                table: "Students",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "InstructorId",
                table: "Students",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<Guid>(
                name: "StudentId",
                table: "StudentCheckIns",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DepartmentId",
                table: "DailySettings",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Instructors",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Initials = table.Column<string>(nullable: true),
                    DepartmentId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instructors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Instructors_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: new Guid("1a2381c9-b461-48f1-9a2e-95314ae62a73"),
                column: "Password",
                value: "$2a$11$knkrzivO7Co/0vbPPmcT3.jmqx4hQLGQYnohDimvrekQkpvNi2wCm");

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("d3098d42-f0ba-47a1-a3b3-b33ca5b5b0d2"), "IT" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("3b097e5e-af52-48a6-8d19-764c20d84f3b"), "EL" });

            migrationBuilder.UpdateData(
                table: "DailySettings",
                keyColumn: "Id",
                keyValue: new Guid("0425fbed-f097-4267-8f66-97070c305098"),
                column: "DepartmentId",
                value: new Guid("3b097e5e-af52-48a6-8d19-764c20d84f3b"));

            migrationBuilder.UpdateData(
                table: "DailySettings",
                keyColumn: "Id",
                keyValue: new Guid("ba878476-7300-460b-b6d3-0bcc21e2fc3e"),
                column: "DepartmentId",
                value: new Guid("3b097e5e-af52-48a6-8d19-764c20d84f3b"));

            migrationBuilder.UpdateData(
                table: "DailySettings",
                keyColumn: "Id",
                keyValue: new Guid("bc195ee1-8966-41f3-b54d-b84cd624c5c6"),
                column: "DepartmentId",
                value: new Guid("3b097e5e-af52-48a6-8d19-764c20d84f3b"));

            migrationBuilder.UpdateData(
                table: "DailySettings",
                keyColumn: "Id",
                keyValue: new Guid("be02754d-d2a4-4f70-bd0f-358b826ee35c"),
                column: "DepartmentId",
                value: new Guid("3b097e5e-af52-48a6-8d19-764c20d84f3b"));

            migrationBuilder.UpdateData(
                table: "DailySettings",
                keyColumn: "Id",
                keyValue: new Guid("f3beefe7-ea96-429c-b2ce-b5df60b6a489"),
                column: "DepartmentId",
                value: new Guid("3b097e5e-af52-48a6-8d19-764c20d84f3b"));

            migrationBuilder.InsertData(
                table: "Instructors",
                columns: new[] { "Id", "DepartmentId", "Initials" },
                values: new object[,]
                {
                    { new Guid("144d14bd-9889-4d02-a363-55da5b8d79b6"), new Guid("3b097e5e-af52-48a6-8d19-764c20d84f3b"), "Ingen" },
                    { new Guid("f006ad1d-efd7-44c8-b265-190944fc8293"), new Guid("3b097e5e-af52-48a6-8d19-764c20d84f3b"), "Ins1" },
                    { new Guid("cf10b277-2252-40bd-aeda-332f5b8a3a5e"), new Guid("3b097e5e-af52-48a6-8d19-764c20d84f3b"), "Ins2" },
                    { new Guid("0160e095-05d9-42bf-b5e9-89151c19ace7"), new Guid("3b097e5e-af52-48a6-8d19-764c20d84f3b"), "Ins3" },
                    { new Guid("e2509b15-811a-4e5d-9893-500a3b95e703"), new Guid("3b097e5e-af52-48a6-8d19-764c20d84f3b"), "Ins4" },
                    { new Guid("a2c5dcdb-c5de-4d33-af22-a9867398d2c8"), new Guid("3b097e5e-af52-48a6-8d19-764c20d84f3b"), "Ins5" },
                    { new Guid("d5785c4f-2c01-451d-940c-1cd0d75488cc"), new Guid("3b097e5e-af52-48a6-8d19-764c20d84f3b"), "Ins6" },
                    { new Guid("9b472c83-dbc1-44a3-a8c0-9a291665e528"), new Guid("d3098d42-f0ba-47a1-a3b3-b33ca5b5b0d2"), "Ingen" },
                    { new Guid("d6a6be1a-683d-4116-b3b5-d5dbcb6c3578"), new Guid("d3098d42-f0ba-47a1-a3b3-b33ca5b5b0d2"), "Ins1" },
                    { new Guid("2236ffa8-13c6-43b3-81ba-bef111319138"), new Guid("d3098d42-f0ba-47a1-a3b3-b33ca5b5b0d2"), "Ins2" }
                });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("1ce22baf-3ca5-48c3-8117-a7d7cd323ef9"),
                columns: new[] { "DepartmentId", "InstructorId" },
                values: new object[] { new Guid("3b097e5e-af52-48a6-8d19-764c20d84f3b"), new Guid("cf10b277-2252-40bd-aeda-332f5b8a3a5e") });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("1f5a8482-9578-4eae-8c75-d0d715d19399"),
                columns: new[] { "DepartmentId", "InstructorId" },
                values: new object[] { new Guid("3b097e5e-af52-48a6-8d19-764c20d84f3b"), new Guid("cf10b277-2252-40bd-aeda-332f5b8a3a5e") });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("2ba50544-e4f2-41f0-9320-fb1edd4232a2"),
                columns: new[] { "DepartmentId", "InstructorId" },
                values: new object[] { new Guid("3b097e5e-af52-48a6-8d19-764c20d84f3b"), new Guid("f006ad1d-efd7-44c8-b265-190944fc8293") });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("2c25b0db-1a09-4f84-94e3-c7a4a3c11ee3"),
                columns: new[] { "DepartmentId", "InstructorId" },
                values: new object[] { new Guid("3b097e5e-af52-48a6-8d19-764c20d84f3b"), new Guid("cf10b277-2252-40bd-aeda-332f5b8a3a5e") });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("33e425d4-7ab4-4d0e-9c8f-c69d7a56baa6"),
                columns: new[] { "DepartmentId", "InstructorId" },
                values: new object[] { new Guid("3b097e5e-af52-48a6-8d19-764c20d84f3b"), new Guid("cf10b277-2252-40bd-aeda-332f5b8a3a5e") });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("8da3427c-fef2-46d1-89d1-3023de95bdf6"),
                columns: new[] { "DepartmentId", "InstructorId" },
                values: new object[] { new Guid("3b097e5e-af52-48a6-8d19-764c20d84f3b"), new Guid("f006ad1d-efd7-44c8-b265-190944fc8293") });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("947b6ad8-4451-481e-98d8-f1f71af3e7cc"),
                columns: new[] { "DepartmentId", "InstructorId" },
                values: new object[] { new Guid("3b097e5e-af52-48a6-8d19-764c20d84f3b"), new Guid("f006ad1d-efd7-44c8-b265-190944fc8293") });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("ae0cb609-04c9-494b-b4cc-a0108be8d3dc"),
                columns: new[] { "DepartmentId", "InstructorId" },
                values: new object[] { new Guid("3b097e5e-af52-48a6-8d19-764c20d84f3b"), new Guid("f006ad1d-efd7-44c8-b265-190944fc8293") });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("c3f091f2-4c6d-48b2-824e-e18addc4bb76"),
                columns: new[] { "DepartmentId", "InstructorId" },
                values: new object[] { new Guid("d3098d42-f0ba-47a1-a3b3-b33ca5b5b0d2"), new Guid("9b472c83-dbc1-44a3-a8c0-9a291665e528") });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("cfd50636-7561-4d93-9495-6e3517b8b9d4"),
                columns: new[] { "DepartmentId", "InstructorId" },
                values: new object[] { new Guid("d3098d42-f0ba-47a1-a3b3-b33ca5b5b0d2"), new Guid("9b472c83-dbc1-44a3-a8c0-9a291665e528") });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("e4bf9577-cc35-43c1-9d35-a5232d82483b"),
                columns: new[] { "DepartmentId", "InstructorId" },
                values: new object[] { new Guid("3b097e5e-af52-48a6-8d19-764c20d84f3b"), new Guid("144d14bd-9889-4d02-a363-55da5b8d79b6") });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("e95f208d-2f31-4796-a2a0-64f2fe5c7c97"),
                columns: new[] { "DepartmentId", "InstructorId" },
                values: new object[] { new Guid("3b097e5e-af52-48a6-8d19-764c20d84f3b"), new Guid("cf10b277-2252-40bd-aeda-332f5b8a3a5e") });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("f84307e8-784c-48c2-bbd6-470ec1f7555b"),
                columns: new[] { "DepartmentId", "InstructorId" },
                values: new object[] { new Guid("3b097e5e-af52-48a6-8d19-764c20d84f3b"), new Guid("f006ad1d-efd7-44c8-b265-190944fc8293") });

            migrationBuilder.CreateIndex(
                name: "IX_Students_DepartmentId",
                table: "Students",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_InstructorId",
                table: "Students",
                column: "InstructorId");

            migrationBuilder.CreateIndex(
                name: "IX_DailySettings_DepartmentId",
                table: "DailySettings",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Instructors_DepartmentId",
                table: "Instructors",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_DailySettings_Departments_DepartmentId",
                table: "DailySettings",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentCheckIns_Students_StudentId",
                table: "StudentCheckIns",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Departments_DepartmentId",
                table: "Students",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Instructors_InstructorId",
                table: "Students",
                column: "InstructorId",
                principalTable: "Instructors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DailySettings_Departments_DepartmentId",
                table: "DailySettings");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentCheckIns_Students_StudentId",
                table: "StudentCheckIns");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Departments_DepartmentId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Instructors_InstructorId",
                table: "Students");

            migrationBuilder.DropTable(
                name: "Instructors");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropIndex(
                name: "IX_Students_DepartmentId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_InstructorId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_DailySettings_DepartmentId",
                table: "DailySettings");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "InstructorId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "DailySettings");

            migrationBuilder.AddColumn<int>(
                name: "Department",
                table: "Students",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Instructor",
                table: "Students",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "StudentId",
                table: "StudentCheckIns",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: new Guid("1a2381c9-b461-48f1-9a2e-95314ae62a73"),
                column: "Password",
                value: "$2a$11$BBjn85mOh6Bvo4MI4PJ2be.aow4GQDNknVlRpnYA0ADpgxkOV3kci");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("1ce22baf-3ca5-48c3-8117-a7d7cd323ef9"),
                columns: new[] { "Department", "Instructor" },
                values: new object[] { 0, 1 });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("1f5a8482-9578-4eae-8c75-d0d715d19399"),
                columns: new[] { "Department", "Instructor" },
                values: new object[] { 0, 1 });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("2ba50544-e4f2-41f0-9320-fb1edd4232a2"),
                columns: new[] { "Department", "Instructor" },
                values: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("2c25b0db-1a09-4f84-94e3-c7a4a3c11ee3"),
                columns: new[] { "Department", "Instructor" },
                values: new object[] { 0, 1 });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("33e425d4-7ab4-4d0e-9c8f-c69d7a56baa6"),
                columns: new[] { "Department", "Instructor" },
                values: new object[] { 0, 1 });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("8da3427c-fef2-46d1-89d1-3023de95bdf6"),
                columns: new[] { "Department", "Instructor" },
                values: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("947b6ad8-4451-481e-98d8-f1f71af3e7cc"),
                columns: new[] { "Department", "Instructor" },
                values: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("ae0cb609-04c9-494b-b4cc-a0108be8d3dc"),
                columns: new[] { "Department", "Instructor" },
                values: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("e4bf9577-cc35-43c1-9d35-a5232d82483b"),
                column: "Department",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("e95f208d-2f31-4796-a2a0-64f2fe5c7c97"),
                columns: new[] { "Department", "Instructor" },
                values: new object[] { 0, 1 });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("f84307e8-784c-48c2-bbd6-470ec1f7555b"),
                columns: new[] { "Department", "Instructor" },
                values: new object[] { 0, 0 });

            migrationBuilder.AddForeignKey(
                name: "FK_StudentCheckIns_Students_StudentId",
                table: "StudentCheckIns",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
