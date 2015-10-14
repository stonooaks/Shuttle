using System;
using System.Collections.Generic;

namespace Hermes.Data.Models
{
    public partial class Guest
    {
        public Guest()
        {
            this.Buses = new List<Bus>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int RegularId { get; set; }
        public virtual ICollection<Bus> Buses { get; set; }
        public virtual Regular Regular { get; set; }
    }
}
