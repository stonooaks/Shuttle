using Hermes.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hermes.Service
{
    public class ShoppingCartService
    {

        private HermesContext db = new HermesContext();
        

        #region Properties
        private Regular regular;

        public Regular Regular 
        {
            get { return regular;}
            set { regular = value;} 
        }
        private double totalCost;

        public double TotalCost
        {
            get { return totalCost; }
            set { totalCost = value; }
        }

        private int guestCount;
                
        public int GuestCount
        {
            get { return guestCount; }
            set { guestCount = value; }
        }

        private string pickUpTime;

        public string PickupTime
        {
            get { return pickUpTime; }
            set { pickUpTime = value; }
        }

        private string returnTime;

        public string ReturnTime
        {
            get { return returnTime; }
            set { returnTime = value; }
        }
        
        
        
        
        #endregion

        /// <summary>
        /// Empty Default Constructor
        /// </summary>
        public ShoppingCartService()
        {

        }

        /// <summary>
        /// Constructor to populate properties from the accompaning
        /// private methods
        /// </summary>
        /// <param name="regularId"></param>
        public ShoppingCartService(int regularId)
        {
            this.regular = db.Regulars.Find(regularId);
            this.guestCount = countGuests();
            this.totalCost = calculateTripCost();
            this.pickUpTime = convertPickupTime();
            this.returnTime = convertReturnTime();
        }


        #region Methods
        /// <summary>
        /// Calculate Cost of Trip
        /// </summary>
        /// <param name="regularId"></param>
        /// <returns></returns>
        public double calculateTripCost()
        {
            //Set TripTotal to 0
            double TripTotal = 0;

            //Adds the cost of an additional shuttle stop and adds it to the 
            //TripTotal
            foreach(var item in regular.AdditionalTrips.Where(x => x.Additional.Name == "Shuttle Stop")){
                double shuttlecost = (double)item.Additional.Cost;
                TripTotal = TripTotal + shuttlecost;
            }

            //Finds the tripId -- I have not figured out why
            int tripId = regular.TripTypeId;
            
            //Initialize the firstwo and secondtwo to 0
            double firstwo = 0.0;
            double secondtow = 0.0;

            //Adds the guestcount value to the integer variable count
            int count = guestCount;

            //Test to see if the trip type is the TGIF shuttle
            // then it takes the firstwo price (which is the one price per
            // person) and multiply it by the guest count
            if (regular.TripType.Name.Contains("TGIF")) {

                
                foreach (Cost cost in db.Costs.Where(x => x.TripTypeId == tripId)) {
                    firstwo = cost.twoperprice.Value;
                }
                TripTotal = TripTotal + firstwo * count;
            }

            //Test to see if the trip type is the Private Trip
            // then it takes the firstwo price (which is the one price per
            // hour) then mutiplies it by the endhour minus the 
            else if (regular.TripType.Name.Contains("Private")) {

                double starthour = regular.PickupTime.TotalHours;
                double endhour = 0.0;

                //this finds the price and adds it the variable firstwo
                foreach (Cost cost in db.Costs.Where(x => x.TripTypeId == tripId)) {
                     
                    firstwo = cost.twoperprice.Value;
                }
                
                //this finds the end hour
                foreach (var rtrip in regular.ReturnTrips) {

                    endhour = rtrip.PickupTime.Value.TotalHours;

                }
                
                //this finds the total hours by subtracting start hour from end hour
                double totalHour = endhour - starthour;

                //this does the price
                TripTotal = TripTotal + totalHour * firstwo;

                //if the price is negative, it adds another day worth of hours
                if (TripTotal < 0)
                    TripTotal = TripTotal + 24 * firstwo;



            }
            else {
                 foreach (Cost cost in db.Costs.Where(x => x.TripTypeId == tripId)) {


                    firstwo = cost.twoperprice.Value;
                    secondtow = cost.addperprice.Value;

                    if (regular.VehicleId.Value != 1) {

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


        /// <summary>
        /// This method determines the number of Guest per trip
        /// by taking a count of all the Members and Guests in the 
        /// Trip
        /// </summary>
        /// <param name="regularId"></param>
        /// <returns></returns>
        public int countGuests()
        {

            int count = 0;

            count = count + regular.Members.Count();
            count = count + regular.Guests.Count();

            return count;

        }

        public string convertPickupTime()
        {
            TimeSpan time = regular.PickupTime;
            DateTime dt = new DateTime(time.Ticks);


            return dt.ToString("hh:mm tt");


        }

        public string convertReturnTime()
        {
            
            TimeSpan time;

            foreach (var item in regular.ReturnTrips) {

                time = item.PickupTime.Value;
                DateTime dt = new DateTime(time.Ticks);



                return dt.ToString("hh:mm tt");
            }

            return "";


        } 
        #endregion
    }
}
