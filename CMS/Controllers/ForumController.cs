using CMS.Models.Repositories;
using CMS.Models.ViewModels.CreateViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CMS.Controllers
{
    [Authorize]
    public class ForumController : Controller
    {
        ISiteRepository repository;

        public ForumController(ISiteRepository repository)
        {
            this.repository = repository;
        }

        // GET: Forum
        public ActionResult CreateThread()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateThread(CreateThreadViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            repository.CreateThread(model);

            return RedirectToAction("Index", "Home");
        }
    }
}