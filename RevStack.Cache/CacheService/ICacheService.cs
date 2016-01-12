using System;
using System.Threading.Tasks;
using RevStack.Pattern;

namespace RevStack.Cache
{
    public interface ICacheService<TEntity,TKey> : IService<TEntity,TKey> where TEntity : class, IEntity<TKey>
    {
        TEntity Get(string key);
        void Set(string key, TEntity entity);
        void Remove(string key);
        void Clear();
        Task<TEntity> GetAsync(string key);
        Task SetAsync(string key, TEntity entity);
        Task RemoveAsync(string key);
        Task ClearAsync();
    }
}
