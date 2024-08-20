using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_TutorApp.Domain.ViewModels.AddCurriculumVMs
{
    public class SectionViewModel
    {
        public string? Id { get; set; }
        public string? CurriculumId { get; set; }
        public string? Name { get; set; }
        public List<LectureViewModel>? Lectures { get; set; } = new List<LectureViewModel>();
    }
}
