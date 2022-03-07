using Core.Model;
using Web.Services.Base;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Web.Services
{
    public class DepartmentsService : BaseService
    {
        public DepartmentsService(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<Department> GetDepartmentAsync(string departmentID)
        {
            Guid elId = Guid.Parse(departmentID);
            using (var client = new HttpClient())
            {
                var endPoint = ApiIP + "/api/departments/" + elId;
                var response = await client.GetAsync(endPoint);
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Department>(content);
            }
        }

        public async Task<List<Department>> GetAllDepartmentsAsync()
        {
            using (var client = new HttpClient())
            {
                var endPoint = ApiIP + "/api/departments";
                var response = await client.GetAsync(endPoint);
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Department>>(content);
            }
        }

        public async Task<Department> CreateDepartment(Department department)
        {
            using (var client = new HttpClient())
            {
                var endPoint = ApiIP + "/api/departments";
                var content = new StringContent(JsonConvert.SerializeObject(department), System.Text.Encoding.UTF8, "application/json");

                var response = await client.PostAsync(endPoint, content);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<Department>(result);
                }
                if (response.StatusCode == System.Net.HttpStatusCode.Conflict)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<Department>(result);
                }

                return null;
            }
        }

        public async Task<Department> UpdateDepartment(Department department)
        {
            Guid id = department.Id;

            using (var client = new HttpClient())
            {
                var endPoint = ApiIP + "/api/departments/" + id;
                var content = new StringContent(JsonConvert.SerializeObject(department), System.Text.Encoding.UTF8, "application/json");
                var response = await client.PutAsync(endPoint, content);
            

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<Department>(result);
                }
                if (response.StatusCode == System.Net.HttpStatusCode.Conflict)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<Department>(result);
                }
                
                return null;
            }   

        }

        public async Task<Department> DeleteDepartment(Guid departmentID)
        {

            using (var client = new HttpClient())
            {
                var endPoint = ApiIP + "/api/departments/" + departmentID;
                var response = await client.DeleteAsync(endPoint);


                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<Department>(result);
                }
                //if (response.StatusCode == System.Net.HttpStatusCode.Conflict)
                //{
                //    var result = await response.Content.ReadAsStringAsync();s
                //    return JsonConvert.DeserializeObject<Department>(result);
                //}

                return null;
            }

        }


    }
}
