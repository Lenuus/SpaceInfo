using SpaceInfo.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInfo.Application.SearchService.NasaSearch
{
    public class NasaSearchRequestDto : PagedRequestDto
    {
        public string Search { get; set; }
    }
}
