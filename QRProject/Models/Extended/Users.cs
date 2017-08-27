using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace QRProject.Models
{


    [MetadataType(typeof(UserMetadata))]
    public partial class Users
    {
        public string ConfirmPassword { get; set; }
    }

    public class UserMetadata
    {
        [Display(Name ="Imię")]
        [Required(AllowEmptyStrings =false, ErrorMessage ="Imię jest wymagane")]
        public string FirstName { get; set; }

        [Display(Name = "Nazwisko")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Nazwisko jest wymagane")]
        public string LastName { get; set; }

        [Display(Name = "Email")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Email jest wymagany")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name ="Data urodzin")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString ="{0:MM-dd-yyyy}")]
        public DateTime DateOfBirth { get; set; }

        [Required(AllowEmptyStrings =false, ErrorMessage ="Hasło jest wymagane")]
        [DataType(DataType.Password)]
        [MinLength(6,ErrorMessage ="Hasło ma zawierać co najmniej 6 znaków")]
        [Display(Name="Hasło")]
        public string Password { get; set; }

        [Display(Name ="Potwierdź hasło")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage="Podano złe hasło potwierdzające")]
        public string ConfirmPassword { get; set; }
    }
}