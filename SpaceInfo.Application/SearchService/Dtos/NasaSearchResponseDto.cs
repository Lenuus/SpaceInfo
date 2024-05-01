using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SpaceInfo.NasaService.Models.NasaSearch
{
    public class NasaSearchResponseDto
    {
        [JsonPropertyName("collection")]
        public NasaSearchCollectionDto Collection { get; set; }
    }
}
