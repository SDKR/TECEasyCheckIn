using Core.Model.Base;
using Core.Model.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Model
{
    public class Student : IEntity, IDeletableEntity
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [NotMapped]
        public string FullName => $"{FirstName} {LastName}";
        [ForeignKey("Department")]
        public Guid DepartmentId { get; set; }
        public Department Department { get; set; }
        [ForeignKey("Instructor")]
        public Guid InstructorId { get; set; }
        public Instructor Instructor { get; set; }
        public StudentStatus Status { get; set; }
        public string StatusComment { get; set; }
        public string CardName { get; set; }
        public bool IsDeleted { get; set; }
        public DateTimeOffset? DeletedOn { get; set; }
        [ForeignKey("Admin")]
        public Guid? DeletedById { get; set; }
        public Admin DeletedBy { get; set; }
        public List<StudentCheckIn> StudentCheckIns { get; set; }
    }
}
