using Dapper;
using Interview.Core.Contracts.Repositories;
using Interview.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.Infrastructure.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        //protected readonly InterviewDbContext dbContext;

        //public BaseRepository(InterviewDbContext dbContext)
        //{
        //    this.dbContext = dbContext;
        //}

        //public async Task<int> DeleteAsync(int id)
        //{
        //    T t = await GetByIdAsync(id);
        //    if (t != null)
        //    {
        //        dbContext.Set<T>().Remove(t);
        //        return await dbContext.SaveChangesAsync();
        //    }
        //    return 0;
        //}

        //public async Task<IEnumerable<T>> GetAllAsync()
        //{
        //    return await dbContext.Set<T>().ToListAsync();
        //}

        //public async Task<T> GetByIdAsync(int id)
        //{
        //    return await dbContext.Set<T>().FindAsync(id);
        //}

        //public async Task<int> InsertAsync(T entity)
        //{
        //    dbContext.Set<T>().Add(entity);
        //    return await dbContext.SaveChangesAsync();
        //}

        //public async Task<int> UpdateAsync(T entity)
        //{
        //    dbContext.Set<T>().Update(entity);
        //    return await dbContext.SaveChangesAsync();
        //}
        public Task<int> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<T> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> InsertAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
