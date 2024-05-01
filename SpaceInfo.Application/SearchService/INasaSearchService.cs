using SpaceInfo.Application.SearchService.NasaSearch;
using SpaceInfo.NasaService.Models.NasaSearch;
using SpaceInfosTracker.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInfo.Application.SearchService
{
    public interface INasaSearchService
    {
        Task<ServiceResponse<PagedResponseDto<SearchItemDataDto>>> GetSearchMaterials(NasaSearchRequestDto search);
    }
}
