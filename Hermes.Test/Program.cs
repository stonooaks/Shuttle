using Hermes.Data.Models;
using Hermes.Service;
using Hermes.ViewModels.Common;
using Hermes.ViewModels.ReportViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hermes.Test
{
    class Program
    {

        
        static void Main(string[] args)
        {
            HermesContext db = new HermesContext();
            VMFormats meth = new VMFormats();
            var regular = db.Regulars.ToList();

            foreach (var item in regular) {

                item.Cost = meth.calculateTripCost(item.Id);
                item.Count = meth.CountGuests(item.Id);
                db.SaveChanges();
            }
           

        }
    }
}
