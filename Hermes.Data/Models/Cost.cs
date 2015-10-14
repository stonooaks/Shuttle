using System;
using System.Collections.Generic;

namespace Hermes.Data.Models
{
    public partial class Cost
    {
        public int Id { get; set; }
        public Nullable<double> twoperprice { get; set; }
        public Nullable<double> addperprice { get; set; }
        public Nullable<int> TripTypeId { get; set; }
        public virtual TripType TripType { get; set; }
    }
}
