using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using MS.Bordro.Domain.Entities.BaseEntities;
using MS.Bordro.Enumerations;

namespace MS.Bordro.Domain.Entities
{
    public class Employee : BaseGuidModel
    {
        [Required]
        [MinLength(1), MaxLength(64)]
        public string Name { get; set; }

        [Required]
        [MinLength(1), MaxLength(64)]
        public string LastName { get; set; }

        [Required]
        [MinLength(11), MaxLength(11)]
        public string TCId { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public byte Gender { get; set; }
        public byte EmployeeType { get; set; }

        public override string ToString()
        {
            var str = base.ToString() + String.Format(" | Name: {0} | LastName: {1} | TCId: {2} | Email: {3} | Phone: {4} | Gender: {5} | Type: {6}", Name, LastName, TCId, Email, Phone, Enum.GetName(typeof(Sex), Gender), Enum.GetName(typeof(EmployeeType), EmployeeType));
            return str;
        }
    }
}