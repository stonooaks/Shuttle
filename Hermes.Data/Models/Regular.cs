using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Hermes.Data.Models
{
    
        public partial class Regular
    {
        public Regular()
        {
            this.AdditionalTrips = new List<AdditionalTrip>();
            this.Guests = new List<Guest>();
            this.ReturnTrips = new List<ReturnTrip>();
            this.ShoppingCarts = new List<ShoppingCart>();
            this.Members = new List<Member>();
        }

        

        public int Id { get; set; }
        public int HHID { get; set; }
        public Nullable<int> MemberId { get; set; }
        public int TripTypeId { get; set; }

        [Required(ErrorMessage = "Please Select a Kiawah Location")]
        public string KiawahLocation { get; set; }

        [Required(ErrorMessage = "Please enter a Trip Location")]
        public string TripLocation { get; set; }
        public bool NonKiawahPickup { get; set; }
        public Nullable<int> DriverId { get; set; }
        
        [DataType(DataType.Date)]
        public System.DateTime Date { get; set; }

        [DataType(DataType.Time)]
        [Required(ErrorMessage = "Please enter a pickup time")]
        public System.TimeSpan PickupTime { get; set; }

        [Required(ErrorMessage = "Please Type your Name here")]
        public string OfficerName { get; set; }
        
        
        public Nullable<int> VehicleId { get; set; }

        [Required(ErrorMessage = "An Email is Required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.MultilineText)]
        public string Notes { get; set; }

        public bool IsCancelled { get; set; }
        public string otherAddress { get; set; }

        [DataType(DataType.PhoneNumber)]
        [DisplayFormat(DataFormatString="{0:(###) ###-####")]
        [Required(ErrorMessage = "A Phone Number is Required")]
        public string Phone { get; set; }

        public Nullable<int> Count { get; set; }
        public Nullable<double> Cost { get; set; }
        public virtual ICollection<AdditionalTrip> AdditionalTrips { get; set; }
        public virtual Driver Driver { get; set; }
        public virtual ICollection<Guest> Guests { get; set; }
        public virtual Household Household { get; set; }
        public virtual Member Member { get; set; }
        public virtual TripType TripType { get; set; }
        public virtual Vehicle Vehicle { get; set; }
        public virtual ICollection<ReturnTrip> ReturnTrips { get; set; }
        public virtual ICollection<ShoppingCart> ShoppingCarts { get; set; }
        public virtual ICollection<Member> Members { get; set; }
    }
}
