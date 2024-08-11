using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using Newtonsoft.Json.Linq;

namespace recruit_dotnetframework.Models
{
    /// <summary>
    /// The CVC class
    /// </summary>
    public class CVC
    {
        public string Value { get; private set; }
        
        /// <summary>
        /// The CVC constructor
        /// </summary>
        /// <param name="value">the cvc value</param>
        /// <exception cref="ArgumentException"></exception>
        public CVC(string value)
        {
            if (IsValid(value))
            {
                Value = value;
            }
            else
            {
                throw new ArgumentException("Invalid CVC");
            }
        }

        /// <summary>
        /// Function that checks if the CVC value is valid
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private bool IsValid(string value)
        {
            // CVC is typically 3 or 4 digits long
            return Regex.IsMatch(value, @"^\d{3,4}$");
        }
    }
}
