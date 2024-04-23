using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SpaceInfo.NasaService.Models.NearObject
{
    public class MissDistanceModel
    {
        [JsonPropertyName("astronomical")]
        public string Astronomical { get; set; } 

        [JsonPropertyName("lunar")]
        public string Lunar { get; set; } 

        [JsonPropertyName("kilometers")]
        public string Kilometers { get; set; }

        [JsonPropertyName("miles")]
        public string Miles { get; set; } 
    }
}
