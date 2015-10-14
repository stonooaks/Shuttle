using Hermes.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hermes.ViewModels.MainViewModels
{
    [System.Runtime.InteropServices.GuidAttribute("ADB11385-0533-44F9-B7F1-1403FE951602")]
    public class RegularViewModel1
    {
        HermesContext db = new HermesContext();

        public RegularViewModel1()
        {

        }

        public RegularViewModel1(int regularId)
        {
            Regular regular = db.Regulars.Find(regularId);
            this.RegularId = regularId;
            this.HHID = regular.HHID;
            this.MemberId = regular.MemberId;
            this.TripTypeId = regular.TripTypeId;
            this.KiawahLocation = regular.KiawahLocation;
            this.TripLocation = regular.TripLocation;
            this.NonKiawahPickup = regular.NonKiawahPickup;
            this.DriverId = regular.DriverId;
            this.Date = regular.Date;
            this.Members = regular.Members;
            this.VehicleId = regular.VehicleId;
            this.OfficerName = regular.OfficerName;
            this.Email = regular.Email;
            this.Notes = regular.Notes;
            this.Phone = regular.Phone;
            this.OtherAddress = regular.otherAddress;
        }

        public int RegularId { get; set; }
        public int HHID { get; set; }
        public Nullable<int> MemberId { get; set; }
        public int TripTypeId { get; set; }

        [Required(ErrorMessage = "Please Select a Kiawah Location")]
        public string KiawahLocation { get; set; }

        [Required(ErrorMessage = "Please enter a Trip Location")]
        public string TripLocation { get; set; }
        public bool NonKiawahPickup { get; set; }
        public Nullable<int> DriverId { get; set; }

        [DataType(DataType.DateTime)]
        public System.DateTime Date { get; set; }

        //[DataType(DataType.Time)]
        //[Required(ErrorMessage = "Please enter a pickup time")]
        //public System.TimeSpan PickupTime { get; set; }

        [Required(ErrorMessage = "Please Type your Name here")]
        public string OfficerName { get; set; }

        [Required(ErrorMessage="Please Enter a Vehicle")]
        public Nullable<int> VehicleId { get; set; }

        [Required(ErrorMessage = "An Email is Required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.MultilineText)]
        public string Notes { get; set; }
                
        [DataType(DataType.PhoneNumber)]
        [DisplayFormat(DataFormatString = "{0:(###) ###-####")]
        [Required(ErrorMessage = "A Phone Number is Required")]
        public string Phone { get; set; }
        public ICollection<Member> Members { get; set; }
        
        public string OtherAddress { get; set; }


        

        


    }
}
