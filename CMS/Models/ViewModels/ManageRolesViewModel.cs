using CMS.Models.ViewModels.CreateViewModels;
using CMS.Models.ViewModels.EditViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMS.Models.ViewModels
{
    public class ManageRolesViewModel
    {
        public CreateRoleViewModel CreateRoleViewModel { get; set; }
        public EditRoleViewModel EditRoleViewModel { get; set; }
    }
}