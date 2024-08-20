using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_TutorApp.Domain.ViewModels
{
    public  class CourseAdvanceCreateViewModel
    {

        public string? Id { get; set; }
        public string? CourseId { get; set; }
            
            public string? Description { get; set; }
            
            public List<string>? ContentSummary { get; set; } = new List<string> { "", "", "", "" };
            public List<string>? TargetAudience { get; set; } = new List<string> { "", "", "", "" };
            public List<string>? Requirements { get; set; } = new List<string> { "", "", "", "" };

        

    }
}
