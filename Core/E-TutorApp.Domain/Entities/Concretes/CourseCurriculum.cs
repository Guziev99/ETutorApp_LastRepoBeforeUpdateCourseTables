using E_TutorApp.Domain.Entities.Abstracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_TutorApp.Domain.Entities.Concretes
{
    public  class CourseCurriculum : BaseEntity
    {


        // Foreign keys
        //[ForeignKey("AdvanceInfos")]
        public string AdvanceInfosId { get; set; }

        // Nav props
        [ForeignKey("AdvanceInfosId")]
        public virtual CourseAdvanceInfos AdvanceInfos { get; set; }
        public virtual IEnumerable<CourseSection>? Sections { get; set; }
    }
}
