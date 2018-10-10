using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _2c2p_tech_test;
using _2c2p_tech_test.Controllers;
using _2c2p_tech_test.Cards.Constants;

namespace _2c2p_tech_test.Tests.Controllers
{
    [TestClass]
    public class CardsControllerTest
    {
       

      
        [TestMethod]
        public void ValidateCard()
        {
            CardsController controller = new CardsController();

            // first add 8 cards to db.

            var visa_valid = new Models.CardViewModel() { cardNumber = 4111111111111111, expiryDate_year = 2020, expiryDate_month = 1 };
            var visa_Invalid = new Models.CardViewModel() { cardNumber = 422211111111111, expiryDate_year = 2021, expiryDate_month = 1 };

            var master_valid = new Models.CardViewModel() { cardNumber = 5111111111111111, expiryDate_year = 2003, expiryDate_month = 1 };
            var master_Invalid = new Models.CardViewModel() { cardNumber = 5011111111111111, expiryDate_year = 2020, expiryDate_month = 1 };

            var JCB_valid = new Models.CardViewModel() { cardNumber = 3528111111111111  , expiryDate_year = 2003, expiryDate_month = 1 };
            var JCB_Invalid = new Models.CardViewModel() { cardNumber = 352811111111111, expiryDate_year = 2003, expiryDate_month = 1 };

            var amex_valid = new Models.CardViewModel() { cardNumber = 342811111111111, expiryDate_year = 2003, expiryDate_month = 1 };
            var amex_Invalid = new Models.CardViewModel() { cardNumber = 3428111111111111, expiryDate_year = 2003, expiryDate_month = 1 };
            try
            {
                Assert.AreEqual(controller.AddCard(visa_valid).message, "Card saved successfully");
                Assert.AreEqual(controller.AddCard(visa_Invalid).message, "Card saved successfully");
                Assert.AreEqual(controller.AddCard(master_Invalid).message, "Card saved successfully");
                Assert.AreEqual(controller.AddCard(master_valid).message, "Card saved successfully");
                Assert.AreEqual(controller.AddCard(JCB_Invalid).message, "Card saved successfully");
                Assert.AreEqual(controller.AddCard(JCB_valid).message, "Card saved successfully");
                Assert.AreEqual(controller.AddCard(amex_Invalid).message, "Card saved successfully");
                Assert.AreEqual(controller.AddCard(amex_valid).message, "Card saved successfully");

            }
            catch (Exception e)
            {
                // already exist
            }



            var result1 = controller.ValidateCard(visa_valid);
            Assert.AreEqual(result1.result, "Valid");
            Assert.AreEqual(result1.type, CardProviderTypes.VISA);

            var result2 = controller.ValidateCard(visa_Invalid);
            Assert.AreEqual(result2.result, "Invalid");
            Assert.AreEqual(result2.type, CardProviderTypes.VISA);



            var result3 = controller.ValidateCard(master_valid);
            Assert.AreEqual(result3.result, "Valid");
            Assert.AreEqual(result3.type, CardProviderTypes.MASTER);

            var result4 = controller.ValidateCard(master_Invalid);
            Assert.AreEqual(result4.result, "Invalid");
            Assert.AreEqual(result4.type, CardProviderTypes.MASTER);



            var result5 = controller.ValidateCard(JCB_valid);
            Assert.AreEqual(result5.result, "Valid");
            Assert.AreEqual(result5.type, CardProviderTypes.JCB);

            var result6 = controller.ValidateCard(JCB_Invalid);
            Assert.AreEqual(result6.result, "Invalid");
            Assert.AreEqual(result6.type, CardProviderTypes.JCB);




            var result7 = controller.ValidateCard(amex_valid);
            Assert.AreEqual(result7.result, "Valid");
            Assert.AreEqual(result7.type, CardProviderTypes.AMEX);

            var result8 = controller.ValidateCard(amex_Invalid);
            Assert.AreEqual(result8.result, "Invalid");
            Assert.AreEqual(result8.type, CardProviderTypes.AMEX);

        }


    }
}
