using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SpaceInfo.NasaService.Models.NasaSearch
{
    public class SearchItemDataModel
    {
        [JsonPropertyName("center")]
        public string Center { get; set; }

        [JsonPropertyName("date_created")]
        public DateTime CreatedDate { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("keywords")]
        public List<string> Keywords { get; set; }

        [JsonPropertyName("media_type")]
        public string MediaType { get; set; }

        [JsonPropertyName("nasa_id")]
        public string NasaId { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }
    }
}
