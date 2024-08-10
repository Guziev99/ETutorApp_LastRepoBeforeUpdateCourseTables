using E_TutorApp.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace E_TutorApp.Application.Repositories.Common
{
    public  interface IReadGenericRepository <T> : IGenericRepository<T> where T : class, IBaseEntity, new()
    {
         Task< IEnumerable<T> > GetAllAsync();
         Task<IQueryable<T>> GetByExpressionAsync(Expression<Func<T, bool>> expression);
         Task<T> GetByIdAsync(string id);
    }
}
