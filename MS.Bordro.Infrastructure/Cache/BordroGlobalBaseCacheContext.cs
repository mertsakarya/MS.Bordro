namespace MS.Bordro.Infrastructure.Cache
{
    public abstract class BordroGlobalBaseCacheContext : IBordroGlobalCacheContext
    {
        private readonly IBordroGlobalCacheContext _containerCacheContext;

        protected BordroGlobalBaseCacheContext(IBordroGlobalCacheContext containerCacheContext)
        {
            _containerCacheContext = containerCacheContext;
        }

        public virtual void Add<T>(string key, T value) where T : class { if(_containerCacheContext != null) _containerCacheContext.Add(key, value); }

        public virtual T Get<T>(string key) where T : class
        {
            return _containerCacheContext != null ? _containerCacheContext.Get<T>(key) : default(T);
        }

        public virtual void Delete(string key) { if (_containerCacheContext != null) _containerCacheContext.Delete(key); }
    }
}