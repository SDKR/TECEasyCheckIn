using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Model
{
    public class Instructor
    {
        public Guid Id { get; set; }
        public string Initials { get; set; }
        public Guid DepartmentId { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public Department Department { get; set; }
        public List<Student> Students { get; set; }
    }
}
