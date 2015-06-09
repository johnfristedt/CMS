using CMS.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace CMS.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            if (!Membership.ValidateUser(model.Username, model.Password))
            {
                ModelState.AddModelError("Username", "Invalid user name or password.");
                return View(model);
            }

            FormsAuthentication.SetAuthCookie(model.Username, false);

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            if (Membership.GetUser(model.UserName) != null)
            {
                ModelState.AddModelError("UserName", "User name is taken");
                return View(model);
            }
            else if (Membership.GetUserNameByEmail(model.Email) != null)
            {
                ModelState.AddModelError("Email", "A user with that e-mail already exists");
                return View(model);
            }

            MembershipCreateStatus status;
            Membership.CreateUser(model.UserName,
                                  model.Password,
                                  model.Email,
                                  model.Question,
                                  model.Answer,
                                  true,
                                  out status);

            Roles.AddUserToRole(model.UserName, "ROLE_USER");

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Home");
        }
    }
}