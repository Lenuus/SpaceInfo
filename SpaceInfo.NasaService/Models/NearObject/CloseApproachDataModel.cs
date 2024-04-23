using Newtonsoft.Json;
using SpaceInfo.NasaService.SpaceInfo.NasaService.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SpaceInfo.NasaService.Models.NearObject
{
    public class CloseApproachDataModel
    {
        [JsonPropertyName("close_approach_date")]
        public string CloseApproachDate { get; set; }

        [JsonPropertyName("close_approach_date_full")]
        public string CloseApproachDateFull { get; set; }

        [JsonPropertyName("epoch_date_close_approach")]
        public double EpochDateCloseApproach { get; set; } = 0;

        [JsonPropertyName("relative_velocity")]
        public RelativeVelocityModel RelativeVelocity { get; set; }

        [JsonPropertyName("miss_distance")]
        public MissDistanceModel MissDistance { get; set; }

        [JsonPropertyName("orbiting_body")]
        public string OrbitingBody { get; set; }

    }
}
