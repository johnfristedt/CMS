using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CMS.Models.ViewModels.CreateViewModels
{
    public class CreatePageViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Content { get; set; }
    }
}