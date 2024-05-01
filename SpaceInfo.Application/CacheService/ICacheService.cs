using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInfo.Application.CacheService
{
    public interface ICacheService
    {
        T GetOrSet<T>(string cacheKey, Func<T> getItemCallback, DateTime Date, int timeForDaysk) where T : class;
        T Get<T>(string cacheKey) where T : class;

    }
}
