using E_TutorApp.Domain.Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_TutorApp.Domain.ViewModels
{
    public class MainCourseVM
    {
        public string ? Id { get; set; } = Guid.NewGuid().ToString();
        public string? Title { get; set; }
        public string? Subtitle { get; set; }
        public string? InstructorName { get; set; }
        public string? TrailerVideo { get; set; }
        public string? Description { get; set; }
        public List<string>? Requirements { get; set; }
        public List<CourseSection>? Curriculum { get; set; }
    }

}
