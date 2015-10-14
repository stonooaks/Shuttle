using System;
using System.Collections.Generic;

namespace Hermes.Data.Models
{
    public partial class KiawahLocation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Directions { get; set; }
    }
}
