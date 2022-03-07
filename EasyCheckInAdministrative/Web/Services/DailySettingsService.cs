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
    public class DailySettingsService : BaseService
    {
        public DailySettingsService(IConfiguration configuration) : base(configuration)
        {
        }


        public async Task<List<DailySettings>> GetDefaultDailySettingsAsync(string departmentName)
        {
            
            using (var client = new HttpClient())
            {
                var endPoint = ApiIP + "/api/dailysettings/defaults/" + departmentName;
                var content = await client.GetStringAsync(endPoint);

                return JsonConvert.DeserializeObject<List<DailySettings>>(content);
            }
        }
        public async Task<List<DailySettings>> GetDailySettingsForSelectedWeekAsync(string departmentName, DateTime[] dates)
        {
            string queryDates = "";
            foreach (var d in dates)
            {
                queryDates += $"selectedDays={d.Date.ToShortDateString()}&";
            }
            using (var client = new HttpClient())
            {
                var endPoint = ApiIP + "/api/dailysettings/forWeek/"+ departmentName + "/?" + queryDates;
                var content = await client.GetStringAsync(endPoint);

                return JsonConvert.DeserializeObject<List<DailySettings>>(content);
            }
        }

        public async Task<List<DailySettings>> UpdateDefaultDailySettingsAsync(List<DailySettings> settings)
        {
            using (var client = new HttpClient())
            {
                var endPoint = ApiIP + "/api/dailysettings/";
                var content = new StringContent(JsonConvert.SerializeObject(settings), System.Text.Encoding.UTF8, "application/json");
                var response = await client.PutAsync(endPoint, content);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<DailySettings>>(result);
                }

                return null;
            }
        }

        public async Task<DailySettings> UpdateDailySettingsForSelectedDayAsync(DailySettings settings)
        {
            using (var client = new HttpClient())
            {
                var endPoint = ApiIP + "/api/dailysettings/" + settings.Id;
                var content = new StringContent(JsonConvert.SerializeObject(settings), System.Text.Encoding.UTF8, "application/json");
                var response = await client.PutAsync(endPoint, content);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<DailySettings>(result);
                }

                return null;
            }
        }

        public async Task<List<DailySettings>> UpdateDailySettingsForSelectedWeekAsync(List<DailySettings> settings)
        {
            using (var client = new HttpClient())
            {
                var endPoint = ApiIP + "/api/dailysettings/";
                var content = new StringContent(JsonConvert.SerializeObject(settings), System.Text.Encoding.UTF8, "application/json");
                var response = await client.PutAsync(endPoint, content);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<DailySettings>>(result);
                }

                return null;
            }
        }
    }
}
