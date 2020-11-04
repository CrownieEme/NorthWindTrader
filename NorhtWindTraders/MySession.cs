using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security;

namespace NorhtWindTraders
{
    public class MySession
    {

        public static string Email 
        {
            get
            {
                if(HttpContext.Current.Session["Email"] != null)
                   return  HttpContext.Current.Session["Email"].ToString();
                else
                    return "";
            }

            set
            {
                 HttpContext.Current.Session["Email"] = value; 
            }
                
        }

        public static string CustomerID
        {
            get
            {
                if (HttpContext.Current.Session["custid"] != null)
                    return HttpContext.Current.Session["custid"].ToString();
                else
                    return "";
            }

            set
            {
                HttpContext.Current.Session["custid"] = value;
            }

        }
    }
}