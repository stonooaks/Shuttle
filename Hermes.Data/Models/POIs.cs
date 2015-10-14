using System;
using System.Collections.Generic;

namespace Hermes.Data.Models
{
    public partial class POIs
    {
        public POIs()
        {
            this.Intersections = new List<Intersection>();
            this.RouteStops = new List<RouteStop>();
        }

        public int id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public virtual ICollection<Intersection> Intersections { get; set; }
        public virtual ICollection<RouteStop> RouteStops { get; set; }
    }
}
