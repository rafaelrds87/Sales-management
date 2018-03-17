using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models
{
    public class LoginInfo
    {
        [Display(Name = "User Name")]
        [Required(ErrorMessage = "The user name is required.")]
        [StringLength(20, ErrorMessage = "The length should be lower than 20.")]
        public string Username { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "The password is required.")]
        public string Password { get; set; }
    }
}