using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CMS.Models.ViewModels.EditViewModels
{
    public class EditRoleViewModel
    {
        [Display(Name="Role")]
        public List<SelectListItem> Roles { get; set; }
        [Display(Name="Users")]
        public List<SelectListItem> UsersInRole { get; set; }
        public List<SelectListItem> AvailableUsers { get; set; }
    }
}