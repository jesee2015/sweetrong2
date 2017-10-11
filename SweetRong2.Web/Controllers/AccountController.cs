﻿using SweetRong2.IBLL;
using SweetRong2.Utility;
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
            return Json("注销成功");
        }


        /// <summary>
        /// 验证码的实现
        /// </summary>
        /// <returns></returns>
        public ActionResult CheckCode()
        {
            //首先实例化验证码的类
            ValidateCode validateCode = new ValidateCode();
            //生成验证码指定的长度
            string code = validateCode.CreateValidateCode(5);
            //将验证码赋值给Session变量
            Session["ValidateCode"] = code;
            //创建验证码的图片
            byte[] bytes = validateCode.CreateValidateGraphic(code);
            //最后将验证码返回
            return File(bytes, @"image/jpeg");
        }

    }
}
