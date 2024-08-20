using E_TutorApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_TutorApp.Domain.ViewModels
{
    public  class CourseCreateBasicsViewModel
    {
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string Topic { get; set; }
        public int Duration { get; set; }
        public DurationUnit DurationUnit { get; set; }

        public string Language { get; set; }
        public string SubtitleLanguage { get; set; }
        public string CategoryName { get; set; }
        public string SubCategoryName { get; set; }
        public Level Level { get; set; }
    }
}
