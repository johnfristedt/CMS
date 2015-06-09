using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CMS.Models.EntityModels
{
    public class Post
    {
        public int Id { get; set; }
        public int ThreadId { get; set; }
        public string Author { get; set; }
        public string Content { get; set; }
        public DateTime TimePosted { get; set; }
    }
}