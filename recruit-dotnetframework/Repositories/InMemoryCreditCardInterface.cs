using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using recruit_dotnetframework.Models;
using recruit_dotnetframework.Repositories;

namespace recruit_dotnetframework.Interface
{
    public class InMemoryCreditCardInterface : ICreditCardInterface
    {
        private readonly List<CreditCard> _cards = new List<CreditCard>();

        public void Add(CreditCard card)
        {
            card.Id = _cards.Count + 1;
            _cards.Add(card);
        }

        public CreditCard Get(int id)
        {
            return _cards.FirstOrDefault(c => c.Id == id);
        }

        public IEnumerable<CreditCard> GetAll()
        {
            return _cards;
        }

        public void Delete(int id)
        {
            _cards.Remove( _cards.FirstOrDefault(c => c.Id == id));
        }
    
    }
}
