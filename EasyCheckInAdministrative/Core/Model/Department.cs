using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Model
{
    public class Department
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Instructor> Instructors { get; set; }
    }
}
