using System;
using System.Collections.Generic;

namespace Hermes.Data.Models
{
    public partial class ShoppingCart
    {
        public int Id { get; set; }
        public int RegularId { get; set; }
        public Nullable<double> TotalCost { get; set; }
        public Nullable<System.DateTime> ShoppingCartDate { get; set; }
        public int HouseholdID { get; set; }
        public virtual Regular Regular { get; set; }
    }
}
