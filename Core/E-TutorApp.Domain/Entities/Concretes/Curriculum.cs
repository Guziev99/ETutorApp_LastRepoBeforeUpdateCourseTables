using E_TutorApp.Domain.Entities.Abstracts;
using E_TutorApp.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_TutorApp.Domain.Entities.Concretes
{
    public class Curriculum : BaseEntity
    {
       // public string Name { get; set; }
        // Foreign key
        public string CourseId { get; set; }

        // Nav props
        public virtual Course Course { get; set; }
        public virtual IEnumerable<Secture> Sectures { get; set; }
    }
}
