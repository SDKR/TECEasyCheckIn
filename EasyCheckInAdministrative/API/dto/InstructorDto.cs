using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.dto
{
    public class InstructorDto
    {
        public string Initials { get; set; }
        public string DepartmentName { get; set; }
        public Guid DepartmentId { get; set; }
        public Guid Id { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
