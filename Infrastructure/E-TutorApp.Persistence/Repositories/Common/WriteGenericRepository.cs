using E_TutorApp.Application.Repositories.Common;
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
    public class WriteGenericRepository<T> : GenericRepository<T>, IWriteGenericRepository<T> where T : class, IBaseEntity, new()
    {
        public WriteGenericRepository(TutorDbContext dbcontext) : base(dbcontext)
        {
        }

        public async Task AddAsync(T entity)
        {
           await  _table.AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await _table.AddRangeAsync(entities);
        }

        public async Task DeleteAsync(T entity)
        {
             _table.Remove(entity);
        }

        public async Task DeleteAsync(string id)
        {
            var entity =await _table.FirstOrDefaultAsync(x => x.Id == id);
            _table.Remove(entity!);
        }

        public async Task SaveChangeAsync()
        {
            await _dbcontext.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _table.Update(entity);
        }
    }
}
