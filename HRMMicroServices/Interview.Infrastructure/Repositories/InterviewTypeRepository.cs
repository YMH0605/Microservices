
using Dapper;
using Interview.Core.Contracts.Repositories;
using Interview.Core.Entities;
using Interview.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.Infrastructure.Repositories
{
    public class InterviewTypeRepository : IBaseRepository<InterviewType>, IInterviewTypeRepository
    {
        protected readonly InterviewDbContext dbContext;

        public InterviewTypeRepository(InterviewDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<int> DeleteAsync(int id)
        {
            using (IDbConnection conn = dbContext.GetConnection())
            {
                return await conn.ExecuteAsync("Delete From InterviewTypes Where LookupCode=@LookupCode", new { LookupCode = id });
            }
        }

        public async Task<IEnumerable<InterviewType>> GetAllAsync()
        {
            using (IDbConnection conn = dbContext.GetConnection())
            {
                return await conn.QueryAsync<InterviewType>("Select * From InterviewTypes");
            }
        }

        public async Task<InterviewType> GetByIdAsync(int id)
        {
            using (IDbConnection conn = dbContext.GetConnection())
            {
                return await conn.QuerySingleOrDefaultAsync<InterviewType>("Select * From InterviewTypes Where LookupCode=@LookupCode", new { LookupCode = id });
            }
        }

        public async Task<int> InsertAsync(InterviewType entity)
        {
            using (IDbConnection conn = dbContext.GetConnection())
            {
                return await conn.ExecuteAsync("Insert Into InterviewTypes Values(@Description)", entity);
            }
        }

        public async Task<int> UpdateAsync(InterviewType entity)
        {
            using (IDbConnection conn = dbContext.GetConnection())
            {
                return await conn.ExecuteAsync("Update InterviewTypes set Description=@Description Where LookupCode=@LookupCode", entity);
            }
        }
    }
}
