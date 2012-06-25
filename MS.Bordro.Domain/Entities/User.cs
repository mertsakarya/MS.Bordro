using System;
using System.ComponentModel.DataAnnotations;
using MS.Bordro.Domain.Entities.BaseEntities;
using Newtonsoft.Json;

namespace MS.Bordro.Domain.Entities
{
    public class User : BaseGuidModel
    {
        [Required]
        [MinLength(3), MaxLength(64)]
        public string UserName { get; set; }

        [Required]
        [MinLength(7), MaxLength(64)]
        public string Email { get; set; }
        
        public string Phone { get; set; }

        [Required]
        [MinLength(6), MaxLength(14)]
        [JsonIgnore]
        public string Password { get; set; }

        public byte MembershipType { get; set; }


        public override string ToString()
        {
            return base.ToString() + String.Format(" | UserName: {0} | Email: {1} | Phone: {2}", UserName, Email, Phone);
        }

    }
}