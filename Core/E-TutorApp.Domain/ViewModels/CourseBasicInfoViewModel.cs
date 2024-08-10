﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_TutorApp.Domain.ViewModels
{
    public class CourseBasicInfoViewModel
    {
        public string? Title { get; set; }
        public string? Subtitle { get; set; }
        public string? CourseCategory { get; set; }
        public string? CourseSubCategory { get; set; }
        public string? CourseTopic { get; set; }
        public string? CourseLanguage { get; set; }
        public string? SubtitleLanguage { get; set; }
        public string? CourseLevel { get; set; }
        public string? Duration { get; set; }
        public string? DurationUnit { get; set; }



        public List<string>? Categories { get; set; }
        public List<string>? SubCategories { get; set; }
        public List<string>? Languages { get; set; }
        public List<string>? SubtitleLanguages { get; set; }
        public List<string>? Levels { get; set; }
        public List<string>? DurationUnits { get; set; }
    }

}
