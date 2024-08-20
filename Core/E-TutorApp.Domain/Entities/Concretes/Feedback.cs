using E_TutorApp.Domain.Entities.Abstracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_TutorApp.Domain.Entities.Concretes
{
    public  class Feedback : BaseEntity
    {
        public string Username { get; set; }
        public float? GivenRating { get; set; }
        public string ReviewText { get; set; }


        //Foreign Key
        public string? CourseInfosId { get; set; }
        public string? LectureId { get; set; }

        // Nav Props
        [ForeignKey(nameof(CourseInfosId ))]

        public virtual CourseBasicInfos? CourseInfos { get; set; }
        [ForeignKey(nameof (LectureId))]
        public virtual CourseLecture? Lecture { get; set; }

    }
}
