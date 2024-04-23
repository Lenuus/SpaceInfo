using System.Text.Json.Serialization;

namespace SpaceInfo.NasaService.Models.NearObject
{
    public class DiameterModel
    {
        [JsonPropertyName("kilometers")]
        public KilometersModel Kilometers { get; set; }

        [JsonPropertyName("meters")]
        public MetersModel Meters { get; set; }

        [JsonPropertyName("miles")]
        public MilesModel Miles { get; set; }

        [JsonPropertyName("feet")]
        public FeetModel Feet { get; set; }
    }
}