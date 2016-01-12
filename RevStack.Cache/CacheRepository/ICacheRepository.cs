using System;
using RevStack.Pattern;

namespace RevStack.Cache
{
    public interface ICacheRepository<TEntity,TKey> : IRepository<TEntity,TKey> where TEntity : class, IEntity<TKey>
    {
        TEntity Get(string key);
        void Set(string key, TEntity entity);
        void Remove(string key);
        void Clear();
    }
}
