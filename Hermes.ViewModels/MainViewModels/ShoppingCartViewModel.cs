using Hermes.Data.Models;
using Hermes.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hermes.ViewModels.MainViewModels
{
    public class ShoppingCartViewModel
    {
        private HermesContext db = new HermesContext();
        private ShoppingCartService sc;

        /// <summary>
        /// Empty Default Constructor
        /// </summary>
        public ShoppingCartViewModel()
        {
            
        }

        public ShoppingCartViewModel(int regularId)
        {
            sc = new ShoppingCartService(regularId);
 
            this.Regular = sc.Regular;
            this.TotalCost = Math.Round(sc.TotalCost,2);
            this.Date = String.Format("{0:dddd, MM/dd/yyyy}", this.Regular.Date);
            this.PickupTime = sc.PickupTime;
            this.ReturnTime = sc.ReturnTime;
            this.Count = sc.countGuests();
            this.MemberName = this.Regular.Member.Name;
            this.KiawahAddress = this.Regular.Household.KiawahAddresses.First().Address1;

            //check to see if the nonkiawahpickup has be checked
            if (Regular.NonKiawahPickup == true){

                //Set the four trip locations to their opposites values
                this.TripLocation = Regular.KiawahLocation;
                this.KiawahLocation = Regular.TripLocation;

                foreach (var rt in Regular.ReturnTrips) {
                    this.ReturnKiawahLocation = rt.TripLocation;
                    this.ReturnTripLocation = rt.KiawahLocation;
                }
            }
            else {

                //sets the four trip locations to their current values
                this.TripLocation = Regular.TripLocation;
                this.KiawahLocation = Regular.KiawahLocation;

                foreach (var rt in Regular.ReturnTrips) {
                    this.ReturnKiawahLocation = rt.KiawahLocation;
                    this.ReturnTripLocation = rt.TripLocation;
                }
            }
	{
		 
	}


        }


        public Regular Regular { get; set; }
        public string ReturnTripLocation { get; set; }
        public string ReturnKiawahLocation { get; set; }
        public string KiawahLocation { get; set; }
        public string TripLocation { get; set; }
        public double TotalCost { get; set; }
        public string Date { get; set; }
        public string PickupTime { get; set; }
        public string ReturnTime { get; set; }
        public int Count { get; set; }
        public string MemberName { get; set; }
        public string KiawahAddress { get; set; }
        public string Telephone { get; set; }

        
    }
}