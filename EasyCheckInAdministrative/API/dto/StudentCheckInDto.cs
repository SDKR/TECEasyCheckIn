using Core.Model.Enums;
using System;

namespace API.dto
{
    public class StudentCheckInDto
    {
        public Guid StudentId { get; set; }
        public string StudentName { get; set; }
        public DateTime Date { get; set; }
        public DateTimeOffset CheckInTimeStamp { get; set; }
        public DateTimeOffset CheckOutTimeStamp { get; set; }
        public bool IsCheckedIn { get; set; }
        public AttendanceStatus Attendance { get; set; }
    }
}
