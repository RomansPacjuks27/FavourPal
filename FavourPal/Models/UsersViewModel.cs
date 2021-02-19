using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FavourPal.Models
{
    public class UsersViewModel
    {
        [Required(ErrorMessage = "First Name is required!")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required!")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email address is required!")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Confirm Email")]
        [Compare("Email", ErrorMessage = "Email addresses does not match!")]
        public string ConfirmEmail { get; set; }

        [Required(ErrorMessage = "Password is required!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords does not match!")]
        public string ConfirmPassword { get; set; }

        //[Display(Name = "Remember Me")]
        //public bool RememberMe { get; set; } = false;
    }
}
