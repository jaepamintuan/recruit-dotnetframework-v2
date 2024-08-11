using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using recruit_dotnetframework.Controllers;
using recruit_dotnetframework.Models;

namespace CreditCardApi.Tests
{
    [TestClass]
    public class CreditCardControllerTests
    {
        private CreditCardController _controller;

        [TestInitialize]
        public void Setup()
        {
            _controller = new CreditCardController { };
        }

        /// <summary>
        /// add one card
        /// </summary>
        [TestMethod]
        public void AddCard_ShouldAddCard()
        {
            var cvc = new CVC("123");
            var expiry = new Expiry("01/2026");
            var card = new CreditCard(1, "1234567812345678", cvc, expiry);

            var result = _controller.AddCard(card) as OkNegotiatedContentResult<CreditCard>;

            Assert.IsNotNull(result);
            Assert.AreEqual(card.CardNumber, result.Content.CardNumber);
        }


        /// <summary>
        /// Get one card
        /// </summary>
        [TestMethod]
        public void GetCard_ShouldReturnCard()
        {
            var cvc = new CVC("123");
            var expiry = new Expiry("01/2026");
            var card = new CreditCard(1, "1234567812345678", cvc, expiry);

            _controller.AddCard(card);

            var result = _controller.GetCard(1) as OkNegotiatedContentResult<CreditCard>;

            Assert.IsNotNull(result);
            Assert.AreEqual(card.CardNumber, result.Content.CardNumber);
        }

        /// <summary>
        /// Get all cards and delete 1 card and check
        /// </summary>
        [TestMethod]       
        public void GetAllCardsAndDelete()
        {
            var cvc1 = new CVC("123");
            var expiry1 = new Expiry("01/2026");
            var card1 = new CreditCard(1, "1234567812345678", cvc1, expiry1);

            var cvc2 = new CVC("356");
            var expiry2 = new Expiry("01/2027");
            var card2 = new CreditCard(2, "1111222233334444", cvc2, expiry2);

            _controller.AddCard(card1);

            var result = _controller.GetCard(1) as OkNegotiatedContentResult<CreditCard>;

            Assert.IsNotNull(result);
            Assert.AreEqual(card1.CardNumber, result.Content.CardNumber);

            _controller.AddCard(card2);

            result = _controller.GetCard(2) as OkNegotiatedContentResult<CreditCard>;

            Assert.IsNotNull(result);
            Assert.AreEqual(card2.CardNumber, result.Content.CardNumber);

            var result1 =
                _controller.GetAllCards() as OkNegotiatedContentResult<IEnumerable<CreditCard>>;

            Assert.IsNotNull(result1);
            Assert.AreEqual(2, result1.Content.Count());

            //delete card and check count, can add more test as desired with time

            var deleteResult = _controller.Delete(2) as OkNegotiatedContentResult<IEnumerable<CreditCard>>;
            Assert.IsNotNull(result1);
            Assert.AreEqual(1, result1.Content.Count());
        }


    }
}
