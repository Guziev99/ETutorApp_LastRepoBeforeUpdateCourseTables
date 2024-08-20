using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_TutorApp.Domain.ViewModels
{
    public class LectureDetailViewModel
    {
        public string? LectureId { get; set; }
        public string? LectureName { get; set; }
        public string VideoUrl { get; set; }
        public string AttachFile { get; set; }
        public string Caption { get; set; }
        public string Description { get; set; }
        public string LectureNotes { get; set; }
    }
}
