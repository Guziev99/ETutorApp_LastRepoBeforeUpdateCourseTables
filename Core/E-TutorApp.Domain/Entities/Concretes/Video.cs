using E_TutorApp.Domain.Entities.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_TutorApp.Domain.Entities.Concretes
{
    public  class Video : BaseEntity
    {
        public string VideoUrl { get; set; }

        public string LectureId { get; set; }

        public virtual Lecture Lecture { get; set; }
    }
}
