using MS.Bordro.Domain.Entities.BaseEntities;

namespace MS.Bordro.Domain.Entities
{
    public class ConfigurationData : BaseModel
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
