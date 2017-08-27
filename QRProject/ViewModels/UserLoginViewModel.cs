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
        [Required(AllowEmptyStrings =false, ErrorMessage ="Email wymagany")]
        public string Email { get; set; }

        [Required(AllowEmptyStrings =false,ErrorMessage ="Hasło wymagane")]
        [DataType(DataType.Password)]
        [Display(Name ="Hasło")]
        public string Password { get; set; }

        [Display(Name ="Pamiętaj mnie")]
        public bool Remember { get; set; }

        public string Role { get; set; }
    }
}