using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RevStack.Pattern;

namespace RevStack.Cache
{
    public interface ICacheService<TEntity,TKey> : IService<TEntity,TKey> where TEntity : class, IEntity<TKey>
    {
        TEntity Get(string key);
        IEnumerable<TEntity> Get(string key,bool isEnumerable);
        void Set(string key, TEntity entity);
        void Set(string key, IEnumerable<TEntity> entity,bool isEnumerable);
        void Remove(string key);
        void Clear();
        Task<TEntity> GetAsync(string key);
        Task<IEnumerable<TEntity>> GetAsync(string key, bool isEnumerable);
        Task SetAsync(string key, TEntity entity);
        Task SetAsync(string key, IEnumerable<TEntity> entity, bool isEnumerable);
        Task RemoveAsync(string key);
        Task ClearAsync();
    }
}
