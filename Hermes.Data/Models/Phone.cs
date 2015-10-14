using System;
using System.Collections.Generic;

namespace Hermes.Data.Models
{
    public partial class Phone
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public Nullable<int> MemberId { get; set; }
        public virtual Member Member { get; set; }
    }
}
