using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _2c2p_tech_test.DomainModel
{
    public class Card
    {
        [Key]
        public int Id { get; set; }
        [Index("IX_cardNumber", 1, IsUnique = true)]
        public long cardNumber { get; set; }
        public DateTime expiryDate { get; set; }
    }
}