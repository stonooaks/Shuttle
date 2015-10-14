using System;
using System.Collections.Generic;

namespace Hermes.Data.Models
{
    public partial class AdditionalType
    {
        public AdditionalType()
        {
            this.Additionals = new List<Additional>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Additional> Additionals { get; set; }
    }
}
