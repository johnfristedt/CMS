using CMS.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CMS.Models.Contexts
{
    public class CMSContext : DbContext
    {
        public DbSet<Board> Boards { get; set; }
        public DbSet<Thread> Threads { get; set; }
        public DbSet<Post> Posts { get; set; }

        public DbSet<Page> Pages { get; set; }

        public CMSContext(string connection)
            : base(connection)
        {
        }
    }
}