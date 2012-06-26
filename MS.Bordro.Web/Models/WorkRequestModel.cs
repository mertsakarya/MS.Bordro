using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using MS.Bordro.Web.Models.BaseEntities;

namespace MS.Bordro.Web.Models
{
    public class WorkRequestModel : BaseGuidModel
    {
        public WorkRequestModel() { Workers = new List<WorkerModel>(); }

        [Required]
        public long CompanyId { get; set; }

        public CompanyModel Company { get; set; }

        [Required]
        public long CompanyLocationId { get; set; }

        public CompanyLocationModel CompanyLocation { get; set; }

        public DateTime Date { get; set; }

        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }

        public string Notes { get; set; }

        public long DepartingId { get; set; }
        public RouteInformationModel Departing { get; set; }

        public long ReturningId { get; set; }
        public RouteInformationModel Returning { get; set; }

        public decimal Cost { get; set; }
        public decimal Sale { get; set; }

        public byte State { get; set; }

        protected IList<WorkerModel> Workers { get; set; }

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