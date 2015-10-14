using System;
using System.Collections.Generic;

namespace Hermes.Data.Models
{
    public partial class RouteStop
    {
        public RouteStop()
        {
            this.Buses = new List<Bus>();
        }

        public int Id { get; set; }
        public int POIId { get; set; }
        public virtual ICollection<Bus> Buses { get; set; }
        public virtual POIs POIs { get; set; }
    }
}
