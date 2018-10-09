using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using _2c2p_tech_test.Cards.Constants;
using _2c2p_tech_test.DomainModel;

namespace _2c2p_tech_test.Cards.Providers
{
    public class UnknownProvider : BaseCardsProvider
    {
      
        public UnknownProvider(long cardnumber , DateTime expiryDate)
        {
            _cardNumber = cardnumber;
            _expiryDate = expiryDate;
            _type = CardProviderTypes.UNKNOWN;
        }
        public override bool IsValid()
        {
            return false;
        }
    }
}