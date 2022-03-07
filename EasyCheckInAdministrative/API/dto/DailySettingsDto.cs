using System;

namespace API.dto
{
    public class DailySettingsDto
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public DateTimeOffset LastestCheckInTimeStamp { get; set; }
        public DateTimeOffset EarliestCheckOutTimeStamp { get; set; }
        public Guid DepartmentId { get; set; }
    }
}
