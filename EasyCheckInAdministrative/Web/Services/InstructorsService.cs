using Core.Model;
using Web.Services.Base;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Web.Services
{
    public class InstructorsService : BaseService
    {
        public InstructorsService(IConfiguration configuration) : base(configuration)
        {
        }


        public async Task<List<Instructor>> GetAllInstructorsByDepartmentAsync(string departmentName)
        {
            using (var client = new HttpClient())
            {
                var endPoint = ApiIP + "/api/instructors/byDepartment/" + departmentName;
                var content = await client.GetStringAsync(endPoint);

                return JsonConvert.DeserializeObject<List<Instructor>>(content);
            }
        }

        public async Task<List<List<Instructor>>> CreateInstructor(List<Instructor> instructors)
        {
            using (var client = new HttpClient())
            {
                var endPoint = ApiIP + "/api/instructors/bulkinsert";
                var content = new StringContent(JsonConvert.SerializeObject(instructors), System.Text.Encoding.UTF8, "application/json");

                var response = await client.PostAsync(endPoint, content);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<List<Instructor>>>(result);
                }

                if (response.StatusCode == System.Net.HttpStatusCode.Conflict)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    List<List<Instructor>> nullliste = new List<List<Instructor>>();
                    return nullliste;
                }

                return null;
            }
        }

        public async Task<Instructor> UpdateInstructor(Instructor instructor)
        {
            using (var client = new HttpClient())
            {
                var endPoint = ApiIP + "/api/instructors/Update";
                var content = new StringContent(JsonConvert.SerializeObject(instructor), System.Text.Encoding.UTF8, "application/json");

                var response = await client.PostAsync(endPoint, content);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<Instructor>(result);
                }
                if (response.StatusCode == System.Net.HttpStatusCode.Conflict)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<Instructor>(result);
                }

                return null;
            }
        }

        public async Task<Instructor> DeleteInstructor(Instructor instructor)
        {
            using (var client = new HttpClient())
            {
                var endPoint = ApiIP + "/api/instructors/Delete/"+ instructor.Id;
                //var content = new StringContent(JsonConvert.SerializeObject(instructors), System.Text.Encoding.UTF8, "application/json");
                
                var response = await client.DeleteAsync(endPoint);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<Instructor>(result);
                }

                return null;
            }
        }

        public async Task<List<Instructor>> GetAllInstructors()
        {
            using (var client = new HttpClient())
            {
                var endPoint = ApiIP + "/api/instructors";
                var content = await client.GetStringAsync(endPoint);

                return JsonConvert.DeserializeObject<List<Instructor>>(content);
            }
        }
    }
}
