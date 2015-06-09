using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CMS.Models.DataModels
{
    public class UserRoleInfo
    {
        public List<SelectListItem> UserRoles { get; set; }
        public List<SelectListItem> AvailableRoles { get; set; }
    }
}