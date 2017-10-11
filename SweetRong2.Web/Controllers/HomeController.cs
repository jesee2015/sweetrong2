using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SweetRong2.Web.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        [AllowAnonymous]
        public ActionResult Index()
        {
            var auth = Request.IsAuthenticated;
            var id = HttpContext.User.Identity;
            return View();
        }


    }
}
