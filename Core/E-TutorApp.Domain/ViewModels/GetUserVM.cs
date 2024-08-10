using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_TutorApp.Domain.ViewModels
{
    public  class GetUserVM
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? UserName { get; set; }
        public bool? ConfirmEmail { get; set; }
        public byte[]? PasswordHash { get; set; }
        public byte[]? PasswordSalt { get; set; }

        // Foreign Key

        public int RoleId { get; set; }
        public int UserTokenId { get; set; }
    }
}
