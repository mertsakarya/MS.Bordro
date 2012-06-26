using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using MS.Bordro.Web.Models.BaseEntities;

namespace MS.Bordro.Web.Models
{
    public class CompanyModel : BaseGuidModel
    {
        public CompanyModel()
        {
            Locations = new List<CompanyLocationModel>();
        }

        [Required]
        [MinLength(7), MaxLength(64)]
        public string Name { get; set; }

        public List<CompanyLocationModel> Locations { get; set; }

        public override string ToString()
        {
            var str = base.ToString() + String.Format(" | Name: {0}", Name);
            if (Locations != null && Locations.Count > 0) {
                str += "\r\nLocations: [\r\n";
                str = Locations.Aggregate(str, (current, item) => current + ("\t" + item.ToString() + "\r\n"));
                str += "]";
            }
            return str;
        }

    }
}