﻿using System;
using System.ComponentModel.DataAnnotations;
using MS.Bordro.Domain.Entities.BaseEntities;
using MS.Bordro.Enumerations;
using Newtonsoft.Json;

namespace MS.Bordro.Domain.Entities
{
    public class SpecialDay : BaseGuidModel
    {
        public byte Gender { get; set; }

        [Required]
        [MinLength(3), MaxLength(64)]
        public string UserName { get; set; }
        public string FacebookUid { get; set; }

        [Required]
        [MinLength(7), MaxLength(64)]
        public string Email { get; set; }

        public bool EmailValidated { get; set; }
        
        public string Phone { get; set; }

        [Required]
        [MinLength(6), MaxLength(14)]
        [JsonIgnore]
        public string Password { get; set; }

        public DateTime Expires { get; set; }
        public byte MembershipType { get; set; }


        public override string ToString()
        {
            return base.ToString() + String.Format(" | FacebookUid: {0} | Gender: {1} | UserName: {2} | Email: {3} | EmailValidated: {7} | Phone: {4} | Password: {5} | Expires: {6}", FacebookUid, Enum.GetName(typeof(Sex), Gender), UserName, Email, Phone, Password, Expires, EmailValidated);
        }

    }
}