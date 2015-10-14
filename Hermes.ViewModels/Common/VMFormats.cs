/********************************************************************************
 * CLASS NAME:      VMFormats.cs
 * PROGRAMMER:      Michael Hughes
 * DESCRIPTION:     This class has all the common methods for counting and
 *                  formatting the View Model properties
 * VERSION:         1.0.0.0
 * CREATED DATE:    4/03/2014
 * MODIFIED DATE:
********************************************************************************/
        
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hermes.Data.Models;

namespace Hermes.ViewModels.Common
{
    /// <summary>
    /// This class has all the common methods for counting and
    /// formatting the View Model properties
    /// </summary>
    public class VMFormats
    {
        HermesContext db = new HermesContext();

        #region Public Methods

        /// <summary>
        /// Counts the number of guests
        /// </summary>
        /// <param name="regularId">the id of the trip</param>
        /// <returns>int count of guests</returns>
        public int CountGuests(int regularId)
        {
            int count = 0;
            var regular = db.Regulars.Find(regularId);
            count = count + regular.Members.Count();
            count = count + regular.Guests.Count();

            return count;
        }

        

        /// <summary>
        /// Formats the Time form TimeSpan to DateTime
        /// </summary>
        /// <param name="time">time</param>
        /// <returns>datetime conversion</returns>
        public DateTime convertTimeToDate(TimeSpan time)
        {
            DateTime date = new DateTime(time.Ticks);

            return date;
        }

        /// <summary>
        /// Decides which trip is the pickup
        /// </summary>
        /// <param name="regularId">regularId</param>
        /// <returns>string location</returns>
        public string PickupLocation(int regularId)
        {

            Regular regular = db.Regulars.Find(regularId);

            if (regular.NonKiawahPickup)
                return regular.TripLocation;
            else
                return regular.KiawahLocation;
        }

        /// <summary>
        /// Decides which trip is the dropoff
        /// </summary>
        /// <param name="regularId">regularId</param>
        /// <returns>string location</returns>
        public string DestinationLocation(int regularId)
        {
            Regular regular = db.Regulars.Find(regularId);

            if (regular.NonKiawahPickup)
                return regular.KiawahLocation;
            else
                return regular.TripLocation;
        }

        /// <summary>
        /// Decides which returntrip is the pickup
        /// </summary>
        /// <param name="regularId">regularId</param>
        /// <returns>string location</returns>
        public string ReturnPickupLocation(int regularId)
        {
            Regular regular = db.Regulars.Find(regularId);

            string location = "";
            foreach (var rt in regular.ReturnTrips) {

                if (regular.NonKiawahPickup)
                     location = rt.KiawahLocation;
                else
                    location = rt.TripLocation;
            }

            return location;
        }

        /// <summary>
        /// Decides which returntrip is the destination
        /// </summary>
        /// <param name="regularId">regularId</param>
        /// <returns>string location</returns>
        public string ReturnDestinationLocation(int regularId)
        {
            Regular regular = db.Regulars.Find(regularId);

            string location = "";
            foreach (var rt in regular.ReturnTrips) {

                if (regular.NonKiawahPickup)
                    location = rt.TripLocation;
                else
                    location = rt.KiawahLocation;
            }

            return location;
        }

        /// <summary>
        /// Calculates the trip cost
        /// </summary>
        /// <param name="regularId"></param>
        /// <returns></returns>
        public double calculateTripCost(int regularId)
        {
            Regular regular = db.Regulars.Find(regularId);

            //Shuttle Stop additional Cost
            //sets the TripTotal to 0
            double TripTotal = 0;

            //foreach shuttle stop taken, the cost is added to the TripTotal
            foreach (var item in regular.AdditionalTrips.Where(x => x.Additional.Name == "Shuttle Stop")) {
                double shuttlecost = (double)item.Additional.Cost;
                TripTotal = TripTotal + shuttlecost;
            }

            //Finding the TripType Id and zeroing the two person and addition person prices
            int tripId = regular.TripTypeId;
            double firstwo = 0.0;
            double secondtow = 0.0;

            //Finds the count of Guests
            int count = CountGuests(regularId);

            
            //TGIF Shuttle Charges
            if (regular.TripType.Name.Contains("TGIF")) {

                //The TGIF shuttle is a per person so the event
                foreach (Cost cost in db.Costs.Where(x=>x.TripTypeId == tripId)) {
                    firstwo = cost.twoperprice.Value;
                }
                                
                TripTotal = TripTotal + firstwo * count;


            }

            //Private Shuttle Charges
            else if (regular.TripType.Name.Contains("Private")) {

                double starthour = regular.PickupTime.TotalHours;
                double endhour = 0.0;

                foreach (Cost cost in db.Costs.Where(x => x.TripTypeId == tripId)) {

                    firstwo = cost.twoperprice.Value;
                }

                foreach (var rtrip in regular.ReturnTrips) {

                    endhour = rtrip.PickupTime.Value.TotalHours;

                }
                double totalHour = endhour - starthour;
                TripTotal = TripTotal + totalHour * firstwo;

                if (TripTotal < 0) {

                    TripTotal = TripTotal + 24 * firstwo;
                }


            }

            //All Other Charges
            else {
                foreach (Cost cost in db.Costs.Where(x => x.TripTypeId == tripId)) {
                    
                    firstwo = cost.twoperprice.Value;
                    secondtow = cost.addperprice.Value;

                    if (regular.VehicleId != 1) {

                        firstwo = firstwo * .75;
                        secondtow = secondtow * .75;
                    }
                }

                if (count > 2) {
                    int otherguest = count - 2;
                    double first = firstwo;
                    double second = secondtow * otherguest;
                    TripTotal = TripTotal + first + second;
                    return TripTotal;
                }
                else {
                    return firstwo;
                }
            }


            return TripTotal;
        }
        #endregion
    }
}
