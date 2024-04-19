using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using SpaceInfo.Application;
using SpaceInfo.NasaService.Models.DailyInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SpaceInfo.NasaService.Services
{
    public class NasaService : INasaService
    {
        private readonly IConfiguration _configuration;

        public NasaService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<ServiceResponse<List<DailyInfoModel>>> GetDailyInfos(DateTime date)
        {
            var infos = new List<DailyInfoModel>();
            DateTime startDate = date.AddDays(-10);
            DateTime endDate = startDate.AddDays(10);
            using (var client = new HttpClient())
            {
                var apiKey = _configuration["NasaUserId"];
                using (var response = await client.GetAsync($"https://api.nasa.gov/planetary/apod?start_date={startDate:yyyy-MM-dd}&end_date={endDate:yyyy-MM-dd}&api_key={apiKey}"))
                {
                    if (response.StatusCode != System.Net.HttpStatusCode.OK)
                    {
                        return new ServiceResponse<List<DailyInfoModel>>(null, false, "Could not recieved");
                    }
                    var content = await response.Content.ReadAsStringAsync();
                    // var data = JsonConvert.DeserializeObject<List<DailyInfoModel>>(content);
                    var data = System.Text.Json.JsonSerializer.Deserialize<List<DailyInfoModel>>(content);
                    infos.AddRange(data);
                }
            }
            return new ServiceResponse<List<DailyInfoModel>>(infos, true, string.Empty);
        }
    }
}
