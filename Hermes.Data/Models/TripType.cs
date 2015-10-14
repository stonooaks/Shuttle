using System;
using System.Collections.Generic;

namespace Hermes.Data.Models
{
    public partial class TripType
    {
        public TripType()
        {
            this.Buses = new List<Bus>();
            this.Costs = new List<Cost>();
            this.Regulars = new List<Regular>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Bus> Buses { get; set; }
        public virtual ICollection<Cost> Costs { get; set; }
        public virtual ICollection<Regular> Regulars { get; set; }
    }
}
