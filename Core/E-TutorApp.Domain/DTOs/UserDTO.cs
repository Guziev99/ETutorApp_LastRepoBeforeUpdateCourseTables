using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_TutorApp.Domain.DTOs
{
    public  class UserDTO
    {

        
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? UserName { get; set; }
        public string Password { get; set; }
        public string? ProfilePicture { get; set; }
        public string? Bio { get; set; }

        ///  Note :  Role DTO uzerinden deyil, string olaraq ayrica teleb edeceyem. 
        ///  public string Role. 
    }
}
