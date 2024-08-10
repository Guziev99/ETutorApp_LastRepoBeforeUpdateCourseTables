using E_TutorApp.Application.Repositories.Common;
using E_TutorApp.Domain.Entities.Common;
using E_TutorApp.Persistence.Db_Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace E_TutorApp.Persistence.Repositories.Common
{
    public class ReadGenericRepository<T> : GenericRepository<T>, IReadGenericRepository<T> where T : class, IBaseEntity, new()
    {
        public ReadGenericRepository(TutorDbContext dbcontext) : base(dbcontext)
        {
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return  _table;
        }

        public async Task<IQueryable<T>> GetByExpressionAsync(Expression<Func<T, bool>> expression)
        {
            return  _table.Where(expression);
        }

        public async Task<T> GetByIdAsync(string id)
        {
            var entity = await _table.FirstOrDefaultAsync(e => e.Id.Contains( id));
            return entity;
        }

    }
}
