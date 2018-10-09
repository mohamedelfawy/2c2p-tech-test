using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _2c2p_tech_test.Models
{
    public class CardViewModel
    {
        public long cardNumber { get; set; }
        public int expiryDate_year { get; set; }
        public int expiryDate_month { get; set; }

    }
}