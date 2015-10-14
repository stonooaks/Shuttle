using System;
using System.Collections.Generic;

namespace Hermes.Data.Models
{
    public partial class Household
    {
        public Household()
        {
            this.AuthorizedUsers = new List<AuthorizedUser>();
            this.BillingAddresses = new List<BillingAddress>();
            this.Members = new List<Member>();
            this.Regulars = new List<Regular>();
            this.KiawahAddresses = new List<KiawahAddress>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<AuthorizedUser> AuthorizedUsers { get; set; }
        public virtual ICollection<BillingAddress> BillingAddresses { get; set; }
        public virtual ICollection<Member> Members { get; set; }
        public virtual ICollection<Regular> Regulars { get; set; }
        public virtual ICollection<KiawahAddress> KiawahAddresses { get; set; }
    }
}
