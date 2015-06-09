using CMS.Models.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Security;
using AutoMapper;
using CMS.Models.EntityModels;

namespace CMS.Models.Repositories
{
    public class DbSiteRepository : ISiteRepository
    {
        const string DEV_DB_CONNECTION = "CMSDB";
        string activeConnection = DEV_DB_CONNECTION;

        public EntityModels.Board[] GetBoards()
        {
            using (var db = new CMSContext(activeConnection))
            {
                return db.Boards.ToArray();
            }
        }

        public EntityModels.Thread[] GetThreadsForBoard(int boardId)
        {
            using (var db = new CMSContext(activeConnection))
            {
                var threads = db.Threads.Where(t => t.BoardId == boardId).ToArray();

                foreach (var item in threads)
                {
                    item.Posts = db.Posts
                        .Where(p => p.ThreadId == item.Id)
                        .OrderByDescending(p => p.TimePosted)
                        .Take(2)
                        .ToArray();
                }

                return threads;
            }
        }

        public EntityModels.Post[] GetPostsForThread(int threadId)
        {
            using (var db = new CMSContext(activeConnection))
            {
                return db.Posts.Where(p => p.ThreadId == threadId).ToArray();
            }
        }

        public void CreateBoard(ViewModels.CreateViewModels.CreateBoardViewModel model)
        {
            using (var db = new CMSContext(activeConnection))
            {
                db.Boards.Add(Mapper.Map<Board>(model));
                db.SaveChanges();
            }
        }


        public void CreateThread(ViewModels.CreateViewModels.CreateThreadViewModel model)
        {
            using (var db = new CMSContext(activeConnection))
            {
                db.Threads.Add(Mapper.Map<Thread>(model));
                db.SaveChanges();
            }
        }

        public void CreatePage(ViewModels.CreateViewModels.CreatePageViewModel model)
        {
            using (var db = new CMSContext(activeConnection))
            {
                db.Pages.Add(Mapper.Map<Page>(model));
                db.SaveChanges();
            }
        }
    }
}