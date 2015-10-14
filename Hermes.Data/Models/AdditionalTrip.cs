using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Hermes.Data.Models
{
    public partial class AdditionalTrip
    {
        public int Id { get; set; }
        public int RegularId { get; set; }
        public int AdditionalId { get; set; }
        public int Number { get; set; }
        [DataType(DataType.MultilineText)]
        public string Notes { get; set; }
        public virtual Additional Additional { get; set; }
        public virtual Regular Regular { get; set; }
    }
}
