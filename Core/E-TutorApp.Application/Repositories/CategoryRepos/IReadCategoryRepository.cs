using E_TutorApp.Application.Repositories.Common;
using E_TutorApp.Domain.Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_TutorApp.Application.Repositories.CategoryRepos
{
    public  interface IReadCategoryRepository : IReadGenericRepository<Category>
    {
        Task<IEnumerable<Course>> GetAllCoursesWithCategoryId(string categoryid);
        Task<IEnumerable<Course>> GetAllCoursesWithCategoryName(string  categoryName);
        
    }
}
