using E_TutorApp.Domain.Entities.Abstracts;
using E_TutorApp.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
        [ForeignKey(nameof(InstructorId))]
        public virtual User Instructor { get; set; }
        public virtual IEnumerable<CourseBasicInfos>? AllCoursesOfInstructor { get; set; }
       

        
    }
}
