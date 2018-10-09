using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using _2c2p_tech_test.Cards.Constants;
using _2c2p_tech_test.DomainModel;

namespace _2c2p_tech_test.Cards.Providers
{
    public class MasterProvider : BaseCardsProvider
    {
        public MasterProvider(long cardnumber, DateTime expiryDate)
        {
            _cardNumber = cardnumber;
            _expiryDate = expiryDate;
            _type = CardProviderTypes.MASTER;

        }
        public override bool IsValid()
        {
           if ((Math.Floor(Math.Log10(_cardNumber) + 1)) != 16 || ! IsPrime(_expiryDate.Year))
            {
                return false;
            }
            return true;
        }

       private bool IsPrime(int year)
        {

            if (year == 1) return false;
            if (year == 2) return true;

            var limit = Math.Ceiling(Math.Sqrt(year)); 

            for (int i = 2; i <= limit; ++i)
            {
                if (year % i == 0) return false;
            }

            return true;

        }

    }
}