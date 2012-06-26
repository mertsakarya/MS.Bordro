using System;
using System.ComponentModel.DataAnnotations;
using MS.Bordro.Domain.Entities.BaseEntities;
using MS.Bordro.Enumerations;
using Newtonsoft.Json;

namespace MS.Bordro.Domain.Entities
{
    public class EmployeeAttribute : BaseModel
    {
        [JsonIgnore]
        [Required]
        public long EmployeeId { get; set; }

        [JsonIgnore]
        public Company Employee { get; set; }

        public String Name { get; set; }
        public String Value { get; set; }


        public override string ToString()
        {
            return base.ToString() + String.Format(" | Name: {0} | Value: {1}", Name, Value);
        }

    }
}