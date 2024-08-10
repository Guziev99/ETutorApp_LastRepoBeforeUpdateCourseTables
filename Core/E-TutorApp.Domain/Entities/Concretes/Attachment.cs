using E_TutorApp.Domain.Entities.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_TutorApp.Domain.Entities.Concretes
{
    public  class Attachment : BaseEntity
    {
        public List <string >? Assignment {  get; set; }
        public List<string>? ImageUrl { get; set; }
        public List<string> ? MaterialUrl { get; set; }

        public string ? LectureId { get; set; }

        public virtual Lecture? Lecture { get; set; }
    }
}
