using SpaceInfo.NasaService.Models.NasaSearch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SpaceInfo.Application.SearchService.Dtos
{
    public class NasaSearchCollectionImageDto
    {

        [JsonPropertyName("version")]
        public string Version { get; set; }

        [JsonPropertyName("href")]
        public string Href { get; set; }

        [JsonPropertyName("items")]
        public List<NasaMediaItemsDto> MediaItems { get; set; }
    }
}
