using SpaceInfo.NasaService.Models.NasaSearch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SpaceInfo.Application.SearchService.Dtos
{
    public class NasaImageResponseDto
    {
        [JsonPropertyName("collection")]
        public NasaSearchCollectionImageDto Collection { get; set; }
    }
}
