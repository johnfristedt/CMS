using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMS.Models.EntityModels
{
    public class User
    {
        public string UserName { get; set; }
        public DateTime LastActivityDate { get; set; }
    }
}