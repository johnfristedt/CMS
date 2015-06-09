using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CMS.Models.DataModels
{
    public class RoleInfo
    {
        public List<SelectListItem> UsersInRole { get; set; }
        public List<SelectListItem> AvailableUsers { get; set; }
    }
}