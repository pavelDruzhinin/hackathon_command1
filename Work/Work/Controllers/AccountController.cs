using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Security;
using Work.Services;
using Work.Models;
using System.Web.Mvc;

namespace Work.Controllers
{
    public class AccountController : Controller
    {

        private AccountService _accountService;
        public AccountController()
        {
            _accountService = new AccountService();
        }
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model)
        {
            if (_accountService.Login(model.Login, model.Password))
            {
                FormsAuthentication.SetAuthCookie(model.Login, true);
                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("", "Что-то не так!");
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Edit(LoginViewModel model)
        {
            if (_accountService.Login(model.Login, model.Password))
            {
                FormsAuthentication.GetAuthCookie(model.Login, true);
                return RedirectToAction("Edit", "Users");
            }
            ModelState.AddModelError("", "Что-то не так!");
            return View(model);
        }


    }
}