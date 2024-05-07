using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SpaceInfo.Application.SearchService.Dtos
{
    public class NasaMediaItemsDto
    {
        [JsonPropertyName("href")]
        public string Href { get; set; }
    }
}
