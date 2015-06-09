using AutoMapper;
using CMS.Models.Repositories;
using CMS.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CMS.Controllers
{
    public class HomeController : Controller
    {
        ISiteRepository repository;

        public HomeController(ISiteRepository repository)
        {
            this.repository = repository;
        }

        // GET: Home
        public ActionResult Index()
        {
            return View(Mapper.Map<BoardViewModel[]>(repository.GetBoards()));
        }

        public ActionResult Board(int id)
        {
            return View(Mapper.Map<ThreadViewModel[]>(repository.GetThreadsForBoard(id)));
        }

        [Authorize]
        public ActionResult Thread(int id)
        {
            return View(Mapper.Map<PostViewModel[]>(repository.GetPostsForThread(id)));
        }
    }
}