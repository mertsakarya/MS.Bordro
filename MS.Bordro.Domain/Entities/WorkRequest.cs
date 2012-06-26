using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using MS.Bordro.Domain.Entities.BaseEntities;

namespace MS.Bordro.Domain.Entities
{
    public class WorkRequest : BaseGuidModel
    {
        public WorkRequest() { Workers = new List<Worker>(); }

        [Required]
        public long CompanyId { get; set; }

        public Company Company { get; set; }

        [Required]
        public long CompanyLocationId { get; set; }

        public CompanyLocation CompanyLocation { get; set; }

        public DateTime Date { get; set; }

        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }

        public string Notes { get; set; }

        public long DepartingId { get; set; }
        public RouteInformation Departing { get; set; }

        public long ReturningId { get; set; }
        public RouteInformation Returning { get; set; }

        public decimal Cost { get; set; }
        public decimal Sale { get; set; }

        public byte State { get; set; }

        protected IList<Worker> Workers { get; set; }

        public override string ToString()
        {
            var str = base.ToString() + String.Format(" | CompanyId: {0} | CompanyLocationId: {1} | Date: {2} | StartTime: {3} | EndTime: {4} | Notes: {5}", CompanyId, CompanyLocationId, Date, StartTime, EndTime, Notes);
            str += String.Format("\r\n\tDeparting: [{0}]", Departing);
            str += String.Format("\r\n\tReturning: [{0}]", Returning);
            if (Workers != null && Workers.Count > 0) {
                str += "\r\nWorkers: [\r\n";
                str = Workers.Aggregate(str, (current, item) => current + ("\t" + item.ToString() + "\r\n"));
                str += "]";
            }
            return str;
        }

    }
}