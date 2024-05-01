using Microsoft.EntityFrameworkCore;
using SpaceInfo.Application.CacheService;
using SpaceInfo.Application.DailyInfoService.Dtos;
using SpaceInfo.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInfo.Application.DailyInfoService
{
    public class DailyInfoService : IDailyInfoService
    {
        private readonly IRepository<Domain.DailyInfo> _dailyInfoRepository;
        private readonly ICacheService _cacheService;

        public DailyInfoService(IRepository<DailyInfo> dailyInfoRepository, ICacheService cacheService)
        {
            _dailyInfoRepository = dailyInfoRepository;
            _cacheService = cacheService;
        }

        public async Task<ServiceResponse<List<DailyInfoDto>>> GetAllInfos()
        {
            var dailyInfos = await _dailyInfoRepository.GetAll().Where(f => !f.IsDeleted).Select(f => new DailyInfoDto
            {
                Id = f.Id,
                Copyright = f.Copyright,
                Date = f.Date,
                Explanation = f.Explanation,
                Hdurl = f.Hdurl,
                MediaType = f.MediaType,
                Title = f.Title,
                Url = f.Url,
            }).OrderBy(f => f.Date).ToListAsync().ConfigureAwait(false);

            return new ServiceResponse<List<DailyInfoDto>>(dailyInfos, true, string.Empty);
        }

        public async Task<ServiceResponse<DailyInfoDto>> GetRandomDailyInfo()
        {
            var dailyInfos = await _dailyInfoRepository.GetAll().ToListAsync().ConfigureAwait(false);


            if (dailyInfos == null || dailyInfos.Count == 0)
            {
                return new ServiceResponse<DailyInfoDto>(null, false, "Daily info list is empty.");
            }

            var random = new Random();
            var randomIndex = random.Next(0, dailyInfos.Count);
            var randomDailyInfo = dailyInfos[randomIndex];
            var key = $"key_{randomDailyInfo.Title}";
            var currentKey = "currentKey";

            var currenctCacheData = _cacheService.Get<DailyInfoDto>(currentKey);
            if (currenctCacheData != null)
            {
                return new ServiceResponse<DailyInfoDto>(currenctCacheData, true, string.Empty);
            }

            DailyInfoDto existedCacheData = null;
            var i = 0;

            do
            {
                existedCacheData = _cacheService.Get<DailyInfoDto>(key);
                i++;
            } while (existedCacheData != null || i == 12);

            var selectedInfo = new DailyInfoDto
            {
                Id = randomDailyInfo.Id,
                Copyright = randomDailyInfo.Copyright,
                Date = randomDailyInfo.Date,
                Explanation = randomDailyInfo.Explanation,
                Hdurl = randomDailyInfo.Hdurl,
                Title = randomDailyInfo.Title,
                Url = randomDailyInfo.Url,
                MediaType = randomDailyInfo.MediaType,
            };


            var cacheDailyData = _cacheService.GetOrSet(key, () => selectedInfo, DateTime.Now, 45);
            var usingData = _cacheService.GetOrSet(currentKey, () => selectedInfo, DateTime.Now, 1);

            return new ServiceResponse<DailyInfoDto>(selectedInfo, true, string.Empty);
        }
    }
}
