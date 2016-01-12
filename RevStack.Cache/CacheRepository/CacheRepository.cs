using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using RevStack.Pattern;

namespace RevStack.Cache
{
    public class CacheRepository<TEntity,TKey> : ICacheRepository<TEntity,TKey> where TEntity :class, IEntity<TKey>
    {
        protected double _hours;
        protected DateTimeOffset _expirationOffset;
        protected const double EXPIRATION_HOURS = 2;
        public CacheRepository()
        {
            _hours = EXPIRATION_HOURS;
        }
        public CacheRepository(double hours)
        {
            _hours = hours;
        }

        public virtual TEntity Get(string key)
        {
            throw new NotImplementedException();
        }

        public virtual void Set(string key, TEntity entity)
        {
            throw new NotImplementedException();
        }

        public virtual void Remove(string key)
        {
            throw new NotImplementedException();
        }

        public virtual void Clear()
        {
            throw new NotImplementedException();
        }

        public virtual IEnumerable<TEntity> Get()
        {
            throw new NotImplementedException();
        }

        public virtual IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public virtual TEntity Add(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public virtual TEntity Update(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public virtual void Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
