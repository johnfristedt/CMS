using AutoMapper;
using CMS.Models.DataModels;
using CMS.Models.Repositories;
using CMS.Models.ViewModels.CreateViewModels;
using CMS.Models.ViewModels.EditViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace CMS.Controllers
{
    [Authorize(Roles="ROLE_ADMIN")]
    public class AdminController : Controller
    {
        ISiteRepository repository;

        public AdminController(ISiteRepository repository)
        {
            this.repository = repository;
        }

        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateRole()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateRole(CreateRoleViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            Roles.CreateRole(model.RoleName);

            return RedirectToAction("Index");
        }

        public ActionResult ManageRoles()
        {
            EditRoleViewModel vm = new EditRoleViewModel
            {
                Roles = Mapper.Map<List<SelectListItem>>(Roles.GetAllRoles()),
                UsersInRole = new List<SelectListItem>(),
                AvailableUsers = new List<SelectListItem>()
            };

            return View(vm);
        }

        [HttpPost]
        public bool ManageRoles(UpdateRoleModel model)
        {
            if (!ModelState.IsValid)
                return false;

            foreach (var user in model.UsersInRole)
            {
                if (!Roles.GetUsersInRole(model.Role).Contains(user))
                    Roles.AddUserToRole(user, model.Role);
            }

            var usersInRole = Roles.GetUsersInRole(model.Role);

            foreach (var user in usersInRole)
            {
                if (!model.UsersInRole.Contains(user) && usersInRole.Contains(user))
                    Roles.RemoveUserFromRole(user, model.Role);
            }

            return true;
        }

        public ActionResult EditUser()
        {
            EditUserViewModel vm = new EditUserViewModel 
            { 
                Users = Mapper.Map<List<SelectListItem>>(Membership.GetAllUsers()),
                UserRoles = new List<SelectListItem>(),
                AvailableRoles = new List<SelectListItem>() 
            };

            return View(vm);
        }

        [HttpPost]
        public bool EditUser(UpdateUserModel model)
        {
            if (!ModelState.IsValid)
                return false;

            foreach (var role in model.UserRoles)
	        {
                if (!Roles.IsUserInRole(model.User, role))
                    Roles.AddUserToRole(model.User, role);
	        }

            var currentRoles = Roles.GetRolesForUser(model.User);

            foreach (var role in Roles.GetAllRoles())
            {
                if (!model.UserRoles.Contains(role) && currentRoles.Contains(role))
                    Roles.RemoveUserFromRole(model.User, role);
            }
            
            return true;
        }

        [HttpPost]
        public ActionResult GetRoleInfo(string role)
        {
            List<string> usersInRole = Roles.GetUsersInRole(role).ToList();
            List<string> availableUsers = Mapper.Map<List<string>>(Membership.GetAllUsers());

            foreach (var user in usersInRole)
            {
                if (availableUsers.Contains(user))
                    availableUsers.Remove(user);
            }

            RoleInfo info = new RoleInfo
            {
                UsersInRole = Mapper.Map<List<SelectListItem>>(usersInRole),
                AvailableUsers = Mapper.Map<List<SelectListItem>>(availableUsers)
            };

            return Json(info);
        }

        [HttpPost]
        public ActionResult GetUserRoleInfo(string username)
        {
            List<string> userRoles = Roles.GetRolesForUser(username).ToList();
            List<string> availableRoles = Roles.GetAllRoles().ToList();

            foreach (var role in userRoles)
            {
                if (availableRoles.Contains(role))
                    availableRoles.Remove(role);
            }

            UserRoleInfo info = new UserRoleInfo
            {
                UserRoles = Mapper.Map<List<SelectListItem>>(userRoles),
                AvailableRoles = Mapper.Map<List<SelectListItem>>(availableRoles)
            };

            return Json(info);
        }
    }
}