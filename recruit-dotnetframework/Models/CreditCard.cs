using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace recruit_dotnetframework.Models
{
    /// <summary>
    /// The Credit Card Class
    /// </summary>
    public class CreditCard
    {
        /// <summary>
        /// The unique Id of the credit card
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The card number
        /// </summary>
        public string CardNumber { get; private set; }

        /// <summary>
        /// The CVC property
        /// </summary>
        public CVC CardCVC { get; private set; }

        /// <summary>
        /// The Expiry property
        /// </summary>
        public Expiry CardExpiry { get; private set; }

        /// <summary>
        /// The constructor
        /// </summary>
        /// <param name="id">The id</param>
        /// <param name="cardNumber">the card number</param>
        /// <param name="cvc">The CVC</param>
        /// <param name="expiry">The expiry</param>
        /// <exception cref="ArgumentException"></exception>
        public CreditCard(int id, string cardNumber, CVC cvc, Expiry expiry)
        {
            if (IsValidCardNumber(cardNumber))
            {
                Id = id;
                CardNumber = cardNumber;
                CardCVC = cvc;
                CardExpiry = expiry;
            }
            else
            {
                throw new ArgumentException("Invalid card number");
            }
        }

        /// <summary>
        /// Function that checks if card number is invalid
        /// </summary>
        /// <param name="cardNumber"></param>
        /// <returns></returns>
        private bool IsValidCardNumber(string cardNumber)
        {
            // Basic validation: length and numeric characters
            return !string.IsNullOrWhiteSpace(cardNumber)
                && cardNumber.Length >= 13
                && cardNumber.Length <= 19
                && long.TryParse(cardNumber, out _);
        }
    }
}
