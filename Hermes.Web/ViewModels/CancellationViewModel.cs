using Hermes.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hermes.Web.ViewModels
{
    public class CancellationViewModel
    {
        //Create a private HermesContext object
        private HermesContext db = new HermesContext();

        #region Constructors
        /// <summary>
        /// Empty default constructor
        /// </summary>
        public CancellationViewModel()
        {

        }

        /// <summary>
        /// Creates a CancellationViewModel object based on the regular object
        /// found by the Find() method
        /// </summary>
        /// <param name="regularId"></param>
        public CancellationViewModel(int regularId)
        {
            this.regular = db.Regulars.Find(regularId);

            Member = regular.Member.Name.ToString();
            Address = regular.Household.KiawahAddresses.First().Address1.ToString();
            Phone = regular.Phone.ToString();
            Household = regular.Household.Name.ToString();
            Date = String.Format("{0:dddd, MM/dd/yyyy}", regular.Date);
            Location = regular.TripLocation.ToString();
            Email = regular.Email.ToString();
        } 
        #endregion

        #region Properties
        /// <summary>
        /// Create properties for the 
        /// </summary>
        public Regular regular { get; set; }
        public string Household { get; set; }
        public string Member { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Location { get; set; }
        public string Date { get; set; }
        public string Email { get; set; }
        #endregion
    }
}