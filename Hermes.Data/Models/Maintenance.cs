using System;
using System.Collections.Generic;

namespace Hermes.Data.Models
{
    public partial class Maintenance
    {
        public int Id { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public Nullable<double> Cost { get; set; }
        public Nullable<int> VehicleId { get; set; }
        public virtual Vehicle Vehicle { get; set; }
    }
}
