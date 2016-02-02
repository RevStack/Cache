using System;
using System.Collections.Generic;
using RevStack.Pattern;


namespace RevStack.Cache
{
    public interface ICacheRepository<TEntity,TKey> : IRepository<TEntity,TKey> where TEntity : class, IEntity<TKey>
    {
        TEntity Get(string key);
        IEnumerable<TEntity> Get(string key,bool isEnumerable);
        void Set(string key, TEntity entity);
        void Set(string key, IEnumerable<TEntity> entity,bool isEnumerable);
        void Remove(string key);
        void Clear();
        double Hours { get; set; }
    }
}
