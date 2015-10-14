using System;
using System.Collections.Generic;

namespace Hermes.Data.Models
{
    public partial class Vehicle
    {
        public Vehicle()
        {
            this.DailyHours = new List<DailyHour>();
            this.GasMileages = new List<GasMileage>();
            this.Maintenances = new List<Maintenance>();
            this.Regulars = new List<Regular>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<DailyHour> DailyHours { get; set; }
        public virtual ICollection<GasMileage> GasMileages { get; set; }
        public virtual ICollection<Maintenance> Maintenances { get; set; }
        public virtual ICollection<Regular> Regulars { get; set; }
    }
}
