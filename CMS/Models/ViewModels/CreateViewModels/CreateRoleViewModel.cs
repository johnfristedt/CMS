using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CMS.Models.ViewModels.CreateViewModels
{
    public class CreateRoleViewModel
    {
        [Required]
        [Display(Name="New role name")]
        public string RoleName { get; set; }
    }
}