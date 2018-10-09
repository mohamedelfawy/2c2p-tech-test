using _2c2p_tech_test.Cards;
using _2c2p_tech_test.Context;
using _2c2p_tech_test.DomainModel;
using _2c2p_tech_test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _2c2p_tech_test.Controllers
{
    public class CardsController : ApiController
    {
        private DatabaseContext db = new DatabaseContext();


        // POST api/ValidateCard
        [HttpPost]
        public ReturnResult ValidateCard(CardViewModel cardInfo)
        {
            var result = new ReturnResult();
            if(cardInfo != null)
            {
                DateTime expiryDate = new DateTime();
                try
                {
                     expiryDate = new DateTime(cardInfo.expiryDate_year, cardInfo.expiryDate_month, 1, 0, 0, 0);

                }
                catch(Exception e)
                {
                    result.message = "please make sure you enter 1. expiryDate year (Numeric between 1 and 9999) 2. expiryDate month (Numeric between 1 and 12)";
                    return result;
                }
                try
                {
                    // check if exist in database 
                    var data = db.excuteSelectCardByCardNumber(cardInfo.cardNumber);
                    if(data != null)
                    {
                        var provider = CardProviders.get(cardInfo.cardNumber, expiryDate);
                        if (provider != null)
                        {
                            result.type = provider._type;
                            bool isValid = provider.IsValid();
                            result.result = isValid ? "Valid" : "Invalid";

                        }
                        else
                        {
                            result.message = "please make sure you enter cardNumber (Numeric 15 or 16 digits)";
                        }
                    }
                    else
                    {
                        result.message = "Does not exist";

                    }


                    return result;
                }
                catch (Exception e)
                {
                    result.message = e.Message;
                    return result;

                }
            }
            else
            {
                result.message = "please make sure you enter 1.cardNumber (Numeric 15 or 16 digits)  2. expiryDate year (Numeric between 1753 and 9999) 3. expiryDate month (Numeric between 1 and 12)";
                return result;
            }
          

        }


        // POST api/AddCard
        [HttpPost]
        public ReturnResult AddCard(CardViewModel cardInfo)
        {
            var result = new ReturnResult();
            if (cardInfo != null)
            {
                DateTime expiryDate = new DateTime();
                try
                {
                    expiryDate = new DateTime(cardInfo.expiryDate_year, cardInfo.expiryDate_month, 1, 0, 0, 0);

                }
                catch (Exception e)
                {
                    result.message = "please make sure you enter 1. expiryDate year (Numeric between 1 and 9999) 2. expiryDate month (Numeric between 1 and 12)";
                    return result;
                }
                try
                {

                    if (cardInfo.cardNumber != 0 && ((Math.Floor(Math.Log10(cardInfo.cardNumber) + 1)) == 15 || (Math.Floor(Math.Log10(cardInfo.cardNumber) + 1)) == 16))
                    {

                        // save card
                        try
                        {
                            db.Cards.Add(new Card()
                            {
                                cardNumber = cardInfo.cardNumber,
                                expiryDate = expiryDate
                            });
                            db.SaveChanges();
                            result.message = "Card saved successfully";
                        }
                        catch(Exception e)
                        {
                            result.message = "there is already a card with the same number";

                        }


                    }
                    else
                    {
                        result.message = "please make sure you enter cardNumber (Numeric 15 or 16 digits)";
                    }

                    return result;
                }
                catch (Exception e)
                {
                    result.message = e.Message;
                    return result;

                }
            }
            else
            {
                result.message = "please make sure you enter 1.cardNumber (Numeric 15 or 16 digits)  2. expiryDate year (Numeric between 1753 and 9999) 3. expiryDate month (Numeric between 1 and 12)";
                return result;
            }


        }

    }
}
