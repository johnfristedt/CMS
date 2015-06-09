using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CMS.Models.EntityModels
{
    public class Thread
    {
        public int Id { get; set; }
        public int BoardId { get; set; }
        public string Name { get; set; }
        public Post[] Posts { get; set; }
    }
}