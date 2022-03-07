using Core.Model;
using Web.Services.Base;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Web.Services
{
    public class CheckInService : BaseService
    {
        public CheckInService(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<List<Student>> GetStudentsWithCheckInsForSelectedWeekAsync(string departmentName, DateTime[] dates) // week / list of days
        {
            string queryDates = "";
            foreach (var d in dates)
            {
                queryDates += $"selectedDays={d.Date.ToShortDateString()}&";
            }

            using (var client = new HttpClient())
            {
                var endPoint = ApiIP + $"/api/studentcheckins/?departmentName={departmentName}&{queryDates}";
                var content = await client.GetStringAsync(endPoint);

                return JsonConvert.DeserializeObject<List<Student>>(content);
            }
        }

        public async Task<Student> ManuelStudenCheckIn(Core.Model.StudentCheckIn checkinstudent)
        {
            Student student = new Student();
            student.FirstName = checkinstudent.StudentName.Substring(0, checkinstudent.StudentName.IndexOf(" "));
            student.LastName = checkinstudent.StudentName.Substring(checkinstudent.StudentName.IndexOf(" ")+1);
            using (var client = new HttpClient())
            {
                var endPoint = ApiIP + $"/api/StudentCheckins";
                var content = new StringContent(JsonConvert.SerializeObject(student), System.Text.Encoding.UTF8, "application/json");

                var response = await client.PostAsync(endPoint, content);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<Student>(result);
                }

                return null;
            }
        }

        public async Task<StudentCheckIn> ManuelStudenLateTooOnTime(StudentCheckIn checkinstudent)
        {
            using (var client = new HttpClient())
            {
                var endPoint = ApiIP + $"/api/StudentCheckins/ManuelStudenLateTooOnTime";
                var content = new StringContent(JsonConvert.SerializeObject(checkinstudent), System.Text.Encoding.UTF8, "application/json");

                var response = await client.PostAsync(endPoint, content);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<StudentCheckIn>(result);
                }

                return null;
            }
        }
    }
}
