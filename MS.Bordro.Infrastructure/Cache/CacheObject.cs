using MS.Bordro.Domain.Entities.BaseEntities;

namespace MS.Bordro.Infrastructure.Cache
{
    public class CacheObject : BaseModel
    {
        public string Key { get; set; }
        public object Value { get; set; }
    }
}
