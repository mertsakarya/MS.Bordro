using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using MS.Bordro.Web.Models.BaseEntities;

namespace MS.Bordro.Web.Models
{
    public class VehicleModel : BaseGuidModel
    {
        [Required]
        [MinLength(3), MaxLength(64)]
        public string Name { get; set; }

        public string Number { get; set; }
        public int Seats { get; set; }


        public override string ToString()
        {
            var str = base.ToString() + String.Format(" | Name: {0} | Number: {1} | Seats: {2}", Name, Number, Seats);
            return str;
        }

    }
}