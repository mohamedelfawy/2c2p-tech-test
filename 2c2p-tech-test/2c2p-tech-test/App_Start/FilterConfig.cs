﻿using System.Web;
using System.Web.Mvc;

namespace _2c2p_tech_test
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
