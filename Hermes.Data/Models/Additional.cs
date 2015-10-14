using System;
using System.Collections.Generic;

namespace Hermes.Data.Models
{
    public partial class Additional
    {
        public Additional()
        {
            this.AdditionalTrips = new List<AdditionalTrip>();
        }

        public int Id { get; set; }
        public int AdditionalTypeId { get; set; }
        public string Name { get; set; }
        public decimal Cost { get; set; }
        public virtual AdditionalType AdditionalType { get; set; }
        public virtual ICollection<AdditionalTrip> AdditionalTrips { get; set; }
    }
}
