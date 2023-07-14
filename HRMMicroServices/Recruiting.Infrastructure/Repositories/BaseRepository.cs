using Microsoft.EntityFrameworkCore;
using Recruiting.Core.Contracts.Repositories;
using Recruiting.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recruiting.Infrastructure.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly RecruitingDbContext dbContext;

        public BaseRepository(RecruitingDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<int> DeleteAsync(int id)
        {
            T t = await GetByIdAsync(id);
            if (t != null)
            {
                dbContext.Set<T>().Remove(t);
                return await dbContext.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await dbContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await dbContext.Set<T>().FindAsync(id);
        }

        public async Task<int> InsertAsync(T entity)
        {
            dbContext.Set<T>().Add(entity);
            return await dbContext.SaveChangesAsync();
        }

        public async Task<int> UpdateAsync(T entity)
        {
            dbContext.Set<T>().Update(entity);
            return await dbContext.SaveChangesAsync();
        }
    }
}
