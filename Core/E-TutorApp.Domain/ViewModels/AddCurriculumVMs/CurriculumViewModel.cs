using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_TutorApp.Domain.ViewModels.AddCurriculumVMs
{
    public class CurriculumViewModel
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string CourseAdvancesId { get; set; }
        public List<SectionViewModel> Sections { get; set; } = new List<SectionViewModel>();
    }
}
