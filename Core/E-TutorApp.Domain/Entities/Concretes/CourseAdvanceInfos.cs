using E_TutorApp.Domain.Entities.Abstracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_TutorApp.Domain.Entities.Concretes
{
    public  class CourseAdvanceInfos : BaseEntity
    {

        public string? ThumbnailUrl { get; set; }     /// byte[]
        public string? Trailer { get; set; }          /// byte []
        public string ? Description { get; set; }

        public List< string > ? ContentSummary { get; set; }    
         
        public List<string>?  TargetAudience { get; set; }
        public List <string>? Requirements { get; set; }


        // Foreign Key
        public string  BasicInfosId {  get; set; }


        // Nav props
        [ForeignKey("BasicInfosId")]
        public virtual CourseBasicInfos BasicInfos { get; set; }
        public virtual CourseCurriculum? Curriculum { get; set; }
    }
}
