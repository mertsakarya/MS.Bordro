using System;
using System.ComponentModel.DataAnnotations;
using MS.Bordro.Domain.Entities.BaseEntities;

namespace MS.Bordro.Domain.Entities
{
    public class RouteInformation : BaseModel
    {
        [Required]
        public long EmployeeId { get; set; }
        public Employee Employee { get; set; }

        [Required]
        public long VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }

        public DateTime Date { get; set; }

        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }

        public int StartKilometers { get; set; }
        public int EndKilometers { get; set; }

        public Money Money { get; set; }

        public byte State { get; set; }

        public string Notes { get; set; }

        public override string ToString()
        {
            var str = base.ToString() + String.Format(" | EmployeeId: {0} | VehicleId: {1} | Date: {2} | StartTime: {3} | EndTime: {4} | StartKilometers: {5} | EndKilometers: {6} | Notes: {7}", EmployeeId, VehicleId, Date, StartTime, EndTime, StartKilometers, EndKilometers, Notes);
            return str;
        }

    }
}