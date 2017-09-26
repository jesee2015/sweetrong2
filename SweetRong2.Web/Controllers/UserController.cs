﻿using SweetRong2.BLL;
using SweetRong2.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SweetRong2.Web.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/
        [HttpGet]
        public ActionResult Register(User user)
        {
            return View(user);
        }

        [HttpPost]
        public ActionResult Create(User user)
        {
            UserService _ser = new UserService();
            user.UId = Guid.NewGuid();
            user.CreateDate = DateTime.Now;
            _ser.AddUser(user);
            return View();
        }

    }
}