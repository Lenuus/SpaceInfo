using SpaceInfo.Application;
using SpaceInfo.NasaService.Models.DailyInfo;
using SpaceInfo.NasaService.Models.NasaSearch;
using SpaceInfo.NasaService.Models.NearObject;
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
        Task<ServiceResponse<List<NearEarthObjectModel>>> GetNearObjects(DateTime startDate, DateTime endDate);
        //Task<ServiceResponse<List<SearchItemDataModel>>> GetSearchMaterials(string search);
    }
}
