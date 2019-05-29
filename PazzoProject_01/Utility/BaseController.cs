using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DBRepostitory.Models;

namespace PazzoProject_01.Utility
{
    public class BaseController : Controller
    {
        protected NorthwindEntities db = null;

        public BaseController()
        {
            db = (NorthwindEntities)System.Web.HttpContext.Current.Items["db"];
        }

    }
}