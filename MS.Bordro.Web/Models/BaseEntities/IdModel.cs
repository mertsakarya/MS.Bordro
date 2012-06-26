using System;

namespace MS.Bordro.Web.Models.BaseEntities
{
    public class IdModel
    {
        public long Id { get; set; }

        public override string ToString()
        {
            return String.Format("Id: {0}", Id);
        }

    }
}
