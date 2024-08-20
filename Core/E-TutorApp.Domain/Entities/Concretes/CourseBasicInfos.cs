using E_TutorApp.Domain.Entities.Abstracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_TutorApp.Domain.Entities.Concretes
{
    public class CourseBasicInfos : BaseEntity
    {
        public string? Title { get; set; }
        public string? Subtitle { get; set; }
        public string? CategoryName { get; set; }
        public string? SubCategoryName { get; set; }
        public string? Topic { get; set; }
        public string? Language { get; set; }
        public string? SubtitleLanguage { get; set; }
        public string? Level { get; set; }
        public string? Duration { get; set; }
        public string? DurationUnit { get; set; }


        // internal project properties
        public int SaleCount { get; set; } = 0;
        public bool IsActive { get; set; } = true;
        public bool? IsCompleted { get; set; }
        public float? RatingScore { get; set; } = 5;
        public float ? Price { get; set; }


        // Foreign Keys
        public string? InstructorId { get; set; }
        public string CategoryId { get; set; }

        // Nav props
        [ForeignKey("InstructorId")]
        public virtual DetailInstructor Instructor { get; set; }
        public virtual IEnumerable<DetailStudent>? Students { get; set; }
        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }
        public virtual ICollection<Invoice>? Invoices { get; set; }
        public virtual CourseAdvanceInfos? AdvanceInfos { get; set; }

        public virtual List<Feedback>?  Feedbacks { get; set; }

    }

}
