// Controllers/CreditCardController.cs
using System.Collections.Generic;
using System.Web.Http;
using recruit_dotnetframework.Interface;
using recruit_dotnetframework.Models;
using recruit_dotnetframework.Repositories;

namespace recruit_dotnetframework.Controllers
{
    public class CreditCardController : ApiController
    {
        private readonly ICreditCardInterface _repository;

        public CreditCardController()
        {
            _repository = new InMemoryCreditCardInterface(); 
        }

        [HttpPost]
        public IHttpActionResult AddCard(CreditCard card)
        {
            if (card == null)
            {
                return BadRequest("Invalid card data.");
            }

            _repository.Add(card);
            return Ok(card);
        }

        [HttpGet]
        public IHttpActionResult GetCard(int id)
        {
            var card = _repository.Get(id);
            if (card == null)
            {
                return NotFound();
            }

            return Ok(card);
        }

        [HttpGet]
        public IHttpActionResult GetAllCards()
        {
            var cards = _repository.GetAll();
            return Ok(cards);
        }

        [HttpPost]
        public IHttpActionResult Delete(int id)
        {
            _repository.Delete(id);
            return Ok(id);
        }

    }
}
