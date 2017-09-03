using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QRProject.Models
{
    public class UserLoginViewModel
    {

        [Display(Name ="Email")]
        [Required(AllowEmptyStrings =false, ErrorMessage ="Email is required")]
        public string Email { get; set; }

        [Required(AllowEmptyStrings =false,ErrorMessage ="Password is required")]
        [DataType(DataType.Password)]
        [Display(Name ="Password")]
        public string Password { get; set; }

        [Display(Name ="Remember me")]
        public bool Remember { get; set; }

        public string Role { get; set; }
    }
}