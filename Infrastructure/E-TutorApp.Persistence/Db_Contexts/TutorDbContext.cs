using E_TutorApp.Domain.Entities.Concretes;
using E_TutorApp.Domain.Entities.Concretes;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace E_TutorApp.Persistence.Db_Contexts
{
    public  class TutorDbContext : IdentityDbContext<User>
    {


        public TutorDbContext(DbContextOptions<TutorDbContext> options)
    : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);   
            foreach(var foreignKey in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) 
            { 
                foreignKey.DeleteBehavior = DeleteBehavior.NoAction;
            }
        }

        // Tables
        public virtual  DbSet<CourseBasicInfos> CourseBasics { get; set; }
        public virtual DbSet<CourseAdvanceInfos> CourseAdvances { get; set; }
        public virtual DbSet<CourseCurriculum > CourseCurriculum { get; set; }
        public virtual DbSet<CourseSection> CourseSections { get; set; }
        public virtual DbSet<CourseLecture> CourseLectures { get; set;}
        public virtual DbSet<Feedback> Feedbacks { get; set; }
        
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Invoice> Invoices { get; set; }
        public virtual DbSet<DetailInstructor> DetailInstructors { get; set; }
        public virtual DbSet<DetailStudent > DetailStudents { get; set; }     




    }
}

