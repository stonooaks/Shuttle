using System;
using System.Collections.Generic;

namespace Hermes.Data.Models
{
    public partial class Kiawah
    {
        public Kiawah()
        {
            this.Buses = new List<Bus>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Bus> Buses { get; set; }
    }
}
