﻿using System.Web;
using System.Web.Mvc;

namespace Institute_Of_Fine_Arts
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
