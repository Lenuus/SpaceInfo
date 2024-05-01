using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SpaceInfo.NasaService.Models.NasaSearch
{
    public class NasaSearchCollectionDto
    {
        [JsonPropertyName("version")]
        public string Version { get; set; }

        [JsonPropertyName("href")]
        public string Href { get; set; }

        [JsonPropertyName("items")]
        public List<SearchItemsDto> SearchItems { get; set; }
    }
}
