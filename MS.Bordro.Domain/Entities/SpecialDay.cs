using System;
using System.ComponentModel.DataAnnotations;
using MS.Bordro.Domain.Entities.BaseEntities;

namespace MS.Bordro.Domain.Entities
{
    public class SpecialDay : BaseModel
    {
        [Required]
        public DateTime Date { get; set; }

        [Required]
        public string Description { get; set; }


        public override string ToString()
        {
            return base.ToString() + String.Format(" | Date: {0} | Description: {1}", Date, Description);
        }

    }
}