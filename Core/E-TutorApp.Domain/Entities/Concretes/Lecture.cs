using E_TutorApp.Domain.Entities.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_TutorApp.Domain.Entities.Concretes
{
    public  class Lecture : BaseEntity
    {
        public string Name {  get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string VideoUrl { get; set; }

        // Foreign Key
        public string SectureId { get; set; }


        // Nav props
        public virtual Secture  Secture { get; set; }
        public virtual Attachment? Attachment { get; set; }
        public virtual Video Video { get; set; }
    }
}
