using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CMS.Models.EntityModels;

namespace CMS.Models.ViewModels
{
    public class ThreadViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Post[] Posts { get; set; }

    }
}