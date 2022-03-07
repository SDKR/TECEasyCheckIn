using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.dto
{
    public class CheckInOutDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public DateTime Date => DateTime.Today;
        public DateTimeOffset TimeStamp => DateTimeOffset.Now;
    }
}
