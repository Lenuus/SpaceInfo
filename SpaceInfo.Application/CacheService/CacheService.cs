using Microsoft.Extensions.Caching.Memory;
using SpaceInfo.Application.CacheService;
using System;
using System.Runtime.Caching;

public class InMemoryCache : ICacheService
{
    public T Get<T>(string cacheKey) where T : class
    {
        T item = System.Runtime.Caching.MemoryCache.Default.Get(cacheKey) as T;
        return item;
    }

    public T GetOrSet<T>(string cacheKey, Func<T> getItemCallback) where T : class
    {
        T item = System.Runtime.Caching.MemoryCache.Default.Get(cacheKey) as T;
        if (item == null)
        {
            item = getItemCallback();
            System.Runtime.Caching.MemoryCache.Default.Add(cacheKey, item, DateTimeOffset.Now.AddDays(45));
        }
        return item;
    }
}
