using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CMS.Models.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Required field")]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Required field")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Required field")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        [Display(Name = "Confirm password")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Required field")]
        [EmailAddress]
        [Display(Name = "E-Mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Required field")]
        [Display(Name = "Secret question")]
        public string Question { get; set; }

        [Required(ErrorMessage = "Required field")]
        [Display(Name = "Secret answer")]
        public string Answer { get; set; }
    }
}