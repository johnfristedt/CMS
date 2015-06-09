using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CMS.Models.DataModels
{
    public class UpdateUserModel
    {
        [Required]
        public string User { get; set; }
        [Required]
        public string[] UserRoles { get; set; }
    }
}