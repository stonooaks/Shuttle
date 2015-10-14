using Hermes.Data.Models;
using Hermes.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hermes.ViewModels.Google
{
    /// <summary>
    /// CalendarViewModel for the modeling of regular objects
    /// </summary>
    public class CalendarViewModel
    {
        HermesContext db = new HermesContext();
        VMFormats vf = new VMFormats();

        /// <summary>
        /// Default Constructor
        /// </summary>
        public CalendarViewModel()
        {
            //Nada
        }

        /// <summary>
        /// Constructor that accepts a regularId
        /// </summary>
        /// <param name="regularId">integer regularId</param>
        public CalendarViewModel(int regularId)
        {
            //Create a new regular object based on the regularId
            Regular regular = db.Regulars.Find(regularId);

            MemberName = regular.Member.ToString();
            Count = (int)regular.Count.Value - 1;
            TripType = regular.TripType.Name;
            StartDate = regular.Date.ToString("yyyy-mm-dd");
            
            StartTime = vf.convertTimeToDate(regular.PickupTime);

            //Required because the ReturnTrip is a collection
            foreach (var rt in regular.ReturnTrips) {
                EndDate = regular.Date.ToString("yyyy-mm-dd");
                //EndTime = vf.convertTimeToDate(rt.PickupTime.value);
            }

            CreatedBy = regular.OfficerName.ToString();
            Comment = regular.Phone.ToString();
            Description = regular.Notes.ToString();
            Email = regular.Email.ToString();
            NonKiawahPickup = regular.NonKiawahPickup;
            Id = regular.Id.ToString();

        }

        public string MemberName { get; set; }
        public int Count { get; set; }
        public string TripType { get; set; }
        
        [DataType(DataType.Date)]
        public string StartDate { get; set; }
        public DateTime StartTime { get; set; }

        [DataType(DataType.Date)]
        public string EndDate { get; set; }
        public DateTime EndTime { get; set; }

        public string CreatedBy { get; set; }
        public string Comment { get; set; }

        public string Description { get; set; }
        public string Email { get; set; }
        public bool NonKiawahPickup { get; set; }
        public string Id { get; set; }

      
    }

    
}
