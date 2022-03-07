using Core.Model;
using Web.Services.Base;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Web.Services
{
    public class StudentsService : BaseService
    {
        public StudentsService(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<List<Student>> GetAllStudentsByDepartmentAsync(string departmentName)
        {
            using (var client = new HttpClient())
            {
                var endPoint = ApiIP + "/api/students/?departmentName="+ departmentName;
                var content = await client.GetStringAsync(endPoint);

                return JsonConvert.DeserializeObject<List<Student>>(content);
            }
        }

        public async Task<List<List<Student>>> GetReplaceStudentsChanges(List<Student> students)
        {
            using (var client = new HttpClient())
            {
                var endPoint = ApiIP + "/api/students/bulkreplacechanges";
                var content = new StringContent(JsonConvert.SerializeObject(students), System.Text.Encoding.UTF8, "application/json");

                var response = await client.PutAsync(endPoint, content);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<List<Student>>>(result);
                }

                return null;
            }
        }

        public async Task<List<List<Student>>> CreateStudents(List<Student> students)
        {
            using (var client = new HttpClient())
            {
                var endPoint = ApiIP + "/api/students/bulkinsert";
                var content = new StringContent(JsonConvert.SerializeObject(students), System.Text.Encoding.UTF8, "application/json");

                var response = await client.PostAsync(endPoint, content);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<List<Student>>>(result);
                }

                return null;
            }
        }

        public async Task<Student> UpdateStudent(Student student)
        {
            using (var client = new HttpClient())
            {
                var endPoint = ApiIP + "/api/students/" + student.Id;
                var content = new StringContent(JsonConvert.SerializeObject(student), System.Text.Encoding.UTF8, "application/json");

                var response = await client.PutAsync(endPoint, content);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<Student>(result);
                }

                return null;
            }
        }

        public async Task<List<List<Student>>> ReplaceStudents(List<Student> students)
        {
            using (var client = new HttpClient())
            {
                var endPoint = ApiIP + "/api/students/bulkreplace";
                var content = new StringContent(JsonConvert.SerializeObject(students), System.Text.Encoding.UTF8, "application/json");

                var response = await client.PutAsync(endPoint, content);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<List<Student>>>(result);
                }

                return null;
            }
        }

        public async Task<Student> DeleteStudent(Student student)
        {
            using (var client = new HttpClient())
            {
                var endPoint = ApiIP + "/api/students/" + student.Id;
                var response = await client.DeleteAsync(endPoint);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<Student>(result);
                }

                return null;
            }
        }
    }
}
