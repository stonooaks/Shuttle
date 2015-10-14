using System;
using System.Collections.Generic;

namespace Hermes.Data.Models
{
    public partial class Member
    {
        public Member()
        {
            this.Phones = new List<Phone>();
            this.Regulars = new List<Regular>();
            this.Buses = new List<Bus>();
            this.Regulars1 = new List<Regular>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public Nullable<int> FamilyRolesId { get; set; }
        public string Email { get; set; }
        public int HouseholdId { get; set; }
        public virtual FamilyRole FamilyRole { get; set; }
        public virtual Household Household { get; set; }
        public virtual ICollection<Phone> Phones { get; set; }
        public virtual ICollection<Regular> Regulars { get; set; }
        public virtual ICollection<Bus> Buses { get; set; }
        public virtual ICollection<Regular> Regulars1 { get; set; }
    }
}
