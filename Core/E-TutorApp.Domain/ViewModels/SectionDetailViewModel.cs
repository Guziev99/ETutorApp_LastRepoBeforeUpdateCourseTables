using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_TutorApp.Domain.ViewModels
{
    public class SectionDetailViewModel
    {
        public string ? SectionId { get; set; }
        public string SectionName { get; set; }
        public IList<LectureDetailViewModel>? Lectures { get; set; }
    }
}
