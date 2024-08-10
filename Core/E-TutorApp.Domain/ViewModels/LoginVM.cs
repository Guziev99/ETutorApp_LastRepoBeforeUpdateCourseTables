using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_TutorApp.Domain.ViewModels
{
    public  class LoginVM
    {

        [Required]
        [Display(Name = "Username or Email")]
        public string UserNameOrEmail { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; } = false;
    }
}
