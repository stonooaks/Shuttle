using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hermes.Data.CustomAttributes
{
    class DateRangeAttribute : ValidationAttribute
    {
        private const string DateFormat = "MM/dd/yyyy";
        private const string DefaultErrorMessage = "'{0}' must be a date after {1:d}";

        public DateTime MinDate { get; set; }

        public DateRangeAttribute() : base(DefaultErrorMessage)
        {
            MinDate = DateTime.Now;
        }

        public override bool IsValid(object value)
        {
            if (value == null || !(value is DateTime)) {
                return true;
            }

            DateTime dateValue = (DateTime)value;
            return MinDate <= dateValue;
        }

        public override string FormatErrorMessage(string name)
        {
            return String.Format(CultureInfo.CurrentCulture, ErrorMessageString, name, MinDate);
        }


        private static DateTime ParseDate(string dateValue)
        {
           return DateTime.ParseExact(dateValue, DateFormat, CultureInfo.InvariantCulture);
        }
    }
}
