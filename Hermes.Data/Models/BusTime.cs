using System;
using System.Collections.Generic;

namespace Hermes.Data.Models
{
    public partial class BusTime
    {
        public BusTime()
        {
            this.Buses = new List<Bus>();
        }

        public int Id { get; set; }
        public Nullable<System.TimeSpan> StopTime { get; set; }
        public string StopLocation { get; set; }
        public virtual ICollection<Bus> Buses { get; set; }
    }
}
