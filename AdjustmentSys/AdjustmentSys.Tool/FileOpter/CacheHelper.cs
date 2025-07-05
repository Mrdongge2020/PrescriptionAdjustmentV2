using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace AdjustmentSys.Tool.FileOpter
{
    public class CacheHelper
    {
        private static MemoryCache cache = MemoryCache.Default;

        public static void AddToCache(string key, object value, DateTimeOffset expirationTime)
        {
            cache.Set(key, value, expirationTime);
        }

        public static object GetFromCache(string key)
        {
            return cache.Get(key);
        }

        public static void RemoveFromCache(string key)
        {
            cache.Remove(key);
        }
    }
}
