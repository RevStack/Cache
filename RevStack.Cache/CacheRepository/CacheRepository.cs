using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using RevStack.Pattern;

namespace RevStack.Cache
{
    public class CacheRepository<TEntity,TKey> : ICacheRepository<TEntity,TKey> where TEntity :class, IEntity<TKey>
    {
        protected double _hours=2;
        protected DateTimeOffset _expirationOffset;
       
        public virtual double Hours
        {
            get
            {
                return _hours;
            }

            set
            {
                _hours = value;
            }
        }

        public virtual TEntity Get(string key)
        {
            throw new NotImplementedException();
        }

        public virtual IEnumerable<TEntity> Get(string key,bool isEnumerable)
        {
            throw new NotImplementedException();
        }

        public virtual void Set(string key, TEntity entity)
        {
            throw new NotImplementedException();
        }

        public virtual void Set(string key, IEnumerable<TEntity> entity, bool isEnumerable)
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
