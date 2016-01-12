using System;
using System.Collections;
using System.Runtime.Caching;
using RevStack.Pattern;

namespace RevStack.Cache
{
    public class MemoryCacheRepository<TEntity,TKey> : CacheRepository<TEntity,TKey> where TEntity :class,IEntity<TKey>
    {
        protected MemoryCache _context;
        protected CacheItemPolicy _policy;
        public MemoryCacheRepository() : base()
        {
            _hours = EXPIRATION_HOURS;
            setCachePolicy();

        }
        public MemoryCacheRepository(double hours) : base(hours)
        {
            _hours = hours;
            setCachePolicy();
        }

        protected void setCachePolicy()
        {
            _context = MemoryCache.Default;
            _policy = new CacheItemPolicy();
            _policy.AbsoluteExpiration = DateTimeOffset.Now.AddHours(_hours);
        }

        public override void Clear()
        {
            foreach (var e in _context)
            {
                string key = e.Key.ToString();
                if (_context[key].GetType() == typeof(TEntity))
                {
                    _context.Remove(key);
                }
            }
        }

        public override TEntity Get(string key)
        {
            return (TEntity)_context.Get(key);
        }

        public override void Remove(string key)
        {
            _context.Remove(key);
        }

        public override void Set(string key, TEntity entity)
        {
            _context.Set(key, entity, _policy);
        }
    }
}
