using E_TutorApp.Domain.Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_TutorApp.Domain.ViewModels
{
    public class StudentDashboardVM
    {
        public int EnrolledCourseCount { get; set; }
        public int CompletedCourseCount { get; set; }
        public int ActiveCourseCount { get; set; }
        public List<CourseBasicInfos> Courses { get; set; }
    }

}
