using _2c2p_tech_test.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _2c2p_tech_test.Cards
{
    public abstract class BaseCardsProvider
    {
        public long _cardNumber { get; set; }
        public DateTime _expiryDate { get; set; }

        public string _type;

        public abstract bool IsValid();

      
    }
}