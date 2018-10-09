using _2c2p_tech_test.Cards.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _2c2p_tech_test.Cards
{
    public class CardProviders
    {
        public static BaseCardsProvider get(long cardNumber,DateTime expiryDate)
        {
            if(cardNumber != 0 && ((Math.Floor(Math.Log10(cardNumber) + 1)) == 15 || (Math.Floor(Math.Log10(cardNumber) + 1)) == 16))
            {
                if(cardNumber.ToString().StartsWith("4"))
                {
                    return new VisaProvider(cardNumber, expiryDate);
                }
                if(cardNumber.ToString().StartsWith("5"))
                {
                    return new MasterProvider(cardNumber, expiryDate);
                }
                if(cardNumber.ToString().StartsWith("34")|| cardNumber.ToString().StartsWith("37"))
                {
                    return new AmexProvider(cardNumber, expiryDate);
                }
                if(cardNumber.ToString().StartsWith("3528") || cardNumber.ToString().StartsWith("3589"))
                {
                    return new JCBProvider(cardNumber, expiryDate);
                }
                return new UnknownProvider(cardNumber, expiryDate);

            }
            return null;
        }
    }
}