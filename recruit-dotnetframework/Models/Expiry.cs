using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace recruit_dotnetframework.Models
{
    /// <summary>
    /// The Expiry class
    /// </summary>
    public class Expiry
    {
        /// <summary>
        /// Set Expiry Date
        /// </summary>
        public DateTime Date { get; private set; }

        /// <summary>
        /// Set the Expiry Date
        /// </summary>
        /// <param name="monthYear">The month year value</param>
        /// <exception cref="ArgumentException"></exception>
        public Expiry(string monthYear)
        {
            if (TryParse(monthYear, out DateTime date))
            {
                Date = date;
            }
            else
            {
                throw new ArgumentException("Invalid expiry date");
            }
        }

        /// <summary>
        /// Function to Parse Date
        /// </summary>
        /// <param name="monthYear">the month year</param>
        /// <param name="date">the output date</param>
        /// <returns></returns>
        private bool TryParse(string monthYear, out DateTime date)
        {
            date = default;
            var parts = monthYear.Split('/');
            if (
                parts.Length != 2
                || !int.TryParse(parts[0], out int month)
                || !int.TryParse(parts[1], out int year)
            )
            {
                return false;
            }

            // Validate month and year
            if (month < 1 || month > 12 || year < DateTime.Now.Year)
            {
                return false;
            }

            // Use the last day of the month for expiry
            var lastDayOfMonth = new DateTime(year, month, DateTime.DaysInMonth(year, month));
            if (lastDayOfMonth < DateTime.Now)
            {
                return false;
            }

            date = lastDayOfMonth;
            return true;
        }
    }
}
