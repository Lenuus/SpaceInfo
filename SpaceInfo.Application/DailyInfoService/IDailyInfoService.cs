using SpaceInfo.Application.DailyInfoService.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInfo.Application.DailyInfoService
{
    public interface IDailyInfoService
    {
        public Task<ServiceResponse<List<DailyInfoDto>>> GetAllInfos();
        public Task<ServiceResponse<DailyInfoDto>> GetRandomDailyInfo();

    }
}
