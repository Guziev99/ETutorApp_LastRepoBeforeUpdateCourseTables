using E_TutorApp.Domain.Entities.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_TutorApp.Domain.Entities.Concretes
{
    public  class Secture : BaseEntity
    {
        public string Name { get; set; }
        
        public string CurriculumId { get; set; }

        public virtual  IEnumerable <Lecture> Lectures { get; set; }
        public virtual Curriculum Curriculum { get; set; }
    }
}
