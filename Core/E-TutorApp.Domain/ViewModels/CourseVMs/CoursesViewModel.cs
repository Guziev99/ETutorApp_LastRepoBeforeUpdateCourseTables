using E_TutorApp.Domain.Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_TutorApp.Domain.ViewModels.CourseVMs
{
    public class CoursesViewModel
    {
        public string? CourseName { get; set; }
        public string? Filter { get; set; }
        public List<CourseBasicInfos>? Courses { get; set; }
    }
}
