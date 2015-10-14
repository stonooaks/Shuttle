using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hermes.ViewModels.Common;
using Hermes.Data.Models;

namespace Hermes.ViewModels.ReportViewModel
{
    public class DriverLogViewModel
    {

        HermesContext db = new HermesContext();
        VMFormats meth = new VMFormats();

        #region Constructors
        /// <summary>
        /// Default Constructor
        /// </summary>
        public DriverLogViewModel()
        {

        }

        /// <summary>
        /// Constructor to create vm objects out of regular objects
        /// </summary>
        /// <param name="regularId"></param>
        public DriverLogViewModel(int regularId)
        {
            Regular regular = db.Regulars.Find(regularId);

            Household household = db.Households.Find(regular.HHID);
 
            if (PickupTime != null) {

                this.PickupTime = meth.convertTimeToDate(regular.PickupTime);
                this.Date = regular.Date;
                this.PickupLocation = meth.PickupLocation(regular.Id);
                this.Destination = meth.DestinationLocation(regular.Id);
                this.TripType = regular.TripType.Name;
                this.Member = regular.Member.Name;
                this.Household = regular.Household.Name;
                this.Count = meth.CountGuests(regular.Id);
                this.emailaddress = regular.Email;
                this.Phone = regular.Phone;
                this.Notes = regular.Notes;
                this.HHID = regular.HHID;
                this.MemberId = regular.MemberId.Value;
                this.regularId = regular.Id;
                this.Cost = meth.calculateTripCost(regularId);
                this.KiawahAddress = household.KiawahAddresses.First().Address1;
                
            }

        }

        #endregion

        #region Properties
        public DateTime PickupTime { get; set; }
        public DateTime Date { get; set; }
        public string PickupLocation { get; set; }
        public string Destination { get; set; }
        public string TripType { get; set; }
        public string Member { get; set; }
        public string Household { get; set; }
        public int Count { get; set; }
        public string emailaddress { get; set; }
        public string Phone { get; set; }
        public string Notes { get; set; }
        public int HHID { get; set; }
        public int MemberId { get; set; }
        public int regularId { get; set; }
        public double Cost { get; set; }
        public string KiawahAddress { get; set; }

        #endregion
    }
}
