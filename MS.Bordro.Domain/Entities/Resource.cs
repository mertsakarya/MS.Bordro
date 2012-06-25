using System.ComponentModel.DataAnnotations;
using System.Globalization;
using MS.Bordro.Domain.Entities.BaseEntities;

namespace MS.Bordro.Domain.Entities
{
    public class Resource : BaseModel
    {
        public string ResourceKey { get; set; }
        public string Value { get; set; }
        [StringLength(2)]
        public string Language { get; set; }

        [NotMapped]
        public string Key
        {
            get { return ResourceKey + Language.ToString(CultureInfo.InvariantCulture); }
        }
    }
}
