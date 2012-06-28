using System;
using MS.Bordro.Domain.Entities.BaseEntities;

namespace MS.Bordro.Domain.Entities
{
    public class Money
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