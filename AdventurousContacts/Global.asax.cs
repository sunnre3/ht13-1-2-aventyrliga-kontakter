﻿using AdventurousContacts.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace AdventurousContacts
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

		//protected void Application_Error()
		//{
		//	var exception = Server.GetLastError();
		//	var httpException = exception as HttpException;
		//	Response.Clear();
		//	Server.ClearError();
		//	var routeData = new RouteData();
		//	routeData.Values["controller"] = "Error";
		//	routeData.Values["action"] = "General";
		//	routeData.Values["exception"] = exception;
		//	Response.StatusCode = 500;
		//	//if (httpException != null)
		//	//{
		//	//	Response.StatusCode = httpException.GetHttpCode();
		//	//	switch (Response.StatusCode)
		//	//	{
		//	//		case 404:
		//	//			routeData.Values["action"] = "404";
		//	//			break;
		//	//	}
		//	//}
		//	// Avoid IIS7 getting in the middle
		//	Response.TrySkipIisCustomErrors = true;
		//	IController errorController = new ErrorController();
		//	HttpContextWrapper wrapper = new HttpContextWrapper(Context);
		//	var rc = new RequestContext(wrapper, routeData);
		//	errorController.Execute(rc);
		//}
    }
}