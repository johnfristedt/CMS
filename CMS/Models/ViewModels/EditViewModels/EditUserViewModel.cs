using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CMS.Models.ViewModels.EditViewModels
{
    public class EditUserViewModel
    {
        [Display(Name="User")]
        public List<SelectListItem> Users { get; set; }
        [Display(Name="Roles")]
        public List<SelectListItem> UserRoles { get; set; }
        public List<SelectListItem> AvailableRoles { get; set; }
    }
}