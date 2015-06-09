using CMS.Models.Repositories;
using CMS.Models.ViewModels.CreateViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CMS.Controllers
{
    [Authorize(Roles="ROLE_ADMIN, ROLE_CMS_ADMIN")]
    public class CMSController : Controller
    {
        ISiteRepository repository;

        public CMSController(ISiteRepository repository)
        {
            this.repository = repository;
        }

        // GET: CMS
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateBoard()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateBoard(CreateBoardViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            repository.CreateBoard(model);

            return RedirectToAction("Index");
        }
    }
}