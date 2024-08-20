using E_TutorApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace E_TutorApp.Domain.ViewModels
{
    public class CourseBasicInfoViewModel
    {
        //public string? Title { get; set; }
        //public string? Subtitle { get; set; }
        //public string? Topic { get; set; }
        //public int? Duration { get; set; }
        //public DurationUnit? DurationUnit { get; set; }

        //public string? Language { get; set; }
        //public string? SubtitleLanguage { get; set; }
        //public string? CategoryName { get; set; }
        //public string? SubCategoryName { get; set; }
        //public Level? Level { get; set; }



        public string  Id {  get; set; }

        public int Salecount { get; set; } = 0;
        public float? Rating { get; set; } = 5;
        public string    ImgUrl {  get; set; }
        public string CategoryName {  get; set; }

        public float? Price { get; set; }

        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string Topic { get; set; }
        public string CourseCategory { get; set; }
        public string CourseSubCategory { get; set; }
        public string CourseTopic { get; set; }
        public string CourseLanguage { get; set; }
        public string SubtitleLanguage { get; set; }
        public string CourseLevel { get; set; }
        public string Duration { get; set; }
        public string DurationUnit { get; set; }

        public string InstructorName { get; set; }






        //public List<string> Categories { get; set; }
        //public List<string> SubCategories { get; set; }
        //public List<string> Languages { get; set; }
        //public List<string> SubtitleLanguages { get; set; }
        //public List<string> Levels { get; set; }
        //public List<string> DurationUnits { get; set; }






    }

}
