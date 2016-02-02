using System;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using HttpCache = System.Web.Caching.Cache;
using RevStack.Pattern;


namespace RevStack.Cache
{
    public class HttpCacheRepository<TEntity,TKey> : CacheRepository<TEntity,TKey> where TEntity : class, IEntity<TKey>
    {
        protected HttpContextBase _context;
        public HttpCacheRepository() : base()
        {
            _context = new HttpContextWrapper(HttpContext.Current);
        }
        public override void Clear()
        {
            var cache = _context.Cache;
            foreach (DictionaryEntry e in cache)
            {
                string key = e.Key.ToString();
                if (cache[key].GetType() == typeof(TEntity))
                {
                    cache.Remove(key);
                }
            }
        }

        public override TEntity Get(string key)
        {
            return (TEntity)_context.Cache[key];
        }

        public override IEnumerable<TEntity> Get(string key, bool isEnumerable)
        {
            return (IEnumerable<TEntity>)_context.Cache[key];
        }

        public override void Remove(string key)
        {
            _context.Cache.Remove(key);
        }

        public override void Set(string key, TEntity entity)
        {
            _context.Cache.Insert(key, entity, null, DateTime.Now.AddHours(_hours), HttpCache.NoSlidingExpiration);
        }

        public override void Set(string key, IEnumerable<TEntity> entity, bool isEnumerable)
        {
            _context.Cache.Insert(key, entity, null, DateTime.Now.AddHours(_hours), HttpCache.NoSlidingExpiration);
        }
    }
}
