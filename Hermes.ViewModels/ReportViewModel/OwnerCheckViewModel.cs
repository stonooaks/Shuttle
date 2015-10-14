using Hermes.Data.Models;
using Hermes.Service;
using Hermes.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hermes.ViewModels.ReportViewModel
{
    public class OwnerCheckViewModel
    {

        HermesContext db = new HermesContext();
        VMFormats vmf = new VMFormats();

        #region Constructor
        /// <summary>
        /// Default Constructor to create an
        /// OwnerCheckViewModel
        /// </summary>
        public OwnerCheckViewModel()
        {

        }

        /// <summary>
        /// Constructor to create an OwnerCheckViewModel
        /// with a regular Id
        /// </summary>
        /// <param name="OwnerName"></param>
        public OwnerCheckViewModel(int regularId)
        {
            //Create a regular list from household name given
            Regular regular = db.Regulars.Find(regularId);

            //Set properties equal to regular property value 
            this.regularId = regular.Id;
            this.HouseholdName = regular.Household.Name;
            this.TripType = regular.TripType.Name;
            this.Date = regular.Date;
            this.Count = vmf.CountGuests(regularId);
        } 
        #endregion

        #region Properties
        public int regularId { get; set; }
        public string HouseholdName { get; set; }
        public string TripType { get; set; }
        public DateTime Date { get; set; }
        public int Count { get; set; }
        
        #endregion
    }
}
