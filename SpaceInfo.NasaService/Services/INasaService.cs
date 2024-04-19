using SpaceInfo.Application;
using SpaceInfo.NasaService.Models.DailyInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInfo.NasaService.Services
{
    public interface INasaService
    {
        Task<ServiceResponse<List<DailyInfoModel>>> GetDailyInfos(DateTime date);
    }
}
