using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_TutorApp.Domain.ViewModels.AddCurriculumVMs
{
    public class LectureViewModel
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string? SectionId { get; set; }
        public string LectureName { get; set; }
       // public IFormFile? VideoUrl { get; set; }
       // public IFormFile  ? AttachFile { get; set; }
        public string? Caption { get; set; }
        public string? Description { get; set; }
        public string? LectureNotes { get; set; }
    }

}
