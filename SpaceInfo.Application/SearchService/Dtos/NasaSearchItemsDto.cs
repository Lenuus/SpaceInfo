using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SpaceInfo.NasaService.Models.NasaSearch
{
    public class NasaSearchItemsDto
    {
        [JsonPropertyName("href")]
        public string Href { get; set; }

        [JsonPropertyName("data")]
        public List<NasaSearchItemDataDto> SearchItemData { get; set; }
    }
}
