using Microsoft.AspNetCore.Mvc;
using SpaceInfo.Application.DailyInfoService;

namespace SpaceInfo.Controllers
{
    public class DailyInfoController : Controller
    {

        private readonly IDailyInfoService _dailyInfoService;

        public DailyInfoController(IDailyInfoService dailyInfoService)
        {
            _dailyInfoService = dailyInfoService;
        }

        [HttpPost("daily-infos")]
        public async Task<IActionResult> GetAllInfos()
        {
            var response = await _dailyInfoService.GetAllInfos().ConfigureAwait(false);
            if (!response.IsSuccesfull)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPost("get-random-daily-info")]
        public async Task<IActionResult> GetRandomDailyInfo()
        {
            var response = await _dailyInfoService.GetRandomDailyInfo().ConfigureAwait(false);
            if (!response.IsSuccesfull)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
    }
}
