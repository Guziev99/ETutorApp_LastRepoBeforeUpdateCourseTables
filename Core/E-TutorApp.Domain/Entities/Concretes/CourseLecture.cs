using E_TutorApp.Domain.Entities.Abstracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_TutorApp.Domain.Entities.Concretes
{
    public  class CourseLecture : BaseEntity
    {

        public string Name { get; set; }
        public string? VideoUrl { get; set; }                // public byte[] Video { get; set; }   
        public string? AttachFileUrl { get; set; }           // public byte[] AttachFile { get; set; }   
        public string? Caption { get; set; }
        public string? Description { get; set; }
        public string ? LectureNotes { get; set; }

        // Foreign Keys
        public string SectionId { get; set; }

        // Nav props
        [ForeignKey("SectionId")]
        public virtual CourseSection Section { get; set; }
        public virtual List<Feedback>? Comments { get; set; }
    }
}
