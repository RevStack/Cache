using System;
using System.Threading.Tasks;
using RevStack.Pattern;

namespace RevStack.Cache.CacheService
{
    public class CacheService<TEntity, TKey> : Service<TEntity, TKey>, ICacheService<TEntity, TKey> where TEntity : class, IEntity<TKey>
    {
        protected new ICacheRepository<TEntity,TKey> _repository;
        public CacheService(ICacheRepository<TEntity,TKey> repository) :base(repository)
        {
            _repository = repository;
        }

        public void Clear()
        {
            _repository.Clear();
        }

        public Task ClearAsync()
        {
            Clear();
            return Task.FromResult(true);
        }

        public TEntity Get(string key)
        {
            return _repository.Get(key);
        }

        public Task<TEntity> GetAsync(string key)
        {
            return Task.FromResult(Get(key));
        }

        public void Remove(string key)
        {
            _repository.Remove(key);
        }

        public Task RemoveAsync(string key)
        {
            Remove(key);
            return Task.FromResult(true);
        }

        public void Set(string key, TEntity entity)
        {
            _repository.Set(key, entity);
        }

        public Task SetAsync(string key, TEntity entity)
        {
            Set(key, entity);
            return Task.FromResult(true);
        }
    }
}
