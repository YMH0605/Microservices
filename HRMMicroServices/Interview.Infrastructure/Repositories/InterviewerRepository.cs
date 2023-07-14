
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
    public class InterviewerRepository : IBaseRepository<Interviewer>, IInterviewerRepository
    {
        protected readonly InterviewDbContext dbContext;

        public InterviewerRepository(InterviewDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<int> DeleteAsync(int id)
        {
            using (IDbConnection conn = dbContext.GetConnection())
            {
                return await conn.ExecuteAsync("Delete From Interviewers Where InterviewerId=@InterviewerId", new { InterviewerId = id });
            }
        }

        public async Task<IEnumerable<Interviewer>> GetAllAsync()
        {
            using (IDbConnection conn = dbContext.GetConnection())
            {
                return await conn.QueryAsync<Interviewer>("Select * From Interviewers");
            }
        }

        public async Task<Interviewer> GetByIdAsync(int id)
        {
            using (IDbConnection conn = dbContext.GetConnection())
            {
                return await conn.QuerySingleOrDefaultAsync<Interviewer>("Select * From Interviewers Where InterviewerId=@InterviewerId", new { InterviewerId = id });
            }
        }

        public async Task<int> InsertAsync(Interviewer entity)
        {
            using (IDbConnection conn = dbContext.GetConnection())
            {
                return await conn.QuerySingleAsync<int>("Insert Into Interviewers Output Inserted.InterviewerId Values(@FirstName, @LastName, @EmployeeId)", entity);
            }
        }

        public async Task<int> UpdateAsync(Interviewer entity)
        {
            using (IDbConnection conn = dbContext.GetConnection())
            {
                return await conn.ExecuteAsync("Update Interviewers set FirstName=@FirstName, LastName=@LastName, EmployeeId=@EmployeeId Where InterviewerId=@InterviewerId", entity);
            }
        }
    }
}
