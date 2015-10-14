/********************************************************************************
 * CLASS NAME:      DriverLog.cs
 * PROGRAMMER:      Michael Hughes
 * DESCRIPTION:     This allows the user to manipulate a Driver Log for
 *                  a Return Trip
 * VERSION:         1.0.0.0
 * CREATED DATE:    4/3/2014
 * MODIFIED DATE:
********************************************************************************/
        
using Hermes.Data.Models;
using Hermes.ViewModels.Common;
using Hermes.ViewModels.ReportViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hermes.ViewModels.ReturnTrips
{
    /// <summary>
    /// This allows the user to manipulate a Driver Log for
    /// a Return Trip
    /// </summary>
    public class DriverLog
    {
        HermesContext db = new HermesContext();
        VMFormats meth = new VMFormats();
        DriverLogViewModel vm;


        /// <summary>
        /// Creates a Driver Log entry for a return trip
        /// </summary>
        /// <param name="regularId">regularId</param>
        /// <returns>DriverLogViewModel object</returns>
        public DriverLogViewModel CreateRTVM(int regularId)
        {
            Regular regular = db.Regulars.Find(regularId);

            foreach (var rt in regular.ReturnTrips.Where(x=>x.Id != null)) {

                //Create a new driver log
                vm = new DriverLogViewModel() { 
                    
                    //Set 
                    PickupTime = meth.convertTimeToDate(rt.PickupTime.Value),
                    Date = regular.Date,
                    PickupLocation = meth.ReturnPickupLocation(regular.Id),
                    Destination = meth.ReturnDestinationLocation(regularId),
                    TripType = regular.TripType.Name,
                    Member = regular.Member.Name,
                    Count = meth.CountGuests(regular.Id),
                    emailaddress = regular.Email,
                    Phone = regular.Phone,
                    Notes = regular.Notes

                };
            }

            return vm;

        }
    }
}
