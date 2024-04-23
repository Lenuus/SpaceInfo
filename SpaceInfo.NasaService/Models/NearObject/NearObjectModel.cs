using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SpaceInfo.NasaService.Models.NearObject
{
    public class NearObjectModel
    {
        [JsonPropertyName("links")]
        public LinksModel Links { get; set; }

        [JsonPropertyName("element_count")]
        public int ElementCount { get; set; }

        [JsonPropertyName("near_earth_objects")]
        public Dictionary<string, List<NearEarthObjectModel>> NearEarthObjects { get; set; }
    }
}
