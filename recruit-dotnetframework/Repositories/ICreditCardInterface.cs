using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using recruit_dotnetframework.Models;

namespace recruit_dotnetframework.Repositories
{
    public interface ICreditCardInterface
    {
        /// <summary>
        /// Function to Add Credit card
        /// </summary>
        /// <param name="card">the credit card</param>
        void Add(CreditCard card);
        
        /// <summary>
        /// Function to Get Specific card
        /// </summary>
        /// <param name="id">The Credit Card Id</param>
        /// <returns>The Credit card</returns>
        CreditCard Get(int id);

        /// <summary>
        /// Function the get the credit card objects
        /// </summary>
        /// <returns>all credit cards</returns>
        IEnumerable<CreditCard> GetAll();

        /// <summary>
        /// Delete credit card
        /// </summary>
        /// <param name="card">The Credit card</param>
        void Delete(int id);
    }
}
