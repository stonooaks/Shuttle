using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hermes.Web.ViewModels
{
    public class AddAddressViewModel
    {
        public int HHID { get; set; }
        public DateTime Date { get; set; }
        public int MemberId { get; set; }
        public string Address { get; set; }
    }
}