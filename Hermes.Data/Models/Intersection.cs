using System;
using System.Collections.Generic;

namespace Hermes.Data.Models
{
    public partial class Intersection
    {
        public Intersection()
        {
            this.Buses = new List<Bus>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int POIId { get; set; }
        public virtual ICollection<Bus> Buses { get; set; }
        public virtual POIs POIs { get; set; }
    }
}
