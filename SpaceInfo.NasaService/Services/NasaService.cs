using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using SpaceInfo.Application;
using SpaceInfo.NasaService.Models.DailyInfo;
using SpaceInfo.NasaService.Models.NasaSearch;
using SpaceInfo.NasaService.Models.NearObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;
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


        public async Task<ServiceResponse<List<NearEarthObjectModel>>> GetNearObjects(DateTime startDate, DateTime endDate)
        {
            var nearObjects = new List<NearEarthObjectModel>();

            try
            {
                var apiKey = _configuration["NasaUserId"];
                var apiUrl = $"https://api.nasa.gov/neo/rest/v1/feed?start_date={startDate:yyyy-MM-dd}&end_date={endDate:yyyy-MM-dd}&api_key={apiKey}";

                using (var client = new HttpClient())
                {
                    using (var response = await client.GetAsync(apiUrl))
                    {
                        if (!response.IsSuccessStatusCode)
                        {
                            return new ServiceResponse<List<NearEarthObjectModel>>(null, false, "Could not retrieve data from NASA API");
                        }

                        var content = await response.Content.ReadAsStringAsync();

                        var nearObjectData = System.Text.Json.JsonSerializer.Deserialize<NearObjectModel>(content);

                        foreach (var dateKey in nearObjectData.NearEarthObjects.Keys)
                        {
                            nearObjects.AddRange(nearObjectData.NearEarthObjects[dateKey]);
                        }
                    }
                }

                return new ServiceResponse<List<NearEarthObjectModel>>(nearObjects, true, "Near Earth objects retrieved successfully");
            }
            catch (Exception ex)
            {
                return new ServiceResponse<List<NearEarthObjectModel>>(null, false, $"An error occurred: {ex.Message}");
            }
        }

        public async Task<ServiceResponse<List<SearchItemDataModel>>> GetSearchMaterials(string search)
        {
            var nasaSearchCollection = new List<SearchItemDataModel>();
            var apiUrl = $"https://images-api.nasa.gov/search?q={search}";

            using (var client = new HttpClient())
            {
                using (var response = await client.GetAsync(apiUrl))
                {
                    if (!response.IsSuccessStatusCode)
                    {
                        return new ServiceResponse<List<SearchItemDataModel>>(null, false, "Cannot be reached");
                    }
                    var content = await response.Content.ReadAsStringAsync();
                    var searchItems = System.Text.Json.JsonSerializer.Deserialize<NasaSearchResponseModel>(content);

                    nasaSearchCollection = searchItems.Collection.SearchItems
                                  .SelectMany(item => item.SearchItemData)
                                  .ToList();
                }
            }

            return new ServiceResponse<List<SearchItemDataModel>>(nasaSearchCollection, true, "Success");
        }

    }
}
