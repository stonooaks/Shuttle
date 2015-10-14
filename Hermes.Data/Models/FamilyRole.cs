using System;
using System.Collections.Generic;

namespace Hermes.Data.Models
{
    public partial class FamilyRole
    {
        public FamilyRole()
        {
            this.Members = new List<Member>();
        }

        public int Id { get; set; }
        public string Description { get; set; }
        public Nullable<bool> AuthorizedUser { get; set; }
        public virtual ICollection<Member> Members { get; set; }
    }
}
