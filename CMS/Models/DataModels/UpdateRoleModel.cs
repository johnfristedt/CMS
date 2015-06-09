using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CMS.Models.DataModels
{
    public class UpdateRoleModel
    {
        [Required]
        public string Role { get; set; }
        [Required]
        public string[] UsersInRole { get; set; }
    }
}