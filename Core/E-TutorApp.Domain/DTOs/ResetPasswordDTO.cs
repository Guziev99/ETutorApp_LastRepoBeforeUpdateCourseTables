using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_TutorApp.Domain.DTOs
{
    public class ResetPasswordDTO
    {

        // Fields
        public string Password { get; set; }
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }

}
