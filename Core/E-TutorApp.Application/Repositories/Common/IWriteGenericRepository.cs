using E_TutorApp.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace E_TutorApp.Application.Repositories.Common
{
    public interface IWriteGenericRepository<T> : IGenericRepository<T> where T : class, IBaseEntity, new()
    {
        Task AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entities);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task DeleteAsync(string id);
        Task SaveChangeAsync();


    }
}
