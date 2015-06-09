using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CMS.Models.ViewModels.CreateViewModels
{
    public class CreateThreadViewModel
    {
        [Required]
        public int ThreadId { get; set; }
        [Required]
        [Display(Name="Thread topic")]
        public int Name { get; set; }
        [Required]
        [Display(Name = "Post content")]
        public string PostContent { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public DateTime TimePosted { get; set; }
    }
}