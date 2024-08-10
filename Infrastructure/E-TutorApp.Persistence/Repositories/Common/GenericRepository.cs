using E_TutorApp.Domain.Entities.Common;
using E_TutorApp.Persistence.Db_Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_TutorApp.Persistence.Repositories.Common
{
    public  class GenericRepository <T> where T : class, IBaseEntity, new()
    {
        protected TutorDbContext _dbcontext;
        protected DbSet<T> _table;
        public GenericRepository(TutorDbContext dbcontext)
        {
            _dbcontext = dbcontext;
            _table = dbcontext.Set<T>();
        }
    }
}
