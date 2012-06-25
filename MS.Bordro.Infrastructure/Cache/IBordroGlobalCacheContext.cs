namespace MS.Bordro.Infrastructure.Cache
{
    public interface IBordroGlobalCacheContext
    {
        void Add<T>(string key, T value) where T : class;
        T Get<T>(string key) where T : class;
        void Delete(string key);
    }
}