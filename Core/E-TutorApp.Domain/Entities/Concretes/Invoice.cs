using E_TutorApp.Domain.Entities.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_TutorApp.Domain.Entities.Concretes
{
    public  class Invoice :BaseEntity
    {
        public float Quantity { get; set; }
        public string  InstructorId { get; set; }
        public string  StudentId { get; set; }
        public string? SellCourseId { get; set; }


        // Nav props
        public virtual Course Course { get; set; }
    }
}
