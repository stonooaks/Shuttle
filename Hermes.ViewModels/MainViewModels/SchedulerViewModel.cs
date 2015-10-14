using Hermes.Data.Models;
using Hermes.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Hermes.ViewModels.MainViewModels
{
    public class SchedulerViewModel
    {
        HermesContext db = new HermesContext();
        VMFormats meth = new VMFormats();

        /// <summary>
        /// Standard Default Constructor
        /// </summary>
        public SchedulerViewModel()
        {

        }

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="regularId"></param>
        public SchedulerViewModel(int regularId)
        {
            Regular regular = db.Regulars.Find(regularId);

            if (!regular.IsCancelled) {
                this.id = regular.Id;
                this.start = startDate(regular);
                this.end = endDate(regular);
                this.title = Text(regular);
                this.allDay = false;
                this.url = "/Regular/Details/" + regularId;
            }

        }
        
        public int id { get; set; }
        public string start { get; set; }
        public string end { get; set; }
        public string title { get; set; }
        public bool allDay { get; set; }
        public string url { get; set; }

        private string startDate(Regular regular)
        {
            DateTime newStartDate;
            newStartDate = regular.Date.Add(regular.PickupTime);
            return newStartDate.ToString("yyyy-MM-ddTHH:mm:ssZ");
        }

        private string endDate(Regular regular)
        {
            DateTime newEndDate;
            TimeSpan time;
            if(regular.ReturnTrips.Count > 0)
                time = regular.ReturnTrips.First().PickupTime.Value;
            else
            {
                switch (regular.TripType.Name) {
                    case "Airport":
                        time = regular.PickupTime.Add(TimeSpan.FromHours(2));
                        break;

                    case "Downtown":
                        time = regular.PickupTime.Add(TimeSpan.FromHours(1.5));
                        break;

                    case "North Charleston":
                        time = regular.PickupTime.Add(TimeSpan.FromHours(3));
                        break;

                    case "West Ashley":
                        time = regular.PickupTime.Add(TimeSpan.FromHours(1.5));
                        break;

                    case "Daniel Island":
                        time = regular.PickupTime.Add(TimeSpan.FromHours(3));
                        break;

                    case "Mt. Pleasant":
                        time = regular.PickupTime.Add(TimeSpan.FromHours(3));
                        break;
                    default:
                        time = regular.PickupTime.Add(TimeSpan.FromHours(1));
                        break;
                }
            }
            newEndDate = regular.Date.Add(time);


            return newEndDate.ToString("yyyy-MM-ddTHH:mm:ssZ");
        }
        
        private string Text(Regular regular)
        {
            string text;
            return text = regular.TripType.Name + " - " + regular.TripLocation + System.Environment.NewLine + regular.Household.Name + System.Environment.NewLine + "Guests: " + meth.CountGuests(regular.Id) + "/10";
            

        }
    }
}
