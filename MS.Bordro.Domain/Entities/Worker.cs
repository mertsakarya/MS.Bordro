using System;
using System.ComponentModel.DataAnnotations;
using MS.Bordro.Domain.Entities.BaseEntities;
using MS.Bordro.Enumerations;

namespace MS.Bordro.Domain.Entities
{
    public class Worker : BaseModel
    {
        [Required]
        public long EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public byte Role { get; set; }
        public byte CalculationType { get; set; }
        public byte State { get; set; }

        public DateTime Date { get; set; }

        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }

        public Money Money { get; set; }

        public string Notes { get; set; }


        public override string ToString()
        {
            var str = base.ToString() + String.Format(" | EmployeeId: {0} | Role: {1} | Date: {2} | StartTime: {3} | EndTime: {4} |  Notes: {5}", EmployeeId, Enum.GetName(typeof(EmployeeType), Role), Date, StartTime, EndTime, Notes);
            return str;
        }
    }
}