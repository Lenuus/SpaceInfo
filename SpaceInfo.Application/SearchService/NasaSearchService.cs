using SpaceInfo.Application.SearchService.NasaSearch;
using SpaceInfo.NasaService.Models.NasaSearch;
using SpaceInfosTracker.Common.Dtos;
using SpaceInfosTracker.Common.Helpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpaceInfo.Application.SearchService.Dtos;

namespace SpaceInfo.Application.SearchService
{
    public class NasaSearchService : INasaSearchService
    {

        public async Task<ServiceResponse<PagedResponseDto<NasaSearchItemDataDto>>> GetSearchMaterials(NasaSearchRequestDto search)
        {
            if (string.IsNullOrEmpty(search.Search))
            {
                search.Search = "Space";
            }
            var apiUrl = $"https://images-api.nasa.gov/search?q={search.Search}";

            using (var client = new HttpClient())
            {
                using (var response = await client.GetAsync(apiUrl))
                {
                    if (!response.IsSuccessStatusCode)
                    {
                        return new ServiceResponse<PagedResponseDto<NasaSearchItemDataDto>>(null, false, "Cannot be reached");
                    }
                    var content = await response.Content.ReadAsStringAsync();
                    var searchItems = System.Text.Json.JsonSerializer.Deserialize<NasaSearchResponseDto>(content);

                    var nasaSearchCollection = searchItems.Collection.SearchItems
                        .SelectMany(item => item.SearchItemData)
                        .ToList();

                    var pagedList = await nasaSearchCollection
                        .ToPagedListAsync(search.PageSize, search.PageIndex);

                    return new ServiceResponse<PagedResponseDto<NasaSearchItemDataDto>>(pagedList, true, "Success");
                }
            }
        }

        public async Task<ServiceResponse<NasaImageResponseDto>> GetDataImages(DataImageRequestDto request)
        {
            var apiUrl = $"https://images-api.nasa.gov/asset/{request.NasaId}";

            using (var client = new HttpClient())
            {
                using (var response = await client.GetAsync(apiUrl))
                {
                    if (!response.IsSuccessStatusCode)
                    {
                        return new ServiceResponse<NasaImageResponseDto>(null, false, "Cannot be reached");
                    }
                    var content = await response.Content.ReadAsStringAsync();
                    var itemsImages = System.Text.Json.JsonSerializer.Deserialize<NasaImageResponseDto>(content);

                    return new ServiceResponse<NasaImageResponseDto>(itemsImages, true, string.Empty);
                }
            }
        }


    }
}
