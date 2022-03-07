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
    [Migration("20200804111851_AddedSeedData")]
    partial class AddedSeedData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Core.Model.DailySettings", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("Date")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset>("EarliestCheckOutTimeStamp")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset>("LastestCheckInTimeStamp")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("Id");

                    b.ToTable("DailySettings");
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

            modelBuilder.Entity("Core.Model.StudentCheckIn", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Attendance")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("CheckInTimeStamp")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset?>("CheckOutTimeStamp")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset>("Date")
                        .HasColumnType("datetimeoffset");

                    b.Property<bool>("IsCheckedIn")
                        .HasColumnType("bit");

                    b.Property<string>("StudentName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("StudentCheckIns");

                    b.HasData(
                        new
                        {
                            Id = new Guid("c0f4025a-a33c-4537-ab05-63e4323a2a0d"),
                            Attendance = 1,
                            CheckInTimeStamp = new DateTimeOffset(new DateTime(2020, 8, 5, 7, 25, 54, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)),
                            CheckOutTimeStamp = new DateTimeOffset(new DateTime(2020, 8, 5, 15, 2, 32, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)),
                            Date = new DateTimeOffset(new DateTime(2020, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)),
                            IsCheckedIn = true,
                            StudentName = "Mikkel Hammer"
                        },
                        new
                        {
                            Id = new Guid("45cd8530-ec55-44ff-a28e-ada3dd8a2398"),
                            Attendance = 2,
                            CheckInTimeStamp = new DateTimeOffset(new DateTime(2020, 8, 5, 7, 32, 54, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)),
                            CheckOutTimeStamp = new DateTimeOffset(new DateTime(2020, 8, 5, 15, 0, 51, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)),
                            Date = new DateTimeOffset(new DateTime(2020, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)),
                            IsCheckedIn = true,
                            StudentName = "Anders Ilesen"
                        },
                        new
                        {
                            Id = new Guid("b2db7a65-a6b5-4c79-be60-b87eaae453e6"),
                            Attendance = 1,
                            CheckInTimeStamp = new DateTimeOffset(new DateTime(2020, 8, 5, 7, 27, 15, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)),
                            CheckOutTimeStamp = new DateTimeOffset(new DateTime(2020, 8, 5, 15, 1, 24, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)),
                            Date = new DateTimeOffset(new DateTime(2020, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)),
                            IsCheckedIn = true,
                            StudentName = "Sarah Hjort"
                        },
                        new
                        {
                            Id = new Guid("9c9aa717-46ff-4a69-af1c-dbb062bc4765"),
                            Attendance = 1,
                            CheckInTimeStamp = new DateTimeOffset(new DateTime(2020, 8, 5, 7, 21, 32, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)),
                            CheckOutTimeStamp = new DateTimeOffset(new DateTime(2020, 8, 5, 15, 4, 43, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)),
                            Date = new DateTimeOffset(new DateTime(2020, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)),
                            IsCheckedIn = true,
                            StudentName = "Andreas Bo"
                        },
                        new
                        {
                            Id = new Guid("5176b586-f03a-49df-af27-8f3ebb650328"),
                            Attendance = 1,
                            CheckInTimeStamp = new DateTimeOffset(new DateTime(2020, 8, 5, 7, 12, 43, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)),
                            CheckOutTimeStamp = new DateTimeOffset(new DateTime(2020, 8, 5, 15, 1, 14, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)),
                            Date = new DateTimeOffset(new DateTime(2020, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)),
                            IsCheckedIn = true,
                            StudentName = "Jens Larsen"
                        },
                        new
                        {
                            Id = new Guid("ac69a97d-d0af-41a9-8c5c-874c7fcf7a5e"),
                            Attendance = 1,
                            CheckInTimeStamp = new DateTimeOffset(new DateTime(2020, 8, 6, 7, 21, 34, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)),
                            CheckOutTimeStamp = new DateTimeOffset(new DateTime(2020, 8, 6, 15, 0, 35, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)),
                            Date = new DateTimeOffset(new DateTime(2020, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)),
                            IsCheckedIn = true,
                            StudentName = "Mikkel Hammer"
                        },
                        new
                        {
                            Id = new Guid("c52c87c8-2b19-496f-b0fe-cc1d815b666f"),
                            Attendance = 1,
                            CheckInTimeStamp = new DateTimeOffset(new DateTime(2020, 8, 6, 7, 21, 46, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)),
                            CheckOutTimeStamp = new DateTimeOffset(new DateTime(2020, 8, 6, 15, 3, 51, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)),
                            Date = new DateTimeOffset(new DateTime(2020, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)),
                            IsCheckedIn = true,
                            StudentName = "Anders Ilesen"
                        },
                        new
                        {
                            Id = new Guid("a8387616-dd1c-4406-8c77-6d82ec3d1716"),
                            Attendance = 1,
                            CheckInTimeStamp = new DateTimeOffset(new DateTime(2020, 8, 6, 7, 23, 58, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)),
                            CheckOutTimeStamp = new DateTimeOffset(new DateTime(2020, 8, 6, 15, 0, 24, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)),
                            Date = new DateTimeOffset(new DateTime(2020, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)),
                            IsCheckedIn = true,
                            StudentName = "Sarah Hjort"
                        },
                        new
                        {
                            Id = new Guid("0fab1c5d-8e6c-4b64-b457-9751ea483688"),
                            Attendance = 1,
                            CheckInTimeStamp = new DateTimeOffset(new DateTime(2020, 8, 6, 7, 14, 16, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)),
                            CheckOutTimeStamp = new DateTimeOffset(new DateTime(2020, 8, 6, 15, 0, 43, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)),
                            Date = new DateTimeOffset(new DateTime(2020, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)),
                            IsCheckedIn = true,
                            StudentName = "Andreas Bo"
                        },
                        new
                        {
                            Id = new Guid("af0f579c-14e7-45bb-98d2-d65246902acb"),
                            Attendance = 2,
                            CheckInTimeStamp = new DateTimeOffset(new DateTime(2020, 8, 6, 7, 32, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)),
                            Date = new DateTimeOffset(new DateTime(2020, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)),
                            IsCheckedIn = true,
                            StudentName = "Jens Larsen"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
