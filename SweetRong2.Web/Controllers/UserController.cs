using SweetRong2.BLL;
using SweetRong2.Domain;
using SweetRong2.IBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SweetRong2.Web.Controllers
{
    public class UserController : Controller
    {
        IUserService _userService;
        public UserController(IUserService userservice)
        {
            _userService = userservice;
        }
        //
        // GET: /User/
        [HttpGet]
        public ActionResult Register(User user)
        {
            return View(user);
        }

        [HttpPost]
        public void Create(User user)
        {
            user.UId = Guid.NewGuid();
            user.CreateDate = DateTime.Now;
            _userService.AddEntity(user);
            FormsAuthentication.SetAuthCookie(user.UName, true);
            RedirectToAction("index", "home");
        }

        public ActionResult Login()
        {
            return View();
        }
    }
}
