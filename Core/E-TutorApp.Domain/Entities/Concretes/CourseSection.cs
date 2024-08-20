using E_TutorApp.Domain.Entities.Abstracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_TutorApp.Domain.Entities.Concretes
{
    public  class CourseSection : BaseEntity
    {
        public string Name { get; set; }


        // Foreign Keys
        public string CurriculumId { get; set; }


        // Nav props
        [ForeignKey("CurriculumId")]
        public virtual CourseCurriculum Curriculum { get; set; }
        public virtual IEnumerable<CourseLecture>? Lectures { get; set; }
    }
}
