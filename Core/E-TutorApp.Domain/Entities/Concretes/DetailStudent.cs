using E_TutorApp.Domain.Entities.Abstracts;
using E_TutorApp.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_TutorApp.Domain.Entities.Concretes
{
    public class DetailStudent : BaseEntity
    {
        // Foreign key
        public string StudentId { get; set; }

        // Nav Props
        public virtual User Student { get; set; }
        public virtual IEnumerable<Course>? EnrolledCoursesOfStudent { get; set; }
    }
}
