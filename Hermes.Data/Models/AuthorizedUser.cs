using System;
using System.Collections.Generic;

namespace Hermes.Data.Models
{
    public partial class AuthorizedUser
    {
        public int Id { get; set; }
        public int HouseholdId { get; set; }
        public string Name { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
        public Nullable<System.DateTime> DateExpired { get; set; }
        public virtual Household Household { get; set; }
    }
}
