using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SpaceInfo.NasaService.Models.NearObject
{
    public class LinksModel
    {
        [JsonPropertyName("previous")]
        public string Previous { get; set; }

        [JsonPropertyName("next")]
        public string Next { get; set; }

        [JsonPropertyName("self")]
        public string Self { get; set; }
    }
}
