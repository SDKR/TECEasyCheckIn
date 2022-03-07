using Core.Model;
using Core.Model.Enums;
using Microsoft.EntityFrameworkCore;
using System;

namespace Infrastructure
{
    public class ECADbContext : DbContext
    {
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<DailySettings> DailySettings { get; set; }
        public DbSet<GeneralSettings> GeneralSettings { get; set; }
        public DbSet<StudentCheckIn> StudentCheckIns { get; set; }

        public ECADbContext(DbContextOptions<ECADbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasOne(s => s.Instructor)
                .WithMany(i => i.Students)
                .OnDelete(DeleteBehavior.Restrict);

            var timespan = new TimeSpan(+2, 0, 0);

            // ADMINS
            modelBuilder.Entity<Admin>().HasData(
                new Admin() 
                { 
                    Id = Guid.Parse("1A2381C9-B461-48F1-9A2E-95314AE62A73"), 
                    Username = "admin", 
                    Password = BCrypt.Net.BCrypt.HashPassword("password"), 
                    FirstName = "adminNavn", LastName = "adminNavn" 
                }
            );

            // DEPARTMENTS
            modelBuilder.Entity<Department>().HasData(
                new Department()
                {
                    Id = Guid.Parse("3b097e5e-af52-48a6-8d19-764c20d84f3b"),
                    Name  = "EL"
                },
                new Department()
                {
                    Id = Guid.Parse("d3098d42-f0ba-47a1-a3b3-b33ca5b5b0d2"),
                    Name = "IT"
                },
                new Department()
                {
                    Id = Guid.Parse("d3098d42-f0ba-47a1-a3b3-b33ca5b5b0a1"),
                    Name = "SystemAdministrator"
                }
            );

            // INSTRUCTORS
            modelBuilder.Entity<Instructor>().HasData(
                // Systemadministrator
                new Instructor()
                {
                    Id = Guid.Parse("144d14bd-9889-4d02-a363-55da5b8d1432"),
                    Initials = "sysadm",
                    Password = "password",
                    Role = "SystemAdministrator",
                    DepartmentId = Guid.Parse("d3098d42-f0ba-47a1-a3b3-b33ca5b5b0a1"),
                },
                // EL
                new Instructor()
                {
                    Id = Guid.Parse("144d14bd-9889-4d02-a363-55da5b8d79b6"),
                    Initials = "Ingen",
                    Password = "password",
                    Role = "Instructor",
                    DepartmentId = Guid.Parse("3b097e5e-af52-48a6-8d19-764c20d84f3b"),
                },
                new Instructor()
                {
                    Id = Guid.Parse("f006ad1d-efd7-44c8-b265-190944fc8293"),
                    Initials = "Ins1",
                    Password = "password",
                    Role = "Administrator",
                    DepartmentId = Guid.Parse("3b097e5e-af52-48a6-8d19-764c20d84f3b"),
                },
                new Instructor()
                {
                    Id = Guid.Parse("cf10b277-2252-40bd-aeda-332f5b8a3a5e"),
                    Initials = "Ins2",
                    Password = "password",
                    Role = "Instructor",
                    DepartmentId = Guid.Parse("3b097e5e-af52-48a6-8d19-764c20d84f3b"),
                },
                new Instructor()
                {
                    Id = Guid.Parse("0160e095-05d9-42bf-b5e9-89151c19ace7"),
                    Initials = "Ins3",
                    Password = "password",
                    Role = "Instructor",
                    DepartmentId = Guid.Parse("3b097e5e-af52-48a6-8d19-764c20d84f3b"),
                },
                new Instructor()
                {
                    Id = Guid.Parse("e2509b15-811a-4e5d-9893-500a3b95e703"),
                    Initials = "Ins4",
                    Password = "password",
                    Role = "Instructor",
                    DepartmentId = Guid.Parse("3b097e5e-af52-48a6-8d19-764c20d84f3b"),
                },
                new Instructor()
                {
                    Id = Guid.Parse("a2c5dcdb-c5de-4d33-af22-a9867398d2c8"),
                    Initials = "Ins5",
                    Password = "password",
                    Role = "Instructor",
                    DepartmentId = Guid.Parse("3b097e5e-af52-48a6-8d19-764c20d84f3b"),
                },
                new Instructor()
                {
                    Id = Guid.Parse("d5785c4f-2c01-451d-940c-1cd0d75488cc"),
                    Initials = "Ins6",
                    Password = "password",
                    Role = "Instructor",
                    DepartmentId = Guid.Parse("3b097e5e-af52-48a6-8d19-764c20d84f3b"),
                },

                // IT
                new Instructor()
                {
                    Id = Guid.Parse("9b472c83-dbc1-44a3-a8c0-9a291665e528"),
                    Initials = "Ingen",
                    Password = "password",
                    Role = "Instructor",
                    DepartmentId = Guid.Parse("d3098d42-f0ba-47a1-a3b3-b33ca5b5b0d2"),
                },
                new Instructor()
                {
                    Id = Guid.Parse("d6a6be1a-683d-4116-b3b5-d5dbcb6c3578"),
                    Initials = "Insx1",
                    Password = "password",
                    Role = "Instructor",
                    DepartmentId = Guid.Parse("d3098d42-f0ba-47a1-a3b3-b33ca5b5b0d2"),
                },
                new Instructor()
                {
                    Id = Guid.Parse("2236ffa8-13c6-43b3-81ba-bef111319138"),
                    Initials = "Insx2",
                    Password = "password",
                    Role = "Instructor",
                    DepartmentId = Guid.Parse("d3098d42-f0ba-47a1-a3b3-b33ca5b5b0d2"),
                }
            );

            // STUDENTS
            modelBuilder.Entity<Student>().HasData(
                // EL DEPARTMENT, ACTIVE
                new Student()
                {
                    Id = Guid.Parse("ae0cb609-04c9-494b-b4cc-a0108be8d3dc"),
                    FirstName = "Mikkel",
                    LastName = "Hammer",
                    DepartmentId = Guid.Parse("3b097e5e-af52-48a6-8d19-764c20d84f3b"),
                    InstructorId = Guid.Parse("f006ad1d-efd7-44c8-b265-190944fc8293"),
                    Status = StudentStatus.Active,
                    IsDeleted = false
                },
                new Student()
                {
                    Id = Guid.Parse("2ba50544-e4f2-41f0-9320-fb1edd4232a2"),
                    FirstName = "Kim",
                    LastName = "Nedergaard",
                    DepartmentId = Guid.Parse("3b097e5e-af52-48a6-8d19-764c20d84f3b"),
                    InstructorId = Guid.Parse("f006ad1d-efd7-44c8-b265-190944fc8293"),
                    Status = StudentStatus.Active,
                    IsDeleted = false
                },
                new Student()
                {
                    Id = Guid.Parse("947b6ad8-4451-481e-98d8-f1f71af3e7cc"),
                    FirstName = "Freddy",
                    LastName = "Jørgensen",
                    DepartmentId = Guid.Parse("3b097e5e-af52-48a6-8d19-764c20d84f3b"),
                    InstructorId = Guid.Parse("f006ad1d-efd7-44c8-b265-190944fc8293"),
                    Status = StudentStatus.Active,
                    IsDeleted = false
                },
                new Student()
                {
                    Id = Guid.Parse("f84307e8-784c-48c2-bbd6-470ec1f7555b"),
                    FirstName = "Bjarke",
                    LastName = "Borg",
                    DepartmentId = Guid.Parse("3b097e5e-af52-48a6-8d19-764c20d84f3b"),
                    InstructorId = Guid.Parse("f006ad1d-efd7-44c8-b265-190944fc8293"),
                    Status = StudentStatus.Active,
                    IsDeleted = false
                },
                new Student()
                {
                    Id = Guid.Parse("8da3427c-fef2-46d1-89d1-3023de95bdf6"),
                    FirstName = "Martin",
                    LastName = "Westergaard",
                    DepartmentId = Guid.Parse("3b097e5e-af52-48a6-8d19-764c20d84f3b"),
                    InstructorId = Guid.Parse("f006ad1d-efd7-44c8-b265-190944fc8293"),
                    Status = StudentStatus.Active,
                    IsDeleted = false
                },
                new Student()
                {
                    Id = Guid.Parse("2c25b0db-1a09-4f84-94e3-c7a4a3c11ee3"),
                    FirstName = "Claus",
                    LastName = "Bruun Kirkegaard",
                    DepartmentId = Guid.Parse("3b097e5e-af52-48a6-8d19-764c20d84f3b"),
                    InstructorId = Guid.Parse("cf10b277-2252-40bd-aeda-332f5b8a3a5e"),
                    Status = StudentStatus.Active,
                    IsDeleted = false
                },
                new Student()
                {
                    Id = Guid.Parse("1f5a8482-9578-4eae-8c75-d0d715d19399"),
                    FirstName = "Henrik",
                    LastName = "Krog Thorsen",
                    DepartmentId = Guid.Parse("3b097e5e-af52-48a6-8d19-764c20d84f3b"),
                    InstructorId = Guid.Parse("cf10b277-2252-40bd-aeda-332f5b8a3a5e"),
                    Status = StudentStatus.Active,
                    IsDeleted = false
                },
                new Student()
                {
                    Id = Guid.Parse("1ce22baf-3ca5-48c3-8117-a7d7cd323ef9"),
                    FirstName = "Axel",
                    LastName = "Bech",
                    DepartmentId = Guid.Parse("3b097e5e-af52-48a6-8d19-764c20d84f3b"),
                    InstructorId = Guid.Parse("cf10b277-2252-40bd-aeda-332f5b8a3a5e"),
                    Status = StudentStatus.Active,
                    IsDeleted = false
                },
                // EL DEPARTMENT, DISABLED
                new Student()
                {
                    Id = Guid.Parse("33e425d4-7ab4-4d0e-9c8f-c69d7a56baa6"),
                    FirstName = "Anders",
                    LastName = "Ilesen",
                    DepartmentId = Guid.Parse("3b097e5e-af52-48a6-8d19-764c20d84f3b"),
                    InstructorId = Guid.Parse("cf10b277-2252-40bd-aeda-332f5b8a3a5e"),
                    Status = StudentStatus.Disabled,
                    IsDeleted = false
                },
                // EL DEPARTMENT, DELETED
                new Student()
                {
                    Id = Guid.Parse("e95f208d-2f31-4796-a2a0-64f2fe5c7c97"),
                    FirstName = "Lars",
                    LastName = "Larsen",
                    DepartmentId = Guid.Parse("3b097e5e-af52-48a6-8d19-764c20d84f3b"),
                    InstructorId = Guid.Parse("cf10b277-2252-40bd-aeda-332f5b8a3a5e"),
                    Status = StudentStatus.Active,
                    IsDeleted = true
                },

                // EL DEPARTMENT, "NO" INSTRUCTOR
                new Student()
                {
                    Id = Guid.Parse("e4bf9577-cc35-43c1-9d35-a5232d82483b"),
                    FirstName = "Tom",
                    LastName = "Madsen",
                    DepartmentId = Guid.Parse("3b097e5e-af52-48a6-8d19-764c20d84f3b"),
                    InstructorId = Guid.Parse("144d14bd-9889-4d02-a363-55da5b8d79b6"),
                    Status = StudentStatus.Active,
                    IsDeleted = true
                },

                // IT DEPARTMENT, "NO" INSTRUCTOR
                new Student()
                {
                    Id = Guid.Parse("c3f091f2-4c6d-48b2-824e-e18addc4bb76"),
                    FirstName = "Oskar",
                    LastName = "Kruse",
                    DepartmentId = Guid.Parse("d3098d42-f0ba-47a1-a3b3-b33ca5b5b0d2"),
                    InstructorId = Guid.Parse("9b472c83-dbc1-44a3-a8c0-9a291665e528"),
                    Status = StudentStatus.Active,
                    IsDeleted = true
                },
                new Student()
                {
                    Id = Guid.Parse("cfd50636-7561-4d93-9495-6e3517b8b9d4"),
                    FirstName = "Laust",
                    LastName = "Høj",
                    DepartmentId = Guid.Parse("d3098d42-f0ba-47a1-a3b3-b33ca5b5b0d2"),
                    InstructorId = Guid.Parse("9b472c83-dbc1-44a3-a8c0-9a291665e528"),
                    Status = StudentStatus.Active,
                    IsDeleted = true
                }
            );

            // DEFAULT DAILY SETTINGS
            modelBuilder.Entity<DailySettings>().HasData(
                // MONDAY
                new DailySettings() { 
                    Id = Guid.Parse("0425fbed-f097-4267-8f66-97070c305098"),
                    Date = new DateTime(0001, 1, 1),
                    LastestCheckInTimeStamp = new DateTimeOffset(0001, 1, 1, 7, 30, 00, timespan),
                    EarliestCheckOutTimeStamp = new DateTimeOffset(0001, 1, 1, 15, 00, 00, timespan),
                    DepartmentId = Guid.Parse("3b097e5e-af52-48a6-8d19-764c20d84f3b")
                },
                // TUESDAY
                new DailySettings()
                {
                    Id = Guid.Parse("be02754d-d2a4-4f70-bd0f-358b826ee35c"),
                    Date = new DateTime(0001, 1, 2),
                    LastestCheckInTimeStamp = new DateTimeOffset(0001, 1, 2, 7, 30, 00, timespan),
                    EarliestCheckOutTimeStamp = new DateTimeOffset(0001, 1, 2, 15, 00, 00, timespan),
                    DepartmentId = Guid.Parse("3b097e5e-af52-48a6-8d19-764c20d84f3b")
                },
                // WEDNESDAY
                new DailySettings()
                {
                    Id = Guid.Parse("f3beefe7-ea96-429c-b2ce-b5df60b6a489"),
                    Date = new DateTime(0001, 1, 3),
                    LastestCheckInTimeStamp = new DateTimeOffset(0001, 1, 3, 7, 30, 00, timespan),
                    EarliestCheckOutTimeStamp = new DateTimeOffset(0001, 1, 3, 15, 00, 00, timespan),
                    DepartmentId = Guid.Parse("3b097e5e-af52-48a6-8d19-764c20d84f3b")
                },
                // THURSDAY
                new DailySettings()
                {
                    Id = Guid.Parse("bc195ee1-8966-41f3-b54d-b84cd624c5c6"),
                    Date = new DateTime(0001, 1, 4),
                    LastestCheckInTimeStamp = new DateTimeOffset(0001, 1, 4, 7, 30, 00, timespan),
                    EarliestCheckOutTimeStamp = new DateTimeOffset(0001, 1, 4, 15, 00, 00, timespan),
                    DepartmentId = Guid.Parse("3b097e5e-af52-48a6-8d19-764c20d84f3b")
                },
                // FRIDAY
                new DailySettings()
                {
                    Id = Guid.Parse("ba878476-7300-460b-b6d3-0bcc21e2fc3e"),
                    Date = new DateTime(0001, 1, 5),
                    LastestCheckInTimeStamp = new DateTimeOffset(0001, 1, 5, 7, 30, 00, timespan),
                    EarliestCheckOutTimeStamp = new DateTimeOffset(0001, 1, 5, 14, 30, 00, timespan),
                    DepartmentId = Guid.Parse("3b097e5e-af52-48a6-8d19-764c20d84f3b")
                }
            );

            modelBuilder.Entity<StudentCheckIn>().HasData(
                // NEW ENTITIES WITH STUDENT FK
                // STUDENT ACTIVE & NOT "DELETED"

                // MIKKEL HAMMER
                new StudentCheckIn()
                {
                    Id = Guid.Parse("0669b168-aada-4e2e-a814-b92f992a3041"),
                    StudentName = "Mikkel Hammer",
                    Date = new DateTime(2020, 8, 3),
                    CheckInTimeStamp = new DateTimeOffset(2020, 8, 3, 7, 23, 51, timespan),
                    CheckOutTimeStamp = new DateTimeOffset(2020, 8, 3, 15, 5, 35, timespan),
                    Attendance = AttendanceStatus.OnTime,
                    StudentId = Guid.Parse("ae0cb609-04c9-494b-b4cc-a0108be8d3dc")
                },
                new StudentCheckIn()
                {
                    Id = Guid.Parse("da1a4904-19f7-47bb-85a0-8893f26237cf"),
                    StudentName = "Mikkel Hammer",
                    Date = new DateTime(2020, 8, 4),
                    CheckInTimeStamp = new DateTimeOffset(2020, 8, 4, 7, 26, 32, timespan),
                    CheckOutTimeStamp = new DateTimeOffset(2020, 8, 4, 15, 1, 47, timespan),
                    Attendance = AttendanceStatus.OnTime,
                    StudentId = Guid.Parse("ae0cb609-04c9-494b-b4cc-a0108be8d3dc")
                },
                new StudentCheckIn()
                {
                    Id = Guid.Parse("53719f18-952a-4795-9069-546b535b2472"),
                    StudentName = "Mikkel Hammer",
                    Date = new DateTime(2020, 8, 5),
                    CheckInTimeStamp = new DateTimeOffset(2020, 8, 5, 7, 21, 23, timespan),
                    CheckOutTimeStamp = new DateTimeOffset(2020, 8, 5, 15, 3, 21, timespan),
                    Attendance = AttendanceStatus.OnTime,
                    StudentId = Guid.Parse("ae0cb609-04c9-494b-b4cc-a0108be8d3dc")
                },

                // KIM NEDERGAARD
                new StudentCheckIn()
                {
                    Id = Guid.Parse("ee92be11-0f3f-47f3-864b-c2411b56c96e"),
                    StudentName = "Kim Nedergaard",
                    Date = new DateTime(2020, 8, 3),
                    CheckInTimeStamp = new DateTimeOffset(2020, 8, 3, 7, 23, 58, timespan),
                    CheckOutTimeStamp = new DateTimeOffset(2020, 8, 3, 15, 2, 33, timespan),
                    Attendance = AttendanceStatus.OnTime,
                    StudentId = Guid.Parse("2ba50544-e4f2-41f0-9320-fb1edd4232a2"),
                },
                new StudentCheckIn()
                {
                    Id = Guid.Parse("858c11da-d530-48be-ace6-9a5466f09eee"),
                    StudentName = "Kim Nedergaard",
                    Date = new DateTime(2020, 8, 4),
                    CheckInTimeStamp = new DateTimeOffset(2020, 8, 4, 7, 41, 23, timespan), // LATE CHECKIN
                    CheckOutTimeStamp = new DateTimeOffset(2020, 8, 4, 15, 0, 43, timespan),
                    Attendance = AttendanceStatus.Late,
                    StudentId = Guid.Parse("2ba50544-e4f2-41f0-9320-fb1edd4232a2"),
                },
                new StudentCheckIn()
                {
                    Id = Guid.Parse("30f41d52-6e3c-438c-8a17-127745209450"),
                    StudentName = "Kim Nedergaard",
                    Date = new DateTime(2020, 8, 5),
                    CheckInTimeStamp = new DateTimeOffset(2020, 8, 5, 7, 21, 23, timespan),
                    CheckOutTimeStamp = new DateTimeOffset(2020, 8, 5, 15, 3, 21, timespan),
                    Attendance = AttendanceStatus.OnTime,
                    StudentId = Guid.Parse("2ba50544-e4f2-41f0-9320-fb1edd4232a2"),
                },

                // FREDDY JØRGENSEN
                new StudentCheckIn()
                {
                    Id = Guid.Parse("597dbd0d-cd5e-4b50-bb6a-e6784cef0411"),
                    StudentName = "Freddy Jørgensen",
                    Date = new DateTime(2020, 8, 3),
                    CheckInTimeStamp = new DateTimeOffset(2020, 8, 3, 7, 23, 58, timespan),
                    CheckOutTimeStamp = new DateTimeOffset(2020, 8, 3, 15, 2, 33, timespan),
                    Attendance = AttendanceStatus.OnTime,
                    StudentId = Guid.Parse("947b6ad8-4451-481e-98d8-f1f71af3e7cc"),
                },
                new StudentCheckIn()
                {
                    Id = Guid.Parse("1cbc3b47-f5b1-4ce1-9d69-5b507c21af1d"),
                    StudentName = "Freddy Jørgensen",
                    Date = new DateTime(2020, 8, 4),
                    CheckInTimeStamp = new DateTimeOffset(2020, 8, 4, 7, 29, 23, timespan),
                    CheckOutTimeStamp = new DateTimeOffset(2020, 8, 4, 13, 21, 43, timespan), // EARLY CHECKOUT
                    Attendance = AttendanceStatus.OnTime,
                    StudentId = Guid.Parse("947b6ad8-4451-481e-98d8-f1f71af3e7cc"),
                },
                new StudentCheckIn()
                {
                    Id = Guid.Parse("3fca7b80-ca50-48cb-89ca-3216d8303dde"),
                    StudentName = "Freddy Jørgensen",
                    Date = new DateTime(2020, 8, 5),
                    CheckInTimeStamp = new DateTimeOffset(2020, 8, 5, 7, 21, 23, timespan),
                    CheckOutTimeStamp = new DateTimeOffset(2020, 8, 5, 14, 44, 21, timespan), // EARLY CHECKOUT
                    Attendance = AttendanceStatus.OnTime,
                    StudentId = Guid.Parse("947b6ad8-4451-481e-98d8-f1f71af3e7cc"),
                },

                // BJARKE BORG
                new StudentCheckIn()
                {
                    Id = Guid.Parse("becc4714-4223-4aca-acbc-f8a6531483b4"),
                    StudentName = "Bjarke Borg",
                    Date = new DateTime(2020, 8, 3),
                    CheckInTimeStamp = new DateTimeOffset(2020, 8, 3, 7, 28, 51, timespan),
                    CheckOutTimeStamp = new DateTimeOffset(2020, 8, 3, 15, 1, 21, timespan),
                    Attendance = AttendanceStatus.OnTime,
                    StudentId = Guid.Parse("f84307e8-784c-48c2-bbd6-470ec1f7555b"),
                },
                new StudentCheckIn()
                {
                    Id = Guid.Parse("5d486a6f-d38a-4d4c-b476-d13aa72b9a6d"),
                    StudentName = "Bjarke Borg",
                    Date = new DateTime(2020, 8, 4),
                    CheckInTimeStamp = new DateTimeOffset(2020, 8, 4, 7, 17, 25, timespan),
                    CheckOutTimeStamp = new DateTimeOffset(2020, 8, 4, 15, 0, 12, timespan),
                    Attendance = AttendanceStatus.OnTime,
                    StudentId = Guid.Parse("f84307e8-784c-48c2-bbd6-470ec1f7555b"),
                },
                new StudentCheckIn()
                {
                    Id = Guid.Parse("64b7acd1-f363-4fc6-a825-96330817fda3"),
                    StudentName = "Bjarke Borg",
                    Date = new DateTime(2020, 8, 5),
                    CheckInTimeStamp = new DateTimeOffset(2020, 8, 5, 7, 25, 14, timespan),
                    CheckOutTimeStamp = new DateTimeOffset(2020, 8, 5, 15, 1, 56, timespan),
                    Attendance = AttendanceStatus.OnTime,
                    StudentId = Guid.Parse("f84307e8-784c-48c2-bbd6-470ec1f7555b"),
                },

                // MARTIN WESTERGAARD
                new StudentCheckIn()
                {
                    Id = Guid.Parse("78b5e513-b9a9-423b-890c-8a47f47e1f08"),
                    StudentName = "Martin Westergaard",
                    Date = new DateTime(2020, 8, 3),
                    CheckInTimeStamp = new DateTimeOffset(2020, 8, 3, 7, 15, 52, timespan),
                    CheckOutTimeStamp = new DateTimeOffset(2020, 8, 3, 15, 1, 16, timespan),
                    Attendance = AttendanceStatus.OnTime,
                    StudentId = Guid.Parse("8da3427c-fef2-46d1-89d1-3023de95bdf6"),
                },
                new StudentCheckIn()
                {
                    Id = Guid.Parse("3eec7f4e-c762-4e8b-a428-1ac3faf6555b"),
                    StudentName = "Martin Westergaard",
                    Date = new DateTime(2020, 8, 4),
                    CheckInTimeStamp = new DateTimeOffset(2020, 8, 4, 7, 29, 25, timespan),
                    CheckOutTimeStamp = new DateTimeOffset(2020, 8, 4, 15, 0, 13, timespan),
                    Attendance = AttendanceStatus.OnTime,
                    StudentId = Guid.Parse("8da3427c-fef2-46d1-89d1-3023de95bdf6"),
                },
                new StudentCheckIn()
                {
                    Id = Guid.Parse("b7183a8f-2b40-4074-acf7-9fc0156e486f"),
                    StudentName = "Martin Westergaard",
                    Date = new DateTime(2020, 8, 5),
                    CheckInTimeStamp = new DateTimeOffset(2020, 8, 5, 7, 25, 1, timespan),
                    CheckOutTimeStamp = new DateTimeOffset(2020, 8, 5, 15, 0, 26, timespan),
                    Attendance = AttendanceStatus.OnTime,
                    StudentId = Guid.Parse("8da3427c-fef2-46d1-89d1-3023de95bdf6"),
                },

                // CLAUS BRUUN KIRKEGAARD
                new StudentCheckIn()
                {
                    Id = Guid.Parse("872744e1-3a52-49bf-be55-b3bd48ee3311"),
                    StudentName = "Claus Bruun Kirkegaard",
                    Date = new DateTime(2020, 8, 3),
                    CheckInTimeStamp = new DateTimeOffset(2020, 8, 3, 7, 26, 31, timespan),
                    CheckOutTimeStamp = new DateTimeOffset(2020, 8, 3, 15, 6, 21, timespan),
                    Attendance = AttendanceStatus.OnTime,
                    StudentId = Guid.Parse("2c25b0db-1a09-4f84-94e3-c7a4a3c11ee3"),
                },
                new StudentCheckIn()
                {
                    Id = Guid.Parse("451c0f3d-5ad7-4fda-b94d-1870703104d4"),
                    StudentName = "Claus Bruun Kirkegaard",
                    Date = new DateTime(2020, 8, 4),
                    CheckInTimeStamp = new DateTimeOffset(2020, 8, 4, 7, 17, 5, timespan),
                    CheckOutTimeStamp = new DateTimeOffset(2020, 8, 4, 15, 0, 16, timespan),
                    Attendance = AttendanceStatus.OnTime,
                    StudentId = Guid.Parse("2c25b0db-1a09-4f84-94e3-c7a4a3c11ee3"),
                },
                new StudentCheckIn()
                {
                    Id = Guid.Parse("9e578d4a-695f-4256-a0b1-2e84537537d7"),
                    StudentName = "Claus Bruun Kirkegaard",
                    Date = new DateTime(2020, 8, 5),
                    CheckInTimeStamp = new DateTimeOffset(2020, 8, 5, 7, 16, 26, timespan),
                    CheckOutTimeStamp = new DateTimeOffset(2020, 8, 5, 15, 2, 17, timespan),
                    Attendance = AttendanceStatus.OnTime,
                    StudentId = Guid.Parse("2c25b0db-1a09-4f84-94e3-c7a4a3c11ee3"),
                },

                // HENRIK KROG THORSEN
                new StudentCheckIn()
                {
                    Id = Guid.Parse("6fe288da-404b-4ea0-84d6-108aebc0b089"),
                    StudentName = "Henrik Krog Thorsen",
                    Date = new DateTime(2020, 8, 3),
                    CheckInTimeStamp = new DateTimeOffset(2020, 8, 3, 7, 23, 58, timespan),
                    CheckOutTimeStamp = new DateTimeOffset(2020, 8, 3, 15, 2, 33, timespan),
                    Attendance = AttendanceStatus.OnTime,
                    StudentId = Guid.Parse("1f5a8482-9578-4eae-8c75-d0d715d19399"),
                },
                new StudentCheckIn()
                {
                    Id = Guid.Parse("c65003fe-77b5-4e0a-bc82-8890c880206b"),
                    StudentName = "Henrik Krog Thorsen",
                    Date = new DateTime(2020, 8, 4),
                    CheckInTimeStamp = new DateTimeOffset(2020, 8, 4, 7, 27, 57, timespan),
                    CheckOutTimeStamp = new DateTimeOffset(2020, 8, 4, 15, 1, 12, timespan),
                    Attendance = AttendanceStatus.OnTime,
                    StudentId = Guid.Parse("1f5a8482-9578-4eae-8c75-d0d715d19399"),
                },
                new StudentCheckIn()
                {
                    Id = Guid.Parse("46bdbdc4-1760-4dcc-a09e-5e57805c49ae"),
                    StudentName = "Henrik Krog Thorsen",
                    Date = new DateTime(2020, 8, 5),
                    CheckInTimeStamp = new DateTimeOffset(2020, 8, 5, 7, 21, 23, timespan),
                    CheckOutTimeStamp = new DateTimeOffset(2020, 8, 5, 15, 0, 16, timespan),
                    Attendance = AttendanceStatus.OnTime,
                    StudentId = Guid.Parse("1f5a8482-9578-4eae-8c75-d0d715d19399"),
                },

                // AXEL BECH
                new StudentCheckIn()
                {
                    Id = Guid.Parse("a5cdae63-3bba-4b10-920b-1003306530db"),
                    StudentName = "Axel Bech",
                    Date = new DateTime(2020, 8, 3),
                    CheckInTimeStamp = new DateTimeOffset(2020, 8, 3, 7, 11, 54, timespan),
                    CheckOutTimeStamp = new DateTimeOffset(2020, 8, 3, 15, 1, 24, timespan),
                    Attendance = AttendanceStatus.OnTime,
                    StudentId = Guid.Parse("1ce22baf-3ca5-48c3-8117-a7d7cd323ef9"),
                },
                new StudentCheckIn()
                {
                    Id = Guid.Parse("7d4d021e-aa3c-4f77-beff-f8de2ccc1390"),
                    StudentName = "Axel Bech",
                    Date = new DateTime(2020, 8, 4),
                    CheckInTimeStamp = new DateTimeOffset(2020, 8, 4, 7, 26, 42, timespan),
                    CheckOutTimeStamp = new DateTimeOffset(2020, 8, 4, 15, 0, 34, timespan),
                    Attendance = AttendanceStatus.OnTime,
                    StudentId = Guid.Parse("1ce22baf-3ca5-48c3-8117-a7d7cd323ef9"),
                },
                new StudentCheckIn()
                {
                    Id = Guid.Parse("db44ce8c-5c36-455f-85cb-f0ba2738926c"),
                    StudentName = "Axel Bech",
                    Date = new DateTime(2020, 8, 5),
                    CheckInTimeStamp = new DateTimeOffset(2020, 8, 5, 7, 24, 46, timespan),
                    CheckOutTimeStamp = new DateTimeOffset(2020, 8, 5, 15, 0, 16, timespan),
                    Attendance = AttendanceStatus.OnTime,
                    StudentId = Guid.Parse("1ce22baf-3ca5-48c3-8117-a7d7cd323ef9"),
                },


                // STUDENT DISABLED & NOT "DELETED"
                new StudentCheckIn()
                {
                    Id = Guid.Parse("ee0d79f8-b3db-4af8-aa0b-3cdc55cca039"),
                    StudentName = "Anders Ilesen",
                    Date = new DateTime(2020, 8, 3),
                    CheckInTimeStamp = new DateTimeOffset(2020, 8, 3, 7, 23, 51, timespan),
                    CheckOutTimeStamp = new DateTimeOffset(2020, 8, 3, 15, 5, 35, timespan),
                    Attendance = AttendanceStatus.OnTime,
                    StudentId = Guid.Parse("33e425d4-7ab4-4d0e-9c8f-c69d7a56baa6")
                },
                new StudentCheckIn()
                {
                    Id = Guid.Parse("0cfc589f-6340-41c4-a826-24283d656227"),
                    StudentName = "Anders Ilesen",
                    Date = new DateTime(2020, 8, 4),
                    CheckInTimeStamp = new DateTimeOffset(2020, 8, 4, 7, 26, 32, timespan),
                    CheckOutTimeStamp = new DateTimeOffset(2020, 8, 4, 15, 1, 47, timespan),
                    Attendance = AttendanceStatus.OnTime,
                    StudentId = Guid.Parse("33e425d4-7ab4-4d0e-9c8f-c69d7a56baa6")
                },
                new StudentCheckIn()
                {
                    Id = Guid.Parse("5f99d0e6-f71b-4ec3-8973-7ebd113b03a4"),
                    StudentName = "Anders Ilesen",
                    Date = new DateTime(2020, 8, 5),
                    CheckInTimeStamp = new DateTimeOffset(2020, 8, 5, 7, 21, 23, timespan),
                    CheckOutTimeStamp = new DateTimeOffset(2020, 8, 5, 15, 3, 21, timespan),
                    Attendance = AttendanceStatus.OnTime,
                    StudentId = Guid.Parse("33e425d4-7ab4-4d0e-9c8f-c69d7a56baa6")
                },

                // STUDENT ACTIVE & "DELETED"
                new StudentCheckIn()
                {
                    Id = Guid.Parse("22530fbd-569a-492c-be29-99b55858d421"),
                    StudentName = "Lars Larsen",
                    Date = new DateTime(2020, 8, 3),
                    CheckInTimeStamp = new DateTimeOffset(2020, 8, 3, 7, 23, 51, timespan),
                    CheckOutTimeStamp = new DateTimeOffset(2020, 8, 3, 15, 5, 35, timespan),
                    Attendance = AttendanceStatus.OnTime,
                    StudentId = Guid.Parse("e95f208d-2f31-4796-a2a0-64f2fe5c7c97")
                },
                new StudentCheckIn()
                {
                    Id = Guid.Parse("f03141fd-ef0e-46d6-8adb-d25182b56f6a"),
                    StudentName = "Lars Larsen",
                    Date = new DateTime(2020, 8, 4),
                    CheckInTimeStamp = new DateTimeOffset(2020, 8, 4, 7, 26, 32, timespan),
                    CheckOutTimeStamp = new DateTimeOffset(2020, 8, 4, 15, 1, 47, timespan),
                    Attendance = AttendanceStatus.OnTime,
                    StudentId = Guid.Parse("e95f208d-2f31-4796-a2a0-64f2fe5c7c97")
                },
                new StudentCheckIn()
                {
                    Id = Guid.Parse("1a128961-d3cc-490a-b0e3-c45171afeb27"),
                    StudentName = "Lars Larsen",
                    Date = new DateTime(2020, 8, 5),
                    CheckInTimeStamp = new DateTimeOffset(2020, 8, 5, 7, 21, 23, timespan),
                    CheckOutTimeStamp = new DateTimeOffset(2020, 8, 5, 15, 3, 21, timespan),
                    Attendance = AttendanceStatus.OnTime,
                    StudentId = Guid.Parse("e95f208d-2f31-4796-a2a0-64f2fe5c7c97")
                }

            );
        }
    }
}
