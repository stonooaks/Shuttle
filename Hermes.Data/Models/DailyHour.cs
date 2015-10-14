using System;
using System.Collections.Generic;

namespace Hermes.Data.Models
{
    public partial class DailyHour
    {
        public int id { get; set; }
        public System.DateTime Day { get; set; }
        public double Miles { get; set; }
        public Nullable<int> VehicleId { get; set; }
        public virtual Vehicle Vehicle { get; set; }
    }
}
