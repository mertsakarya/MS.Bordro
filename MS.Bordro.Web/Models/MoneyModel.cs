using System;

namespace MS.Bordro.Web.Models
{
    public class MoneyModel
    {
        public decimal Cost { get; set; }
        public decimal Sale { get; set; }

        public override string ToString()
        {
            var str = base.ToString() + String.Format(" | Cost: {0} | Sale: {1}", Cost, Sale);
            return str;
        }
    }
}