using System;
using System.Collections.Generic;

namespace Hermes.Data.Models
{
    public partial class GasMileage
    {
        public int Id { get; set; }
        public System.DateTime Date { get; set; }
        public float Mileage { get; set; }
        public float Gallons { get; set; }
        public Nullable<int> VehicleId { get; set; }
        public virtual Vehicle Vehicle { get; set; }
    }
}
