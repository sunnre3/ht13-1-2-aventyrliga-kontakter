using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace AdventurousContacts.Controllers
{
    public class ErrorController : Controller
    {
        //
        // GET: /Error/404
		[ActionName("404")]
        public ActionResult HTTP_404()
        {
			Response.TrySkipIisCustomErrors = true;
			Response.StatusCode = (int)HttpStatusCode.NotFound;
            return View("NotFound");
        }

		//
		// GET: /Error/General
		public ActionResult General()
		{
			Response.TrySkipIisCustomErrors = true;
			Response.StatusCode = (int)HttpStatusCode.InternalServerError;
			return View("General");
		}

    }
}
