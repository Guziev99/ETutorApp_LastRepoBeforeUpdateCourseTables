using E_TutorApp.Domain.Entities.Abstracts;
using E_TutorApp.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_TutorApp.Domain.Entities.Concretes
{
    public  class DetailInstructor : BaseEntity
    {

        // Foreign Key
        public string  InstructorId { get; set; }

        // Nav props
        public virtual IEnumerable<Course>? AllCoursesOfInstructor { get; set; }
        public virtual User Instructor { get; set; }

        
    }
}
