using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_TutorApp.Domain.DTOs
{
    public  class CourseDTO
    {
        public string? Name { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public float? Price { get; set; }
        public string? ImageUrl { get; set; }

        public string CategoryName { get; set; }
        public string InstructorId { get; set; }
    }
}
