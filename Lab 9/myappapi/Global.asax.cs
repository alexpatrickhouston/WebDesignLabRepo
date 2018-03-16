using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace myappapi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            AppDomain.CurrentDomain.SetData("DataDirectory", @"C:\Users\Alex Houston\Desktop\Winter 2018\Web Design\Lab Repo\WebDesignLabRepo\Lab 4 - Copy\Lab4\App_Data");
        }
    }
}
