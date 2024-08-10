using E_TutorApp.Application.Repositories.CategoryRepos;
using E_TutorApp.Domain.Entities.Concretes;
using E_TutorApp.Persistence.Db_Contexts;
using E_TutorApp.Persistence.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_TutorApp.Persistence.Repositories.CategoryRepos
{
    public class WriteCategoryRepository : WriteGenericRepository<Category>, IWriteCategoryRepository
    {
        public WriteCategoryRepository(TutorDbContext dbcontext) : base(dbcontext)
        {
        }
    }
}
