using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_TutorApp.Domain.ViewModels
{
    public class CurriculumDetailViewModel
    {
        public string ? CurriculumId { get; set; }
        public string CurriculumName { get; set; }
        public IList<SectionDetailViewModel>? Sections { get; set; }
    }


}
