using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RevStack.Pattern;


namespace RevStack.Cache
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

        public IEnumerable<TEntity> Get(string key, bool isEnumerable)
        {
            return _repository.Get(key,isEnumerable);
        }

        public Task<TEntity> GetAsync(string key)
        {
            return Task.FromResult(Get(key));
        }

        public Task<IEnumerable<TEntity>> GetAsync(string key, bool isEnumerable)
        {
            return Task.FromResult(Get(key,isEnumerable));
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

        public void Set(string key, IEnumerable<TEntity> entity, bool isEnumerable)
        {
            _repository.Set(key, entity,isEnumerable);
        }

        public Task SetAsync(string key, TEntity entity)
        {
            Set(key, entity);
            return Task.FromResult(true);
        }

        public Task SetAsync(string key, IEnumerable<TEntity> entity, bool isEnumerable)
        {
            Set(key, entity,isEnumerable);
            return Task.FromResult(true);
        }
    }
}
