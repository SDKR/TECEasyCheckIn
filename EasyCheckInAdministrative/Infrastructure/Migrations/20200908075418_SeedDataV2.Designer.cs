﻿// <auto-generated />
using System;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Migrations
{
    [DbContext(typeof(ECADbContext))]
    [Migration("20200908075418_SeedDataV2")]
    partial class SeedDataV2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Core.Model.Admin", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Admins");

                    b.HasData(
                        new
                        {
                            Id = new Guid("1a2381c9-b461-48f1-9a2e-95314ae62a73"),
                            FirstName = "adminNavn",
                            LastName = "adminNavn",
                            Password = "$2a$11$BBjn85mOh6Bvo4MI4PJ2be.aow4GQDNknVlRpnYA0ADpgxkOV3kci",
                            Username = "admin"
                        });
                });

            modelBuilder.Entity("Core.Model.DailySettings", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<DateTimeOffset>("EarliestCheckOutTimeStamp")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset>("LastestCheckInTimeStamp")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("Id");

                    b.ToTable("DailySettings");

                    b.HasData(
                        new
                        {
                            Id = new Guid("0425fbed-f097-4267-8f66-97070c305098"),
                            Date = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EarliestCheckOutTimeStamp = new DateTimeOffset(new DateTime(1, 1, 1, 15, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)),
                            LastestCheckInTimeStamp = new DateTimeOffset(new DateTime(1, 1, 1, 7, 30, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0))
                        },
                        new
                        {
                            Id = new Guid("be02754d-d2a4-4f70-bd0f-358b826ee35c"),
                            Date = new DateTime(1, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EarliestCheckOutTimeStamp = new DateTimeOffset(new DateTime(1, 1, 2, 15, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)),
                            LastestCheckInTimeStamp = new DateTimeOffset(new DateTime(1, 1, 2, 7, 30, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0))
                        },
                        new
                        {
                            Id = new Guid("f3beefe7-ea96-429c-b2ce-b5df60b6a489"),
                            Date = new DateTime(1, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EarliestCheckOutTimeStamp = new DateTimeOffset(new DateTime(1, 1, 3, 15, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)),
                            LastestCheckInTimeStamp = new DateTimeOffset(new DateTime(1, 1, 3, 7, 30, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0))
                        },
                        new
                        {
                            Id = new Guid("bc195ee1-8966-41f3-b54d-b84cd624c5c6"),
                            Date = new DateTime(1, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EarliestCheckOutTimeStamp = new DateTimeOffset(new DateTime(1, 1, 4, 15, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)),
                            LastestCheckInTimeStamp = new DateTimeOffset(new DateTime(1, 1, 4, 7, 30, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0))
                        },
                        new
                        {
                            Id = new Guid("ba878476-7300-460b-b6d3-0bcc21e2fc3e"),
                            Date = new DateTime(1, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EarliestCheckOutTimeStamp = new DateTimeOffset(new DateTime(1, 1, 5, 14, 30, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)),
                            LastestCheckInTimeStamp = new DateTimeOffset(new DateTime(1, 1, 5, 7, 30, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0))
                        });
                });

            modelBuilder.Entity("Core.Model.GeneralSettings", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("TimeToKeepData")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("Id");

                    b.ToTable("GeneralSettings");
                });

            modelBuilder.Entity("Core.Model.Student", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CardName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("DeletedById")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset?>("DeletedOn")
                        .HasColumnType("datetimeoffset");

                    b.Property<int?>("Department")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Instructor")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("StatusComment")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DeletedById");

                    b.ToTable("Students");

                    b.HasData(
                        new
                        {
                            Id = new Guid("ae0cb609-04c9-494b-b4cc-a0108be8d3dc"),
                            Department = 0,
                            FirstName = "Mikkel",
                            Instructor = 0,
                            IsDeleted = false,
                            LastName = "Hammer",
                            Status = 0
                        },
                        new
                        {
                            Id = new Guid("2ba50544-e4f2-41f0-9320-fb1edd4232a2"),
                            Department = 0,
                            FirstName = "Kim",
                            Instructor = 0,
                            IsDeleted = false,
                            LastName = "Nedergaard",
                            Status = 0
                        },
                        new
                        {
                            Id = new Guid("947b6ad8-4451-481e-98d8-f1f71af3e7cc"),
                            Department = 0,
                            FirstName = "Freddy",
                            Instructor = 0,
                            IsDeleted = false,
                            LastName = "Jørgensen",
                            Status = 0
                        },
                        new
                        {
                            Id = new Guid("f84307e8-784c-48c2-bbd6-470ec1f7555b"),
                            Department = 0,
                            FirstName = "Bjarke",
                            Instructor = 0,
                            IsDeleted = false,
                            LastName = "Borg",
                            Status = 0
                        },
                        new
                        {
                            Id = new Guid("8da3427c-fef2-46d1-89d1-3023de95bdf6"),
                            Department = 0,
                            FirstName = "Martin",
                            Instructor = 0,
                            IsDeleted = false,
                            LastName = "Westergaard",
                            Status = 0
                        },
                        new
                        {
                            Id = new Guid("2c25b0db-1a09-4f84-94e3-c7a4a3c11ee3"),
                            Department = 0,
                            FirstName = "Claus",
                            Instructor = 1,
                            IsDeleted = false,
                            LastName = "Bruun Kirkegaard",
                            Status = 0
                        },
                        new
                        {
                            Id = new Guid("1f5a8482-9578-4eae-8c75-d0d715d19399"),
                            Department = 0,
                            FirstName = "Henrik",
                            Instructor = 1,
                            IsDeleted = false,
                            LastName = "Krog Thorsen",
                            Status = 0
                        },
                        new
                        {
                            Id = new Guid("1ce22baf-3ca5-48c3-8117-a7d7cd323ef9"),
                            Department = 0,
                            FirstName = "Axel",
                            Instructor = 1,
                            IsDeleted = false,
                            LastName = "Bech",
                            Status = 0
                        },
                        new
                        {
                            Id = new Guid("33e425d4-7ab4-4d0e-9c8f-c69d7a56baa6"),
                            Department = 0,
                            FirstName = "Anders",
                            Instructor = 1,
                            IsDeleted = false,
                            LastName = "Ilesen",
                            Status = 1
                        },
                        new
                        {
                            Id = new Guid("e95f208d-2f31-4796-a2a0-64f2fe5c7c97"),
                            Department = 0,
                            FirstName = "Lars",
                            Instructor = 1,
                            IsDeleted = true,
                            LastName = "Larsen",
                            Status = 0
                        },
                        new
                        {
                            Id = new Guid("e4bf9577-cc35-43c1-9d35-a5232d82483b"),
                            Department = 0,
                            FirstName = "Tom",
                            IsDeleted = true,
                            LastName = "Madsen",
                            Status = 0
                        },
                        new
                        {
                            Id = new Guid("c3f091f2-4c6d-48b2-824e-e18addc4bb76"),
                            FirstName = "Oskar",
                            IsDeleted = true,
                            LastName = "Kruse",
                            Status = 0
                        },
                        new
                        {
                            Id = new Guid("cfd50636-7561-4d93-9495-6e3517b8b9d4"),
                            FirstName = "Laust",
                            IsDeleted = true,
                            LastName = "Høj",
                            Status = 0
                        });
                });

            modelBuilder.Entity("Core.Model.StudentCheckIn", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Attendance")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset?>("CheckInTimeStamp")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset?>("CheckOutTimeStamp")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("StudentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("StudentName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.ToTable("StudentCheckIns");

                    b.HasData(
                        new
                        {
                            Id = new Guid("0669b168-aada-4e2e-a814-b92f992a3041"),
                            Attendance = 0,
                            CheckInTimeStamp = new DateTimeOffset(new DateTime(2020, 8, 3, 7, 23, 51, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)),
                            CheckOutTimeStamp = new DateTimeOffset(new DateTime(2020, 8, 3, 15, 5, 35, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)),
                            Date = new DateTime(2020, 8, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StudentId = new Guid("ae0cb609-04c9-494b-b4cc-a0108be8d3dc"),
                            StudentName = "Mikkel Hammer"
                        },
                        new
                        {
                            Id = new Guid("da1a4904-19f7-47bb-85a0-8893f26237cf"),
                            Attendance = 0,
                            CheckInTimeStamp = new DateTimeOffset(new DateTime(2020, 8, 4, 7, 26, 32, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)),
                            CheckOutTimeStamp = new DateTimeOffset(new DateTime(2020, 8, 4, 15, 1, 47, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)),
                            Date = new DateTime(2020, 8, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StudentId = new Guid("ae0cb609-04c9-494b-b4cc-a0108be8d3dc"),
                            StudentName = "Mikkel Hammer"
                        },
                        new
                        {
                            Id = new Guid("53719f18-952a-4795-9069-546b535b2472"),
                            Attendance = 0,
                            CheckInTimeStamp = new DateTimeOffset(new DateTime(2020, 8, 5, 7, 21, 23, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)),
                            CheckOutTimeStamp = new DateTimeOffset(new DateTime(2020, 8, 5, 15, 3, 21, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)),
                            Date = new DateTime(2020, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StudentId = new Guid("ae0cb609-04c9-494b-b4cc-a0108be8d3dc"),
                            StudentName = "Mikkel Hammer"
                        },
                        new
                        {
                            Id = new Guid("ee92be11-0f3f-47f3-864b-c2411b56c96e"),
                            Attendance = 0,
                            CheckInTimeStamp = new DateTimeOffset(new DateTime(2020, 8, 3, 7, 23, 58, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)),
                            CheckOutTimeStamp = new DateTimeOffset(new DateTime(2020, 8, 3, 15, 2, 33, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)),
                            Date = new DateTime(2020, 8, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StudentId = new Guid("2ba50544-e4f2-41f0-9320-fb1edd4232a2"),
                            StudentName = "Kim Nedergaard"
                        },
                        new
                        {
                            Id = new Guid("858c11da-d530-48be-ace6-9a5466f09eee"),
                            Attendance = 1,
                            CheckInTimeStamp = new DateTimeOffset(new DateTime(2020, 8, 4, 7, 41, 23, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)),
                            CheckOutTimeStamp = new DateTimeOffset(new DateTime(2020, 8, 4, 15, 0, 43, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)),
                            Date = new DateTime(2020, 8, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StudentId = new Guid("2ba50544-e4f2-41f0-9320-fb1edd4232a2"),
                            StudentName = "Kim Nedergaard"
                        },
                        new
                        {
                            Id = new Guid("30f41d52-6e3c-438c-8a17-127745209450"),
                            Attendance = 0,
                            CheckInTimeStamp = new DateTimeOffset(new DateTime(2020, 8, 5, 7, 21, 23, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)),
                            CheckOutTimeStamp = new DateTimeOffset(new DateTime(2020, 8, 5, 15, 3, 21, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)),
                            Date = new DateTime(2020, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StudentId = new Guid("2ba50544-e4f2-41f0-9320-fb1edd4232a2"),
                            StudentName = "Kim Nedergaard"
                        },
                        new
                        {
                            Id = new Guid("597dbd0d-cd5e-4b50-bb6a-e6784cef0411"),
                            Attendance = 0,
                            CheckInTimeStamp = new DateTimeOffset(new DateTime(2020, 8, 3, 7, 23, 58, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)),
                            CheckOutTimeStamp = new DateTimeOffset(new DateTime(2020, 8, 3, 15, 2, 33, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)),
                            Date = new DateTime(2020, 8, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StudentId = new Guid("947b6ad8-4451-481e-98d8-f1f71af3e7cc"),
                            StudentName = "Freddy Jørgensen"
                        },
                        new
                        {
                            Id = new Guid("1cbc3b47-f5b1-4ce1-9d69-5b507c21af1d"),
                            Attendance = 0,
                            CheckInTimeStamp = new DateTimeOffset(new DateTime(2020, 8, 4, 7, 29, 23, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)),
                            CheckOutTimeStamp = new DateTimeOffset(new DateTime(2020, 8, 4, 13, 21, 43, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)),
                            Date = new DateTime(2020, 8, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StudentId = new Guid("947b6ad8-4451-481e-98d8-f1f71af3e7cc"),
                            StudentName = "Freddy Jørgensen"
                        },
                        new
                        {
                            Id = new Guid("3fca7b80-ca50-48cb-89ca-3216d8303dde"),
                            Attendance = 0,
                            CheckInTimeStamp = new DateTimeOffset(new DateTime(2020, 8, 5, 7, 21, 23, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)),
                            CheckOutTimeStamp = new DateTimeOffset(new DateTime(2020, 8, 5, 14, 44, 21, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)),
                            Date = new DateTime(2020, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StudentId = new Guid("947b6ad8-4451-481e-98d8-f1f71af3e7cc"),
                            StudentName = "Freddy Jørgensen"
                        },
                        new
                        {
                            Id = new Guid("becc4714-4223-4aca-acbc-f8a6531483b4"),
                            Attendance = 0,
                            CheckInTimeStamp = new DateTimeOffset(new DateTime(2020, 8, 3, 7, 28, 51, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)),
                            CheckOutTimeStamp = new DateTimeOffset(new DateTime(2020, 8, 3, 15, 1, 21, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)),
                            Date = new DateTime(2020, 8, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StudentId = new Guid("f84307e8-784c-48c2-bbd6-470ec1f7555b"),
                            StudentName = "Bjarke Borg"
                        },
                        new
                        {
                            Id = new Guid("5d486a6f-d38a-4d4c-b476-d13aa72b9a6d"),
                            Attendance = 0,
                            CheckInTimeStamp = new DateTimeOffset(new DateTime(2020, 8, 4, 7, 17, 25, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)),
                            CheckOutTimeStamp = new DateTimeOffset(new DateTime(2020, 8, 4, 15, 0, 12, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)),
                            Date = new DateTime(2020, 8, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StudentId = new Guid("f84307e8-784c-48c2-bbd6-470ec1f7555b"),
                            StudentName = "Bjarke Borg"
                        },
                        new
                        {
                            Id = new Guid("64b7acd1-f363-4fc6-a825-96330817fda3"),
                            Attendance = 0,
                            CheckInTimeStamp = new DateTimeOffset(new DateTime(2020, 8, 5, 7, 25, 14, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)),
                            CheckOutTimeStamp = new DateTimeOffset(new DateTime(2020, 8, 5, 15, 1, 56, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)),
                            Date = new DateTime(2020, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StudentId = new Guid("f84307e8-784c-48c2-bbd6-470ec1f7555b"),
                            StudentName = "Bjarke Borg"
                        },
                        new
                        {
                            Id = new Guid("78b5e513-b9a9-423b-890c-8a47f47e1f08"),
                            Attendance = 0,
                            CheckInTimeStamp = new DateTimeOffset(new DateTime(2020, 8, 3, 7, 15, 52, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)),
                            CheckOutTimeStamp = new DateTimeOffset(new DateTime(2020, 8, 3, 15, 1, 16, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)),
                            Date = new DateTime(2020, 8, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StudentId = new Guid("8da3427c-fef2-46d1-89d1-3023de95bdf6"),
                            StudentName = "Martin Westergaard"
                        },
                        new
                        {
                            Id = new Guid("3eec7f4e-c762-4e8b-a428-1ac3faf6555b"),
                            Attendance = 0,
                            CheckInTimeStamp = new DateTimeOffset(new DateTime(2020, 8, 4, 7, 29, 25, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)),
                            CheckOutTimeStamp = new DateTimeOffset(new DateTime(2020, 8, 4, 15, 0, 13, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)),
                            Date = new DateTime(2020, 8, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StudentId = new Guid("8da3427c-fef2-46d1-89d1-3023de95bdf6"),
                            StudentName = "Martin Westergaard"
                        },
                        new
                        {
                            Id = new Guid("b7183a8f-2b40-4074-acf7-9fc0156e486f"),
                            Attendance = 0,
                            CheckInTimeStamp = new DateTimeOffset(new DateTime(2020, 8, 5, 7, 25, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)),
                            CheckOutTimeStamp = new DateTimeOffset(new DateTime(2020, 8, 5, 15, 0, 26, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)),
                            Date = new DateTime(2020, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StudentId = new Guid("8da3427c-fef2-46d1-89d1-3023de95bdf6"),
                            StudentName = "Martin Westergaard"
                        },
                        new
                        {
                            Id = new Guid("872744e1-3a52-49bf-be55-b3bd48ee3311"),
                            Attendance = 0,
                            CheckInTimeStamp = new DateTimeOffset(new DateTime(2020, 8, 3, 7, 26, 31, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)),
                            CheckOutTimeStamp = new DateTimeOffset(new DateTime(2020, 8, 3, 15, 6, 21, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)),
                            Date = new DateTime(2020, 8, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StudentId = new Guid("2c25b0db-1a09-4f84-94e3-c7a4a3c11ee3"),
                            StudentName = "Claus Bruun Kirkegaard"
                        },
                        new
                        {
                            Id = new Guid("451c0f3d-5ad7-4fda-b94d-1870703104d4"),
                            Attendance = 0,
                            CheckInTimeStamp = new DateTimeOffset(new DateTime(2020, 8, 4, 7, 17, 5, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)),
                            CheckOutTimeStamp = new DateTimeOffset(new DateTime(2020, 8, 4, 15, 0, 16, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)),
                            Date = new DateTime(2020, 8, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StudentId = new Guid("2c25b0db-1a09-4f84-94e3-c7a4a3c11ee3"),
                            StudentName = "Claus Bruun Kirkegaard"
                        },
                        new
                        {
                            Id = new Guid("9e578d4a-695f-4256-a0b1-2e84537537d7"),
                            Attendance = 0,
                            CheckInTimeStamp = new DateTimeOffset(new DateTime(2020, 8, 5, 7, 16, 26, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)),
                            CheckOutTimeStamp = new DateTimeOffset(new DateTime(2020, 8, 5, 15, 2, 17, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)),
                            Date = new DateTime(2020, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StudentId = new Guid("2c25b0db-1a09-4f84-94e3-c7a4a3c11ee3"),
                            StudentName = "Claus Bruun Kirkegaard"
                        },
                        new
                        {
                            Id = new Guid("6fe288da-404b-4ea0-84d6-108aebc0b089"),
                            Attendance = 0,
                            CheckInTimeStamp = new DateTimeOffset(new DateTime(2020, 8, 3, 7, 23, 58, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)),
                            CheckOutTimeStamp = new DateTimeOffset(new DateTime(2020, 8, 3, 15, 2, 33, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)),
                            Date = new DateTime(2020, 8, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StudentId = new Guid("1f5a8482-9578-4eae-8c75-d0d715d19399"),
                            StudentName = "Henrik Krog Thorsen"
                        },
                        new
                        {
                            Id = new Guid("c65003fe-77b5-4e0a-bc82-8890c880206b"),
                            Attendance = 0,
                            CheckInTimeStamp = new DateTimeOffset(new DateTime(2020, 8, 4, 7, 27, 57, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)),
                            CheckOutTimeStamp = new DateTimeOffset(new DateTime(2020, 8, 4, 15, 1, 12, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)),
                            Date = new DateTime(2020, 8, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StudentId = new Guid("1f5a8482-9578-4eae-8c75-d0d715d19399"),
                            StudentName = "Henrik Krog Thorsen"
                        },
                        new
                        {
                            Id = new Guid("46bdbdc4-1760-4dcc-a09e-5e57805c49ae"),
                            Attendance = 0,
                            CheckInTimeStamp = new DateTimeOffset(new DateTime(2020, 8, 5, 7, 21, 23, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)),
                            CheckOutTimeStamp = new DateTimeOffset(new DateTime(2020, 8, 5, 15, 0, 16, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)),
                            Date = new DateTime(2020, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StudentId = new Guid("1f5a8482-9578-4eae-8c75-d0d715d19399"),
                            StudentName = "Henrik Krog Thorsen"
                        },
                        new
                        {
                            Id = new Guid("a5cdae63-3bba-4b10-920b-1003306530db"),
                            Attendance = 0,
                            CheckInTimeStamp = new DateTimeOffset(new DateTime(2020, 8, 3, 7, 11, 54, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)),
                            CheckOutTimeStamp = new DateTimeOffset(new DateTime(2020, 8, 3, 15, 1, 24, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)),
                            Date = new DateTime(2020, 8, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StudentId = new Guid("1ce22baf-3ca5-48c3-8117-a7d7cd323ef9"),
                            StudentName = "Axel Bech"
                        },
                        new
                        {
                            Id = new Guid("7d4d021e-aa3c-4f77-beff-f8de2ccc1390"),
                            Attendance = 0,
                            CheckInTimeStamp = new DateTimeOffset(new DateTime(2020, 8, 4, 7, 26, 42, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)),
                            CheckOutTimeStamp = new DateTimeOffset(new DateTime(2020, 8, 4, 15, 0, 34, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)),
                            Date = new DateTime(2020, 8, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StudentId = new Guid("1ce22baf-3ca5-48c3-8117-a7d7cd323ef9"),
                            StudentName = "Axel Bech"
                        },
                        new
                        {
                            Id = new Guid("db44ce8c-5c36-455f-85cb-f0ba2738926c"),
                            Attendance = 0,
                            CheckInTimeStamp = new DateTimeOffset(new DateTime(2020, 8, 5, 7, 24, 46, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)),
                            CheckOutTimeStamp = new DateTimeOffset(new DateTime(2020, 8, 5, 15, 0, 16, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)),
                            Date = new DateTime(2020, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StudentId = new Guid("1ce22baf-3ca5-48c3-8117-a7d7cd323ef9"),
                            StudentName = "Axel Bech"
                        },
                        new
                        {
                            Id = new Guid("ee0d79f8-b3db-4af8-aa0b-3cdc55cca039"),
                            Attendance = 0,
                            CheckInTimeStamp = new DateTimeOffset(new DateTime(2020, 8, 3, 7, 23, 51, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)),
                            CheckOutTimeStamp = new DateTimeOffset(new DateTime(2020, 8, 3, 15, 5, 35, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)),
                            Date = new DateTime(2020, 8, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StudentId = new Guid("33e425d4-7ab4-4d0e-9c8f-c69d7a56baa6"),
                            StudentName = "Anders Ilesen"
                        },
                        new
                        {
                            Id = new Guid("0cfc589f-6340-41c4-a826-24283d656227"),
                            Attendance = 0,
                            CheckInTimeStamp = new DateTimeOffset(new DateTime(2020, 8, 4, 7, 26, 32, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)),
                            CheckOutTimeStamp = new DateTimeOffset(new DateTime(2020, 8, 4, 15, 1, 47, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)),
                            Date = new DateTime(2020, 8, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StudentId = new Guid("33e425d4-7ab4-4d0e-9c8f-c69d7a56baa6"),
                            StudentName = "Anders Ilesen"
                        },
                        new
                        {
                            Id = new Guid("5f99d0e6-f71b-4ec3-8973-7ebd113b03a4"),
                            Attendance = 0,
                            CheckInTimeStamp = new DateTimeOffset(new DateTime(2020, 8, 5, 7, 21, 23, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)),
                            CheckOutTimeStamp = new DateTimeOffset(new DateTime(2020, 8, 5, 15, 3, 21, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)),
                            Date = new DateTime(2020, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StudentId = new Guid("33e425d4-7ab4-4d0e-9c8f-c69d7a56baa6"),
                            StudentName = "Anders Ilesen"
                        },
                        new
                        {
                            Id = new Guid("22530fbd-569a-492c-be29-99b55858d421"),
                            Attendance = 0,
                            CheckInTimeStamp = new DateTimeOffset(new DateTime(2020, 8, 3, 7, 23, 51, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)),
                            CheckOutTimeStamp = new DateTimeOffset(new DateTime(2020, 8, 3, 15, 5, 35, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)),
                            Date = new DateTime(2020, 8, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StudentId = new Guid("e95f208d-2f31-4796-a2a0-64f2fe5c7c97"),
                            StudentName = "Lars Larsen"
                        },
                        new
                        {
                            Id = new Guid("f03141fd-ef0e-46d6-8adb-d25182b56f6a"),
                            Attendance = 0,
                            CheckInTimeStamp = new DateTimeOffset(new DateTime(2020, 8, 4, 7, 26, 32, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)),
                            CheckOutTimeStamp = new DateTimeOffset(new DateTime(2020, 8, 4, 15, 1, 47, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)),
                            Date = new DateTime(2020, 8, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StudentId = new Guid("e95f208d-2f31-4796-a2a0-64f2fe5c7c97"),
                            StudentName = "Lars Larsen"
                        },
                        new
                        {
                            Id = new Guid("1a128961-d3cc-490a-b0e3-c45171afeb27"),
                            Attendance = 0,
                            CheckInTimeStamp = new DateTimeOffset(new DateTime(2020, 8, 5, 7, 21, 23, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)),
                            CheckOutTimeStamp = new DateTimeOffset(new DateTime(2020, 8, 5, 15, 3, 21, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)),
                            Date = new DateTime(2020, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StudentId = new Guid("e95f208d-2f31-4796-a2a0-64f2fe5c7c97"),
                            StudentName = "Lars Larsen"
                        });
                });

            modelBuilder.Entity("Core.Model.Student", b =>
                {
                    b.HasOne("Core.Model.Admin", "DeletedBy")
                        .WithMany()
                        .HasForeignKey("DeletedById");
                });

            modelBuilder.Entity("Core.Model.StudentCheckIn", b =>
                {
                    b.HasOne("Core.Model.Student", "Student")
                        .WithMany("StudentCheckIns")
                        .HasForeignKey("StudentId");
                });
#pragma warning restore 612, 618
        }
    }
}