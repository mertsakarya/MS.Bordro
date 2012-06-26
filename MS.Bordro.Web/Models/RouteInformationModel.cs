using System;
using System.ComponentModel.DataAnnotations;
using MS.Bordro.Web.Models.BaseEntities;

namespace MS.Bordro.Web.Models
{
    public class RouteInformationModel : BaseModel
    {
        [Required]
        public long EmployeeId { get; set; }
        public EmployeeModel Employee { get; set; }

        [Required]
        public long VehicleId { get; set; }
        public VehicleModel Vehicle { get; set; }

        public DateTime Date { get; set; }

        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }

        public int StartKilometers { get; set; }
        public int EndKilometers { get; set; }

        public decimal Cost { get; set; }
        public decimal Sale { get; set; }

        public byte State { get; set; }

        public string Notes { get; set; }

        public override string ToString()
        {
            var str = base.ToString() + String.Format(" | EmployeeId: {0} | VehicleId: {1} | Date: {2} | StartTime: {3} | EndTime: {4} | StartKilometers: {5} | EndKilometers: {6} | Notes: {7}", EmployeeId, VehicleId, Date, StartTime, EndTime, StartKilometers, EndKilometers, Notes);
            return str;
        }

    }
}