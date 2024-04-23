using SpaceInfo.NasaService.SpaceInfo.NasaService.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SpaceInfo.NasaService.Models.NearObject
{
    public class NearEarthObjectModel
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("neo_reference_id")]
        public string NeoReferenceId { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("nasa_jpl_url")]
        public string? NasaJplUrl { get; set; }

        [JsonPropertyName("absolute_magnitude_h")]
       // [JsonConverter(typeof(DoubleToString))]
        public double AbsoluteMagnitudeH { get; set; }

        [JsonPropertyName("estimated_diameter")]
        public DiameterModel Diameter { get; set; }

        [JsonPropertyName("is_potentially_hazardous_asteroid")]
        public bool IsPotentiallyHazardous { get; set; }

        [JsonPropertyName("close_approach_data")]
        public List<CloseApproachDataModel> CloseApproachDataModel { get; set; } = new List<CloseApproachDataModel>();

        [JsonPropertyName("links")]
        public LinksModel Links { get; set; }
    }
}
