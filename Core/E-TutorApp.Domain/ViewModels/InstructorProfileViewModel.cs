using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_TutorApp.Domain.ViewModels
{
    public class InstructorProfileViewModel
    {
        public string UserName { get; set; }
        public string Title { get; set; }
        public string AboutMe { get; set; }
        public string InstructorImg { get; set; }
        public int CourseCount { get; set; }
        public double RatingScore { get; set; }
        public int StudentCount { get; set; }
        public List<CourseViewModel> Courses { get; set; }
    }

    public class CourseViewModel
    {

        public string Title { get; set; }
        public string? CategoryId { get; set; }
        public string CategoryName { get; set; }
        public float Price { get; set; }
        public string ImgUrl { get; set; }
    }
}
