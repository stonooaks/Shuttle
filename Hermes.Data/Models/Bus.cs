using System;
using System.Collections.Generic;

namespace Hermes.Data.Models
{
    public partial class Bus
    {
        public Bus()
        {
            this.Members = new List<Member>();
        }

        public int Id { get; set; }
        public int StopsId { get; set; }
        public int TripTypeId { get; set; }
        public Nullable<int> Kiawah_Id { get; set; }
        public int DriverId { get; set; }
        public Nullable<int> BusTimeId { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public Nullable<int> GuestId { get; set; }
        public virtual BusTime BusTime { get; set; }
        public virtual Guest Guest { get; set; }
        public virtual Intersection Intersection { get; set; }
        public virtual RouteStop RouteStop { get; set; }
        public virtual Driver Driver { get; set; }
        public virtual Kiawah Kiawah { get; set; }
        public virtual TripType TripType { get; set; }
        public virtual ICollection<Member> Members { get; set; }
    }
}
