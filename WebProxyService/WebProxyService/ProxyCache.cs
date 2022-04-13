using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime;
using System.Runtime.Caching;
using WebProxyService.ReferenceObjects;

namespace WebProxyService
{
    public class ProxyCache<T> where T : class
    {
        private ObjectCache cache = MemoryCache.Default;
        private DateTimeOffset dt_default;


        //attributes 
        public ProxyCache()
        {
            dt_default = ObjectCache.InfiniteAbsoluteExpiration;
        }


        public T Get(string CacheItemName)
        {
            if (this.cache.Get(CacheItemName) == null || !this.cache.Contains(CacheItemName))
            {
                T obj = (T)Activator.CreateInstance(typeof(T), CacheItemName);
                CacheItemPolicy cacheItemPolicy = new CacheItemPolicy();
                cacheItemPolicy.AbsoluteExpiration = dt_default;
                this.cache.Add(CacheItemName, obj, cacheItemPolicy);
            }
            return (T)this.cache.Get(CacheItemName);

        }

        public T Get(string CacheItemName, double dt_seconds)
        {
            if (this.cache.Get(CacheItemName) == null || !this.cache.Contains(CacheItemName))
            {
                T obj = (T)Activator.CreateInstance(typeof(T), CacheItemName);
                CacheItemPolicy cacheItemPolicy = new CacheItemPolicy();
                cacheItemPolicy.AbsoluteExpiration = DateTimeOffset.Now.AddSeconds(dt_seconds);
                this.cache.Add(CacheItemName, obj, cacheItemPolicy);
            }
            return (T)this.cache.Get(CacheItemName);
        }

        public T Get(string CacheItemName, DateTimeOffset dt)
        {
            if (this.cache.Get(CacheItemName) == null || !this.cache.Contains(CacheItemName))
            {
                T obj = (T)Activator.CreateInstance(typeof(T), CacheItemName);
                CacheItemPolicy cacheItemPolicy = new CacheItemPolicy();
                cacheItemPolicy.AbsoluteExpiration = dt;
                this.cache.Add(CacheItemName, obj, cacheItemPolicy);
            }
            return (T)this.cache.Get(CacheItemName);
        }
    }
}
