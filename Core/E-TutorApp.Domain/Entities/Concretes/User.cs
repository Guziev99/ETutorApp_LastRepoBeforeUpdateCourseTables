using E_TutorApp.Domain.Entities.Abstracts;
using E_TutorApp.Domain.Entities.Common;
//using Microsoft.AspNet.Identity;
//using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Identity;




//using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_TutorApp.Domain.Entities.Concretes
{
    public  class User : IdentityUser, IBaseEntity
    {

        // Columns
        //
        // public string? UserName { get; set; }
        //public string? Email { get; set; }


        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Address { get; set; }
        public string? ProfilePicture { get; set; }
        public string? Bio { get; set; }

        // Foreign Key


        //public string? InstructorDetailId { get; set; }
        //public string ? StudentDetailId { get; set; }



        // Navigation Properties

        public virtual DetailInstructor? DetailOfInstrutctor { get; set; }

        public virtual DetailStudent? DetailStudent { get; set; }
        




    }
}
