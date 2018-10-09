using _2c2p_tech_test.DomainModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace _2c2p_tech_test.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("DefaultConnection") { }

        public DbSet<Card> Cards { get; set; }


        public Card excuteSelectCardByCardNumber(long cardNumber)
        {
            Card data = null;
            string sqlQuery;
            SqlParameter[] sqlParams;


            try
            {
                sqlQuery = "SelectCardByCardNumber @cardNumber";

                sqlParams = new SqlParameter[]
                {
                new SqlParameter { ParameterName = "@cardNumber",  Value =cardNumber , Direction = System.Data.ParameterDirection.Input},
                };

                using (DatabaseContext dbContext = new DatabaseContext())
                {
                    data = dbContext.Database.SqlQuery<Card>(sqlQuery, sqlParams).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                //handle, Log or throw exception 
            }

            return data;
        }

    }
}