using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using _2c2p_tech_test.Cards.Constants;
using _2c2p_tech_test.DomainModel;

namespace _2c2p_tech_test.Cards.Providers
{
    public class AmexProvider : BaseCardsProvider
    {
      
        public AmexProvider(long cardnumber, DateTime expiryDate)
        {
            _cardNumber = cardnumber;
            _expiryDate = expiryDate;
            _type = CardProviderTypes.AMEX;

        }
        public override bool IsValid()
        {

            if ((Math.Floor(Math.Log10(_cardNumber) + 1)) != 15)
            {
                return false;
            }
            return true;
        }
    }
}