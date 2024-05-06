using Microsoft.AspNetCore.Mvc;
using SpaceInfo.Application.SearchService;
using SpaceInfo.Application.SearchService.NasaSearch;

namespace SpaceInfo.Controllers
{
    public class NasaSearchController : Controller
    {
        private readonly INasaSearchService _searchService;

        public NasaSearchController(INasaSearchService searchService)
        {
            _searchService = searchService;
        }
        [HttpPost("search-nasa-item")]
        public async Task<IActionResult> GetSearchMaterials([FromBody] NasaSearchRequestDto request)
        {
            var response = await _searchService.GetSearchMaterials(request).ConfigureAwait(false);
            if (!response.IsSuccesfull)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPost("get-nasa-item-images")]
        public async Task<IActionResult> GetNasaImages([FromBody] string request)
        {
            var response = await _searchService.GetDataImages(request).ConfigureAwait(false);
            if (!response.IsSuccesfull)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
    }
}
