using E_TutorApp.Domain.Entities.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_TutorApp.Domain.Entities.Concretes
{
    public  class Category : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string? IconUrl { get; set; }

        // Navigation Property

        public virtual ICollection<CourseBasicInfos>? Courses { get; set; }
    }
}
