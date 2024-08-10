using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_TutorApp.Domain.ViewModels
{
    public class RegisterVM
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public bool Agreed { get; set; }


    }
        

//public class RegisterVM
//    {
//        [Required(ErrorMessage = "First Name is required")]
//        public string FirstName { get; set; }

//        [Required(ErrorMessage = "Last Name is required")]
//        public string LastName { get; set; }

//        [Required(ErrorMessage = "Username is required")]
//        public string UserName { get; set; }

//        [Required(ErrorMessage = "Email is required")]
//        [EmailAddress(ErrorMessage = "Invalid Email Address")]
//        public string Email { get; set; }

//        [Required(ErrorMessage = "Password is required")]
//        [DataType(DataType.Password)]
//        public string Password { get; set; }

//        [Required(ErrorMessage = "Confirm Password is required")]
//        [DataType(DataType.Password)]
//        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
//        public string ConfirmPassword { get; set; }

//        [Required(ErrorMessage = "You must agree to the terms and conditions")]
//        public bool Agreed { get; set; }
//    }

}

