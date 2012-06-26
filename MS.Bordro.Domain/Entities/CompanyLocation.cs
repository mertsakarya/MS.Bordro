using System;
using System.ComponentModel.DataAnnotations;
using MS.Bordro.Domain.Entities.BaseEntities;
using Newtonsoft.Json;

namespace MS.Bordro.Domain.Entities
{
    public class CompanyLocation : BaseGuidModel
    {
        [JsonIgnore]
        [Required]
        public long CompanyId { get; set; }

        [JsonIgnore]
        public Company Company { get; set; }

        public String Name { get; set; }
        public String Address { get; set; }

        [MinLength(12), MaxLength(12)]
        public String CommunicationPhone { get; set; }
        public String CommunicationName { get; set; }

        public override string ToString()
        {
            return base.ToString() + String.Format(" | Name: {0}", Name);
        }
    }
}