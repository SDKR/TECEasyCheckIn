using Core.Model.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Model
{
    public class DailySettings : IEntity
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public DateTimeOffset LastestCheckInTimeStamp { get; set; }
        public DateTimeOffset EarliestCheckOutTimeStamp { get; set; }
        [ForeignKey("Department")]
        public Guid DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}
