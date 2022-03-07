using Core.Model.Base;
using Core.Model.Enums;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Model
{
    public class StudentCheckIn : IEntity
    {
        public Guid Id { get; set; }
        public string StudentName { get; set; }
        public DateTime Date { get; set; }
        public DateTimeOffset? CheckInTimeStamp { get; set; }
        public DateTimeOffset? CheckOutTimeStamp { get; set; }
        public AttendanceStatus Attendance { get; set; }
        [ForeignKey("Student")]
        public Guid StudentId { get; set; }
        public Student Student { get; set; }
    }
}
