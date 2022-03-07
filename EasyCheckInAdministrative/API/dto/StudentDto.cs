using Core.Model;
using Core.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.dto
{
    public class StudentDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Guid DepartmentId { get; set; }
        public Guid InstructorId { get; set; }
        public StudentStatus Status { get; set; }
        public string StatusComment { get; set; }
        public string CardName { get; set; }
        public bool IsDeleted { get; set; }
        public DateTimeOffset? DeletedOn { get; set; }
        public Guid? DeletedById { get; set; }
    }
}
