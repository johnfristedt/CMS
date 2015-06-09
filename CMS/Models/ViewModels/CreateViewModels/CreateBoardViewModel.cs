using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CMS.Models.ViewModels.CreateViewModels
{
    public class CreateBoardViewModel
    {
        [Required]
        [Display(Name="New board name")]
        public string Name { get; set; }
    }
}