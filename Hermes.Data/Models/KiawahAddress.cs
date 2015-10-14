using System;
using System.Collections.Generic;

namespace Hermes.Data.Models
{
    public partial class KiawahAddress
    {
        public KiawahAddress()
        {
            this.Households = new List<Household>();
        }

        public int Id { get; set; }
        public string Address1 { get; set; }
        public virtual ICollection<Household> Households { get; set; }
    }
}
