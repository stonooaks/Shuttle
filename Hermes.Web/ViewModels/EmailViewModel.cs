using Hermes.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hermes.Web.ViewModels
{
    public class EmailViewModel
    {
        public Regular Regular{ get; set; }

        public ICollection<string> Emails { get; set; }

        public ICollection<string> Phones { get; set; }
    }
}