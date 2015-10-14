using System;
using System.Collections.Generic;

namespace Hermes.Data.Models
{
    public partial class Driver
    {
        public Driver()
        {
            this.Buses = new List<Bus>();
            this.Regulars = new List<Regular>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string License { get; set; }
        public Nullable<int> ShiftId { get; set; }
        public virtual ICollection<Bus> Buses { get; set; }
        public virtual ICollection<Regular> Regulars { get; set; }
        public virtual DriverShift DriverShift { get; set; }
    }
}
