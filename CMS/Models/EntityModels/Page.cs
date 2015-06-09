using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMS.Models.EntityModels
{
    public class Page
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
    }
}