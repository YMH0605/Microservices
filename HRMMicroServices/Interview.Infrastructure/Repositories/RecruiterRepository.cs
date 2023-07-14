
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
    public class RecruiterRepository : IBaseRepository<Recruiter>, IRecruiterRepository
    {
        protected readonly InterviewDbContext dbContext;

        public RecruiterRepository(InterviewDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<int> DeleteAsync(int id)
        {
            using (IDbConnection conn = dbContext.GetConnection())
            {
                return await conn.ExecuteAsync("Delete From Recruiters Where RecruiterId=@RecruiterId", new { RecruiterId = id });
            }
        }

        public async Task<IEnumerable<Recruiter>> GetAllAsync()
        {
            using (IDbConnection conn = dbContext.GetConnection())
            {
                return await conn.QueryAsync<Recruiter>("Select * From Recruiters");
            }
        }

        public async Task<Recruiter> GetByIdAsync(int id)
        {
            using (IDbConnection conn = dbContext.GetConnection())
            {
                return await conn.QuerySingleOrDefaultAsync<Recruiter>("Select * From Recruiters Where RecruiterId=@RecruiterId", new { RecruiterId = id });
            }
        }

        public async Task<int> InsertAsync(Recruiter entity)
        {
            using (IDbConnection conn = dbContext.GetConnection())
            {
                return await conn.ExecuteAsync("Insert Into Recruiters Values(@FirstName, @LastName, @EmployeeId)", entity);
            }
        }

        public async Task<int> UpdateAsync(Recruiter entity)
        {
            using (IDbConnection conn = dbContext.GetConnection())
            {
                return await conn.ExecuteAsync("Update Recruiters set FirstName=@FirstName, LastName=@LastName, EmployeeId=@EmployeeId Where RecruiterId=@RecruiterId", entity);
            }
        }
    }
}
