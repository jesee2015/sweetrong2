using SweetRong2.IBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SweetRong2.Web.Controllers
{
    public class AccountController : Controller
    {
        IUserService _userService;
        public AccountController(IUserService userService)
        {
            _userService = userService;
        }
        //
        // GET: /Account/
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("index", "home");
            }
            ViewBag.returnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        public ActionResult Login(SweetRong2.Domain.User user, string returnUrl)
        {
            var users = _userService.LoadEntities(c => c.UName == user.UName && c.UPwd == user.UPwd).ToList();
            if (users != null && users.Count > 0)
            {
                FormsAuthentication.SetAuthCookie(user.UName, true);
                return RedirectToAction("index", "home");
            }
            return View();
        }

        [HttpPost]
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("index", "home");
        }

    }
}
