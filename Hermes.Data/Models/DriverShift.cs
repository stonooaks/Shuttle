using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Hermes.Data.Models
{
    public partial class DriverShift
    {
        public DriverShift()
        {
            this.Drivers = new List<Driver>();
        }

        public int Id { get; set; }

        [Display(Name ="Driver Shift")]
        public string DriverShift1 { get; set; }
        public virtual ICollection<Driver> Drivers { get; set; }
    }
}
