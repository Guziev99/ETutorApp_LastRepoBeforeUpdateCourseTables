using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_TutorApp.Domain.ViewModels
{
    public  class AllCoursesOfInstructorVM
    {
        public string Title { get; set; }
        public string? CategoryId { get; set; }
        public string CategoryName { get; set; }
        public double  Price { get; set; }
        public string ImgUrl { get; set; }
        public int SaleCount { get; set; }
        public float RatingScore { get; set; }
    }
}
