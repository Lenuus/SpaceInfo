using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SpaceInfo.NasaService.Models.NearObject
{
    public class RelativeVelocityModel
    {
        [JsonPropertyName("kilometers_per_second")]
        public string KilometersPerSecond { get; set; } 

        [JsonPropertyName("kilometers_per_hour")]
        public string KilometersPerHour { get; set; } 

        [JsonPropertyName("miles_per_hour")]
        public string MilesPerHour { get; set; } 

    }
}
