using E_TutorApp.Application.Repositories.CategoryRepos;
using E_TutorApp.Domain.Entities.Concretes;
using E_TutorApp.Persistence.Db_Contexts;
using E_TutorApp.Persistence.Repositories.Common;
using E_TutorApp.Domain.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_TutorApp.Persistence.Repositories.CategoryRepos
{
    public class ReadCategoryRepository : ReadGenericRepository<Category>, IReadCategoryRepository
    {
        public ReadCategoryRepository(TutorDbContext dbcontext) : base(dbcontext)
        {
        }

        public async Task<IEnumerable<CourseBasicInfos>?> GetAllCoursesWithCategoryId(string categoryid)
        {
            //var category = await _table.FirstOrDefaultAsync(c => c.Id == categoryid);
            //if (category is not null)
            //{
            //     return  category.Courses;
            //}
            //return null;

            var courses =  _table.Include(c => c.Courses).FirstOrDefault(c => c.Id.Contains(categoryid))?.Courses;
            return courses;

        }

        public async Task<IEnumerable<CourseBasicInfos>?> GetAllCoursesWithCategoryName(string categoryName)
        {
            var courses  =  _table.Include(c => c.Courses).FirstOrDefault(c => c.Name == categoryName)?.Courses!.ToList();
            return courses;
        }

        
    }
}
