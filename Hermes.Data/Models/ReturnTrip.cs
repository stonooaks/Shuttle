using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Hermes.Data.Models
{
    public partial class ReturnTrip
    {
        public int Id { get; set; }
        public int RegularId { get; set; }
        [DataType(DataType.Time)]
        public Nullable<System.TimeSpan> PickupTime { get; set; }
        public string TripLocation { get; set; }
        public string KiawahLocation { get; set; }
        public virtual Regular Regular { get; set; }
    }
}
